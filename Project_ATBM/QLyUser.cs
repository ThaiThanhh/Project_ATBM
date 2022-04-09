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
            (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-ONG9HE4)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=1";

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
    }
}
