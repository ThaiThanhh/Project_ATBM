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
    public partial class GrantRoletoUser : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=1";
        public GrantRoletoUser(string username)
        {
            InitializeComponent();
            username_txtbox.Text = username;
        }

        private void GrantRoletoUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = username_txtbox.Text.Trim().ToUpper();
            string role = role_txtbox.Text.Trim().ToUpper();

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "proc_grant_role";
                cmd_drop_user.CommandType = CommandType.StoredProcedure;
                cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = user_name;
                cmd_drop_user.Parameters.Add(new OracleParameter("role", OracleDbType.Varchar2, ParameterDirection.Input)).Value = role;
               
                cmd_drop_user.ExecuteNonQuery();
                MessageBox.Show("Gán role thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
