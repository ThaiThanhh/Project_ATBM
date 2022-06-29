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
    public partial class RevokePrivs : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            ); User Id =DB_ADMIN;password=1234";
        public RevokePrivs()
        {
            InitializeComponent();
        }

        private void button_add_role_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void RevokePrivs_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from DBA_ROLES where role = :role_name";
            cmd.Parameters.Add(":role_name", txt_rolename.Text.ToUpper());
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable roles = new DataTable();
            roles.Load(dr);

            if (roles.Rows.Count == 0)
            {
                MessageBox.Show("Role " + txt_rolename.Text.ToUpper() + " không tồn tại");
            }
            else
            {
                //revoke privs
                try
                {
                    OracleCommand cmd_revole_privs = new OracleCommand();
                    cmd_revole_privs.Connection = con;
                    cmd_revole_privs.CommandText = "soytex.Revoke_Role_Privs";
                    cmd_revole_privs.CommandType = CommandType.StoredProcedure;
                    if (txt_rolename.Text == null)
                    {
                        MessageBox.Show("Role không tồn tại");
                    }
                    else
                    {

                        cmd_revole_privs.Parameters.Add(new OracleParameter("role_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txt_rolename.Text.ToUpper();
                        cmd_revole_privs.Parameters.Add(new OracleParameter("privs_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txt_privsname.Text;
                        cmd_revole_privs.Parameters.Add(new OracleParameter("obj", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txt_obj.Text;
                        cmd_revole_privs.ExecuteNonQuery();
                        MessageBox.Show("Đã thu hồi quyền " + txt_privsname.Text.ToUpper() + " cho role " + txt_rolename.Text.ToUpper() + " trên đối tượng " + txt_obj.Text.ToUpper());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();
        }
    }
}
