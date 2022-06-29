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
    public partial class AddRole : Form
    {

        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );User Id = DB_ADMIN;password=1234";

        public AddRole()
        {
            InitializeComponent();
        }

        private void AddRole_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addRoleBtn_Click(object sender, EventArgs e)
        {

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from DBA_ROLES where role = :role_name";
            cmd.Parameters.Add(":role_name", txtrolename.Text.ToUpper());
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable users = new DataTable();
            users.Load(dr);

            if (users.Rows.Count > 0)
            {
                MessageBox.Show("Role " + txtrolename.Text.ToUpper() + " đã tồn tại");
            }
            else
            {
                //add user
                try
                {

                    OracleCommand cmd_add_role = new OracleCommand();
                    cmd_add_role.CommandType = CommandType.Text;
                    cmd_add_role.CommandText = "alter session set \"_ORACLE_SCRIPT\"=true;\n ";
                    cmd_add_role.CommandText += "create role :role_name identified by :pass";
                    cmd_add_role.Parameters.Add(":role_name", txtrolename.Text);
                    cmd_add_role.Parameters.Add(":pass", txtidentitymode.Text);
                    cmd_add_role.Connection = con;
                    cmd_add_role.ExecuteNonQuery();                 
                }
                catch (Exception ex)
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

        private void txtrolename_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtidentitymode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
