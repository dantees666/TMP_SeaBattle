using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Game
    {
        public const int mapSize = 11;
        public bool[,] myMap = new bool[mapSize, mapSize]; // bots
        public bool[,] targetMap = new bool[mapSize, mapSize]; //players

        public Game()
        {
            Restart();
        }

        public void Restart()
        {
            Init();
            ConfigureShips();
        }

        private void Init()
        {
            for (int i = 0; i < mapSize; i++)
                for (int j = 0; j < mapSize; j++)
                {
                    myMap[i, j] = false;
                    targetMap[i, j] = false;
                }
        }

        private bool IsInsideMap(int i, int j)
        {
            if (i < 0 || j < 0 || i >= mapSize || j >= mapSize)
                return false;
            return true;
        }

        private bool IsEmpty(int i, int j, int length)
        {
            for (int k = j; k < j + length; k++)
                if (myMap[i, k])
                    return false;
            return true;
        }

        private void ConfigureShips()
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
        }

        public string Shoot()
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

            return posX + "-" + posY;
        }

        public string IsHit(string coord)
        {
            int x = coord.Split('-').Select(int.Parse).ToList().ElementAt(0);
            int y = coord.Split('-').Select(int.Parse).ToList().ElementAt(1);
            if (myMap[y, x])
                return "true";
            else
                return "false";
        }
    }
}
