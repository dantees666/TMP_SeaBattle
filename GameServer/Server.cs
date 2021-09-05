using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace GameServer
{
    public class Server //класс описывающий работу сервера
    {
        private string ip;
        private int port;
        Socket listenSocket, handler;

        public string Ip
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                if (value > 0)
                    port = value;
                else
                    throw new FormatException();
            }
        }

        public Server(string ip = "127.0.0.1", int port = 8888)
        {
            Ip = ip;
            Port = port;
            Init();
        }

        public void Init()
        {
            // Получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // Создаем сокет
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Связываем сокет с локальной адресом, по которому будем принимать значение
            listenSocket.Bind(ipPoint);
            listenSocket.Listen(10);
            Console.WriteLine("Сервер запущен. Ожидание подключений...");
        }

        public void Send(string message)//отправка сообщения
        {
            byte[] data = Encoding.Unicode.GetBytes(message); // Формируем сообщение в нужной кодировке
            handler.Send(data);

            DisposeHandler();
        }

        public string Recieve()//функция для принятия сообщений
        {
            handler = listenSocket.Accept(); // Получаем сообщение
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] data = new byte[256]; // Буффер для полученных данных

            do
            {
                bytes = handler.Receive(data);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (handler.Available > 0);

            if(builder.ToString() == "CreateConnection")
                Console.WriteLine(DateTime.Now.ToShortTimeString() + " [+] установлено соединение с клиентом");
            else
                Console.WriteLine(DateTime.Now.ToShortTimeString() + " [+] ответ клиента получен");

            return builder.ToString();
        }

        private void DisposeHandler()
        {
            if (handler != null)
            {
                // Закрываем сокет
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                handler = null;
            }
        }

        public void DisposeListenSocket()
        {
            if (listenSocket != null)
            {
                // Закрываем сокет
                listenSocket.Shutdown(SocketShutdown.Both);
                listenSocket.Close();
                listenSocket = null;
            }
        }

        ~Server()
        {
            DisposeHandler();
            DisposeListenSocket();
        }
    }
}