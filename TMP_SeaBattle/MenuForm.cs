using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMP_SeaBattle
{
    public partial class MenuForm : Form
    {
        const string defaultIp = "127.0.0.1";
        const int defaultPort = 8888;
        Client client;

        public MenuForm()
        {
            InitializeComponent();

            ipInput.Text = defaultIp;
            portInput.Text = defaultPort.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                client = new Client(ipInput.Text,int.Parse(portInput.Text));
                client.Interact("CreateConnection");
                Hide();
                GameForm gameForm = new GameForm(client);
                gameForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
