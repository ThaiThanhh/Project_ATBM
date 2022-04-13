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
    public partial class GrantPrivelegetoUser : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=5906341";
        
        public GrantPrivelegetoUser(string username)
        {
            InitializeComponent();
            username_txtbox.Text = username;
        }

        private void GrantPrivelegetoUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = username_txtbox.Text.Trim().ToUpper();
            string priv = comboBox1.SelectedItem.ToString().ToUpper();
            string table = textBox1.Text.Trim().ToUpper();
            int option;
            if (radioButton1.Checked == true)
            {
                option = 1;
            }
            else option = 0;
            
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "proc_grant_priv";
                cmd_drop_user.CommandType = CommandType.StoredProcedure;
                cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = user_name;
                cmd_drop_user.Parameters.Add(new OracleParameter("p_table", OracleDbType.Varchar2, ParameterDirection.Input)).Value = table;
                cmd_drop_user.Parameters.Add(new OracleParameter("priv", OracleDbType.Varchar2, ParameterDirection.Input)).Value = priv;
                cmd_drop_user.Parameters.Add(new OracleParameter("grant_option", OracleDbType.Int64, ParameterDirection.Input)).Value = option;
                
                cmd_drop_user.ExecuteNonQuery();
                MessageBox.Show("Cấp quyền thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
