using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Game //класс описывает поведение бота
    {
        public const int mapSize = 11;
        public bool[,] myMap = new bool[mapSize, mapSize]; //карта бота
        public bool[,] targetMap = new bool[mapSize, mapSize]; //карта игрока

        public Game() //конструктор класса
        {
            Restart();
        }

        public void Restart() //функция очищает карту и расставляет корабли бота на карте
        {
            Init();
            ConfigureShips();
        }

        private void Init() //функция  очищает матрицы карты бота и игрока
        {
            for (int i = 0; i < mapSize; i++)
                for (int j = 0; j < mapSize; j++)
                {
                    myMap[i, j] = false;
                    targetMap[i, j] = false;
                }
        }

        private bool IsInsideMap(int i, int j) //функция проверяет существует ли ячейка с выбранными координатами внутри нашей матрицы
        {
            if (i < 0 || j < 0 || i >= mapSize || j >= mapSize)
                return false;
            return true;
        }

        private bool IsEmpty(int i, int j, int length) //функция проверяет свободны ли ячейки с [i, j] до [i, j + length]
                                                       //для добавления корабля
        {
            for (int k = j; k < j + length; k++)
                if (myMap[i, k])
                    return false;
            return true;
        }

        private void ConfigureShips() //функция размещает на карте бота корабли
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

        public string Shoot() //функция случайно выбирает свободную
                              //клетку для выстрела и возращает его координаты
        {
            Random r = new Random();

            //Проверим не стрелял ли бот туда
            int posX, posY;
            do
            {
                posX = r.Next(1, mapSize);
                posY = r.Next(1, mapSize);
            }
            while (targetMap[posX, posY]);
            targetMap[posX, posY] = true; //отмечаем ячейку после выстрела

            return posX + "-" + posY;
        }

        public string IsHit(string coord) //функция проверяет попал ли игрок по кораблю бота
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
