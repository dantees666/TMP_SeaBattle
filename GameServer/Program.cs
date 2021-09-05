using System;
using System.Linq;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Server server = new Server();
                Game game = new Game();
                while (true)
                {
                    string answer = server.Recieve(), //получаем сообщение от клиента
                    message = "0";

                    if (answer == "Shoot")//команда на выстрел бота
                        message = game.Shoot();
                    else if (answer.Contains('-'))//команда на проверку попал ли игрок
                        message = game.IsHit(answer);
                    else if (answer == "End")//команда на перезапуск игры
                        game.Restart();
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
