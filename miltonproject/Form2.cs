using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace miltonproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            maskedTextBox_password.PasswordChar = '*'; //Jelszó kicsillagozása
        }

        //Kapcsolódása adatok továbbítása a Form1re 
        public void button_logon_Click(object sender, EventArgs e)
        {
            string cs = @"server="+ textBox_server.Text + ";userid="+ textBox_username.Text + ";password="+ maskedTextBox_password.Text + ";database="+ textBox_username.Text;
            Form1 f1 = new Form1(cs);
          
            this.Hide();
            f1.ShowDialog();
            this.Close();

        }
    }
}
