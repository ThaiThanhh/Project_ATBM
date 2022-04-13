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
    public partial class QuanLyRole : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=oracleqa1409";

        public QuanLyRole()
        {
            InitializeComponent();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy dữ liệu cho table danh sách các role trong hệ thống
            OracleCommand getRoles = new OracleCommand();

            getRoles.CommandText = "SELECT * FROM DBA_ROLES";

            getRoles.Connection = con;

            getRoles.CommandType = CommandType.Text;

            OracleDataReader roleList = getRoles.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleList);

            dataGridView1.DataSource = tableRoleList;

            con.Close();
        }

        private void QuanLyRole_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRole form = new AddRole();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy dữ liệu cho table danh sách các roles trong hệ thống
            OracleCommand getRoles = new OracleCommand();

            getRoles.CommandText = "SELECT * FROM DBA_ROLES";

            getRoles.Connection = con;

            getRoles.CommandType = CommandType.Text;

            OracleDataReader roleList = getRoles.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleList);

            dataGridView1.DataSource = tableRoleList;

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //get clicked cell value
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["USERNAME"].Value);

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                //Drop user
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "Drop_Role";
                cmd_drop_user.CommandType = CommandType.StoredProcedure;
                cmd_drop_user.Parameters.Add(new OracleParameter("role_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = cellValue;
                cmd_drop_user.ExecuteNonQuery();
                MessageBox.Show("Đã xóa role " + cellValue + " thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //input rolename
            string role_name = txtrolename_search.Text.Trim().ToUpper();

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                //Search Role
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "proc_search_user";
                cmd_drop_user.CommandType = CommandType.StoredProcedure;
                cmd_drop_user.Parameters.Add(new OracleParameter("role_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = role_name;
                OracleDataReader user = cmd_drop_user.ExecuteReader();
                DataTable tableRoleList = new DataTable();

                tableRoleList.Load(user);

                dataGridView1.DataSource = tableRoleList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditRole form = new EditRole();
            form.Show();
        }

        private void txtusername_search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
