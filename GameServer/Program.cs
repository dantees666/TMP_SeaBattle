using System;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Server server = new Server();
                while (true)
                {
                    string answer = server.Recieve();
                    string message = "сам ты дебил";
                    server.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
