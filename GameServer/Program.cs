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
                    string answer = server.Recieve(), message = "0";
                    if (answer == "Shoot")
                        message = game.Shoot();
                    else if (answer.Contains('-'))
                        message = game.IsHit(answer);
                    else if (answer == "End")
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
