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
    public partial class QLyUser : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=5906341";

        public QLyUser()
        {
            InitializeComponent();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy dữ liệu cho table danh sách các user trong hệ thống
            OracleCommand getUsers = new OracleCommand();

            getUsers.CommandText = "SELECT username, user_id, account_status, lock_date, expiry_date, created, authentication_type, default_tablespace FROM dba_users";

            getUsers.Connection = con;

            getUsers.CommandType = CommandType.Text;

            OracleDataReader userList = getUsers.ExecuteReader();

            DataTable tableUserList = new DataTable();

            tableUserList.Load(userList);

            dataGridView1.DataSource = tableUserList;

            con.Close();
        }

        private void QLyUser_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser form = new AddUser();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy dữ liệu cho table danh sách các user trong hệ thống
            OracleCommand getUsers = new OracleCommand();

            getUsers.CommandText = "SELECT username, user_id, account_status, lock_date, expiry_date, created, authentication_type, default_tablespace FROM dba_users";

            getUsers.Connection = con;

            getUsers.CommandType = CommandType.Text;

            OracleDataReader userList = getUsers.ExecuteReader();

            DataTable tableUserList = new DataTable();

            tableUserList.Load(userList);

            dataGridView1.DataSource = tableUserList;

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
                cmd_drop_user.CommandText = "proc_drop_user";
                cmd_drop_user.CommandType = CommandType.StoredProcedure;
                cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = cellValue;
                cmd_drop_user.ExecuteNonQuery();
                MessageBox.Show("Đã xóa user " + cellValue + " thành công!");
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
            //input username
            string user_name = txtusername_search.Text.Trim().ToUpper();
            
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                //Search User
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "proc_search_user";
                cmd_drop_user.CommandType = CommandType.StoredProcedure;
                cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = user_name;
                OracleDataReader user = cmd_drop_user.ExecuteReader();
                DataTable tableUserList = new DataTable();

                tableUserList.Load(user);

                dataGridView1.DataSource = tableUserList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditUser form = new EditUser();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //get clicked cell value
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["USERNAME"].Value);

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            PrivsManage form = new PrivsManage(cellValue);
            form.Show();
        }
    }
}
