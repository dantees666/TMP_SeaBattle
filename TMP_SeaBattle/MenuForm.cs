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
        Client client;
        public MenuForm()
        {
            InitializeComponent();
            client = new Client();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "татуировку де бил?";
                MessageBox.Show(client.Interact(message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
