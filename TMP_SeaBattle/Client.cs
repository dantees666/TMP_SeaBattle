using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TMP_SeaBattle
{
    public class Client //класс описывающий взаимодействие клиента с сервером
    {
        private string ip;
        private int port;
        Socket socket;

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

        public Client(string ip = "127.0.0.1", int port = 8888) //конструктор
        {
            Ip = ip;
            Port = port;
        }

        public void Init() // создать сокет и подключится к серверу
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint); // Подключаемся к удаленному хосту
        }

        public string Interact(string message) //отправить запрос и получить ответ
        {
            Init();
            byte[] data = Encoding.Unicode.GetBytes(message); // Формируем сообщение в нужной кодировке
            socket.Send(data);

            // Получаем ответ
            data = new byte[256]; // Буфер для ответа
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // Количество полученных байт
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            Dispose();

            return builder.ToString();
        }

        public void Dispose() //закрыть сокеты
        {
            // Закрываем сокет
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
        }
    }
}
