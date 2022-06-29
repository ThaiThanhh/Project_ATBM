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
    public partial class BacSi : Form
    {
        string user_name = "";
        string pass = "";
        public BacSi(string username, string name, string password)
        {
            InitializeComponent();
            Header.Text = Header.Text + " " + name;
            user_name = username;
            pass = password;
        }

        private void BS_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
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
            BS_dataGridView.DataSource = table;
            con.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            cb = comboBox1;
            string str = cb.SelectedItem.ToString();

            string searchText = searchBox.Text;
            if (str == "Bệnh nhân")
            {
                command.CommandText = $"SELECT * FROM SOYTEX.BENHNHAN WHERE MABN LIKE '%{searchText}%' or CMND LIKE '%{searchText}'";
            }
            else if (str == "Hồ sơ bệnh án")
            {
                command.CommandText = $"SELECT SOYTEX.HSBA.* FROM SOYTEX.HSBA JOIN SOYTEX.BENHNHAN ON SOYTEX.HSBA.MABN = SOYTEX.BENHNHAN.MABN WHERE SOYTEX.BENHNHAN.MABN LIKE '%{searchText}%' or CMND LIKE '%{searchText}'";

            }
            else
            {
                command.CommandText = $"SELECT SOYTEX.HSBA_DV.* FROM SOYTEX.HSBA_DV JOIN SOYTEX.BENHNHAN ON SOYTEX.HSBA_DV.MABN = SOYTEX.BENHNHAN.MABN WHERE SOYTEX.BENHNHAN.MABN LIKE '%{searchText}%' or CMND LIKE '%{searchText}'";
            }
            command.CommandType = CommandType.Text;
            OracleDataReader data = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(data);
            BS_dataGridView.DataSource = table;
            con.Close();
        }

        private void Header_Click(object sender, EventArgs e)
        {

        }
    }
}
