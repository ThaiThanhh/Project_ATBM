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
    public partial class ThanhTra : Form
    {
        string user_name = "";
        string pass = "";
        public ThanhTra(string username,string name, string password)
        {
            InitializeComponent();
            Header.Text = Header.Text + " " + username;
            user_name = username;
            pass = password;
        }

        private void ThanhTra_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            ); User Id = " + user_name + ";password=" + pass;
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            OracleCommand command = new OracleCommand();
            command.Connection = con;
            con.Open(); 

            ComboBox cb = sender as ComboBox;
            string str = cb.SelectedItem.ToString();
            if (str == "Bệnh nhân")
            {
                command.CommandText = "SELECT * FROM SOYTEX.BENHNHAN";
            }
            else if (str == "Nhân viên")
            {
                command.CommandText = "SELECT * FROM SOYTEX.NHANVIEN";
            }
            else if (str == "Cơ sở y tế")
            {
                command.CommandText = "SELECT * FROM SOYTEX.CSYT";

            }
            else if (str == "Hồ sơ bệnh án")
            {
                command.CommandText = "SELECT * FROM SOYTEX.HSBA";

            }
            else
            {
                command.CommandText = "SELECT * FROM SOYTEX.HSBA_DV";
            }
            command.CommandType = CommandType.Text;
            OracleDataReader data = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(data);
            ThanhTra_dataGridView.DataSource = table;
            con.Close();
        }

        private void ThanhTra_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
