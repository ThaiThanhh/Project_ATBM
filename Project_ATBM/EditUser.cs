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
   
    public partial class EditUser : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=1";
        public EditUser()
        {
            InitializeComponent();
        }

        private void button_add_user_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from all_users where username = :user_name";
            cmd.Parameters.Add(":user_name", txt_username.Text.ToUpper());
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable users = new DataTable();
            users.Load(dr);

            if (users.Rows.Count == 0)
            {
                MessageBox.Show("Username " + txt_username.Text.ToUpper() + " không tồn tại");
            }
            else
            {
                //edit user
                try
                {
                    OracleCommand cmd_edit_user = new OracleCommand();
                    cmd_edit_user.Connection = con;
                    cmd_edit_user.CommandText = "proc_edit_user";
                    cmd_edit_user.CommandType = CommandType.StoredProcedure;
                    if (txtpassword.Text == null)
                    {
                        cmd_edit_user.Parameters.Add(":username", txt_username.Text.ToUpper());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm user mới");
                    }
                    else
                    {

                        cmd_edit_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txt_username.Text.ToUpper();
                        cmd_edit_user.Parameters.Add(new OracleParameter("new_password", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txtpassword.Text;
                        cmd_edit_user.ExecuteNonQuery();
                        MessageBox.Show("Đã chỉnh sửa user");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
