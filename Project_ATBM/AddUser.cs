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
    public partial class AddUser : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=1";
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from all_users where username = :user_name";
            cmd.Parameters.Add(":user_name", txtusername.Text.ToUpper());
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable users = new DataTable();
            users.Load(dr);

            if (users.Rows.Count > 0)
            {
                MessageBox.Show("Username " +  txtusername.Text.ToUpper()+ " đã tồn tại");
            }
            else
            {
                //add user
                try
                {
                    OracleCommand cmd_add_user = new OracleCommand();
                    cmd_add_user.Connection = con;
                    cmd_add_user.CommandText = "proc_add_user";
                    cmd_add_user.CommandType = CommandType.StoredProcedure;
                    if (txtpassword.Text == null)
                    {
                        cmd_add_user.Parameters.Add(":username", txtusername.Text.ToUpper());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm user mới");
                    }
                    else {
                
                        cmd_add_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txtusername.Text.ToUpper();
                        cmd_add_user.Parameters.Add(new OracleParameter("u_password", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txtpassword.Text;
                        cmd_add_user.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm user mới");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
