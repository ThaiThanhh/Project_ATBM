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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim().ToUpper();
            string password = txtpassword.Text.Trim();
            string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            ); User Id = " + username + ";password=" + password;
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            OracleCommand command = new OracleCommand();
            command.Connection = con;

            command.CommandText = "SELECT HoTen, VaiTro FROM SOYTEX.NHANVIEN WHERE MANV = :username";
            command.Parameters.Add("username", username);
            command.CommandType = CommandType.Text;

            string role = "";
            string name = "";
            try
            {
                con.Open();
                OracleDataReader roleList = command.ExecuteReader();
                while (roleList.Read())
                {
                    if (!roleList.HasRows)
                        break;
                    role = roleList.GetValue(1).ToString();
                    name = roleList.GetValue(0).ToString(); 
                }

                if (role == "Thanh tra")
                {
                    ThanhTra form = new ThanhTra(username, name, password);
                    this.Hide();
                    form.Show();
                    con.Close();
                }
                else if (role == "Y si/ Bac si")
                {
                    BacSi form = new BacSi(username, name, password);
                    this.Hide();
                    form.Show();
                    con.Close();
                }
                else if (role == "Nghien cuu")
                {
                    Researcher form = new Researcher(username, password);
                    this.Hide();
                    form.Show();
                    con.Close();
                }
                else if (role == "Co so y te")
                {
                    MedicalRecord form = new MedicalRecord(username, password);
                    this.Hide();
                    form.Show();
                    con.Close();
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number.ToString() == "1017")
                {
                    MessageBox.Show("Nhập sai user name hoặc password!");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}
   