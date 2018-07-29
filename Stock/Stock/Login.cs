using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // To-Do: check login username & password
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                  FROM [Stock].[dbo].[Login] where UserName='"+ textBox1.Text +"' and Password='"+ textBox2.Text +"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            // this.hide is hide the login windows and run the Stockmain
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid UserName & Password..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
        }
    }
}
