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
    public partial class EditRole : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=1";
        public EditRole()
        {
            InitializeComponent();
        }

        private void button_add_role_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
                //edit role
                try
                {
                    OracleCommand cmd_edit_role = new OracleCommand();
                    cmd_edit_role.Connection = con;
                    cmd_edit_role.CommandText = "Alter_Role";
                    cmd_edit_role.CommandType = CommandType.StoredProcedure;
                    if (txtidentitymode.Text == null)
                    {
                        cmd_edit_role.Parameters.Add(":rolename", txt_rolename.Text.ToUpper());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm role mới");
                    }
                    else
                    {

                        cmd_edit_role.Parameters.Add(new OracleParameter("role_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txt_rolename.Text.ToUpper();
                        cmd_edit_role.Parameters.Add(new OracleParameter("identity_mode", OracleDbType.Varchar2, ParameterDirection.Input)).Value = txtidentitymode.Text;
                        cmd_edit_role.ExecuteNonQuery();
                        MessageBox.Show("Đã chỉnh sửa identity");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();
        }

        private void EditRole_Load(object sender, EventArgs e)
        {

        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
