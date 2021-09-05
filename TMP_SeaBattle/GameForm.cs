using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TMP_SeaBattle
{
    public partial class GameForm : Form //основная форма игры
    {
        private const int mapSize = 11;
        private int cellSize = 30;
        private string alphabet = "АБВГДЕЖЗИК";

        public Button[,] myButtons = new Button[mapSize, mapSize];
        public Button[,] enemyButtons = new Button[mapSize, mapSize];

        private int myBoatsCount = 0, enemyBoatsCount = 20;

        private bool isPlaying = false;

        Client client;

        public GameForm(Client client = null) //конструктор
        {
            this.client = client;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            isPlaying = false;
            CreateMaps();
        }

        public void CreateMaps() //создание карты
        {
            this.Width = mapSize * 2 * cellSize + 50;
            this.Height = (mapSize + 3) * cellSize + 20;
            for (int i = 0; i < mapSize; i++) //создание кораблей игрока и добавление соответствующих кнопок 
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(i * cellSize, j * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    else
                    {
                        button.Click += new EventHandler(ConfigureShips);
                    }
                    myButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            for (int i = 0; i < mapSize; i++) //создание кнопок для клеток бота
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(350 + i * cellSize, j * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    else
                    {
                        button.Click += new EventHandler(PlayerShoot);
                    }
                    enemyButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            Label map1 = new Label();
            map1.Text = "Карта игрока";
            map1.Location = new Point(mapSize * cellSize / 2, mapSize * cellSize + 10);
            this.Controls.Add(map1);

            Label map2 = new Label();
            map2.Text = "Карта противника";
            map2.Location = new Point(350 + mapSize * cellSize / 2, mapSize * cellSize + 10);
            this.Controls.Add(map2);

            Button startButton = new Button();
            startButton.Text = "Начать";
            startButton.Click += new EventHandler(Start);
            startButton.Location = new Point(0, mapSize * cellSize + 20);
            this.Controls.Add(startButton);
        }

        public void Start(object sender, EventArgs e) //событие для кнопки начать игру
        {
            isPlaying = true;
        }

        public void CheckIfGameEnded() //проверяет закончена ли игра и выводит результат
        {
            if (myBoatsCount <= 0)
            {
                DialogResult result = MessageBox.Show("Вы проиграли!", "Результат", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                    Application.Exit();
            }
            if (enemyBoatsCount <= 0)
            {
                DialogResult result = MessageBox.Show("Вы выиграли!", "Результат", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                    Application.Exit();
            }
        }

        public void ConfigureShips(object sender, EventArgs e) //событие при нажатие на кнопку для создания своего корабля
        {
            Button pressedButton = sender as Button;
            if (!isPlaying && myBoatsCount < 20)
            {
                if (pressedButton.BackColor == Color.White)
                {
                    pressedButton.BackColor = Color.Red;
                    myBoatsCount++;
                }
                else
                {
                    pressedButton.BackColor = Color.White;
                    myBoatsCount--;
                }
            }
        }

        public bool IsHit(string coord) //функция проверят попал ли бот
        {
            int x = coord.Split('-').Select(int.Parse).ToList().ElementAt(0);
            int y = coord.Split('-').Select(int.Parse).ToList().ElementAt(1);
            if (myButtons[y, x].BackColor == Color.Red)
            {
                myButtons[y, x].BackColor = Color.Blue;
                myButtons[y, x].Text = "X";
                myBoatsCount--;
                CheckIfGameEnded();
                return true;
            }
            else
            {
                myButtons[y, x].BackColor = Color.Black;
                return false;
            }
        }

        public void PlayerShoot(object sender, EventArgs e) //функция для вызова выстрела игрока
        {
            Button pressedButton = sender as Button;
            if (isPlaying)
                if (!Shoot(pressedButton))
                    while (IsHit(client.Interact("Shoot")));
        }

        public bool Shoot(Button pressedButton) //функция выстрела игрока
        {
            int delta = 350;
            int posX = (pressedButton.Location.X - delta) / cellSize;
            int posY = pressedButton.Location.Y / cellSize;
            if (client.Interact(posX + "-" + posY) == "true")
            {
                pressedButton.BackColor = Color.Blue;
                pressedButton.Text = "X";
                pressedButton.Enabled = false;
                enemyBoatsCount--;
                CheckIfGameEnded();
                return true;
            }
            else
            {
                pressedButton.BackColor = Color.Black;
                pressedButton.Enabled = false;
                return false;
            }
        }
    }
}
