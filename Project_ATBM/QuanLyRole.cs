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
            );User Id = DB_ADMIN;password=1234";

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
            string cellValue = Convert.ToString(selectedRow.Cells["ROLE"].Value);

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                //Drop role
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "soytex.Drop_Role";
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

        private void button5_Click(object sender, EventArgs e)
        {
            EditRole form = new EditRole();
            form.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            RevokePrivs form = new RevokePrivs();
            form.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            GrantPrivs form = new GrantPrivs();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy dữ liệu cho table danh sách các roles trong hệ thống
            OracleCommand getRoles = new OracleCommand();

            getRoles.CommandText = "select ROLE_TAB_PRIVS.role as \"Nhóm người dùng\", table_name as \"Tên bảng\", column_name as \"Tên cột\", privilege \"Quyền\" from ROLE_TAB_PRIVS join DBA_ROLES on ROLE_TAB_PRIVS.role = DBA_ROLES.role where DBA_ROLES.oracle_maintained = 'N'";

            getRoles.Connection = con;

            getRoles.CommandType = CommandType.Text;

            OracleDataReader roleList = getRoles.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleList);

            dataGridView1.DataSource = tableRoleList;

            con.Close();
        }
    }
}
