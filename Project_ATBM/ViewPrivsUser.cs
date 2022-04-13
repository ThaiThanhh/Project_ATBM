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
    public partial class ViewPrivsUser : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=1";
        public ViewPrivsUser(string user_name)
        {
            InitializeComponent();
            

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            try
            {
                //view privs of user
                OracleCommand cmd_view_privs = new OracleCommand();
                cmd_view_privs.Connection = con;
                cmd_view_privs.CommandText = "proc_privs_information";
                cmd_view_privs.CommandType = CommandType.StoredProcedure;
                cmd_view_privs.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = user_name;

                OracleDataReader privs = cmd_view_privs.ExecuteReader();
                DataTable tablePrivs = new DataTable();

                tablePrivs.Load(privs);

                dataGridViewPrivs.DataSource = tablePrivs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ViewPrivsUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
