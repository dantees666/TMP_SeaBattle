using System;

namespace GameServer
{
    class Program
    {
        public const int mapSize = 10;
        public bool[,] myMap = new bool[mapSize, mapSize]; // bots
        public bool[,] targetMap = new bool[mapSize, mapSize]; //players

        public bool IsInsideMap(int i, int j)
        {
            if (i < 0 || j < 0 || i >= mapSize || j >= mapSize)
                return false;
            return true;
        }

        public bool IsEmpty(int i, int j, int length)
        {
            for (int k = j; k < j + length; k++)
                if (myMap[i, k])
                    return false;
            return true;
        }

        public bool[,] ConfigureShips()
        {
            int lengthShip = 4;
            int cycleValue = 1;
            int shipsCount = 10;
            Random r = new Random();

            while (shipsCount > 0)
            {
                for (int i = 0; i < cycleValue; i++)
                {
                    int posX, posY;
                    do
                    {
                        posX = r.Next(1, mapSize);
                        posY = r.Next(1, mapSize);
                    }
                    while (!IsInsideMap(posX, posY + lengthShip - 1) || !IsEmpty(posX, posY, lengthShip));

                    for (int k = posY; k < posY + lengthShip; k++)
                        myMap[posX, k] = true;

                    shipsCount--;
                    if (shipsCount <= 0)
                        break;
                }
                cycleValue++;
                lengthShip--;
            }
            return myMap;
        }

        public bool Shoot()
        {
            Random r = new Random();

            // Проверим не стрелял ли бот туда
            int posX, posY;
            do
            {
                posX = r.Next(1, mapSize);
                posY = r.Next(1, mapSize);
            }
            while (targetMap[posX, posY]);
            targetMap[posX, posY] = true;

            // отправить координаты на сервер
            if (/*ответ сервера*/)
                return false;
            else
                return true;
        }

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
