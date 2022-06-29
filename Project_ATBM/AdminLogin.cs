using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace Project_ATBM
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim().ToUpper();
            string password = txtpassword.Text.Trim();
            //string connectionString = @"Data Source=(DESCRIPTION =
            //(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            //(CONNECT_DATA =
            //  (SERVER = DEDICATED)
            //  (SERVICE_NAME = XE)
            //)
            //); User Id = " + username + ";password=" + password;
            //OracleConnection con = new OracleConnection();
            //con.ConnectionString = connectionString;

            //OracleCommand command = new OracleCommand();
            //command.Connection = con;
            if (username == "DB_ADMIN" && password == "1234")
            {
                PanelPhanHe1 form = new PanelPhanHe1();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
