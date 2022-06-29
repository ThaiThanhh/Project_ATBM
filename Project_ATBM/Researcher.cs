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
    public partial class Researcher : Form
    {
        string user_name = "";
        string pass = "";
        public Researcher(string username, string password)
        {
            InitializeComponent();
            user_name = username;
            pass = password;
        }
        private void buttonViewHSBA_Click(object sender, EventArgs e)
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
            con.Open();

            //Lấy dữ liệu cho table Hồ sơ bệnh án
            OracleCommand getListMedicalRecord = new OracleCommand();

            getListMedicalRecord.CommandText = "SELECT * FROM SOYTEX.HSBA";
            getListMedicalRecord.Connection = con;
            getListMedicalRecord.CommandType = CommandType.Text;
            OracleDataReader listRecord = getListMedicalRecord.ExecuteReader();
            DataTable tableMedicalRecord = new DataTable();
            tableMedicalRecord.Load(listRecord);
            listMedicalRecord.DataSource = tableMedicalRecord;

            con.Close();
        }
        private void buttonViewHSBADV_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            ); User Id = " + user_name + ";password=" + pass;
            OracleConnection con = new OracleConnection();
            //get clicked cell value
            int selectedrowindex = listMedicalRecord.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = listMedicalRecord.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["MAHSBA"].Value);

            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT * FROM SOYTEX.HSBA_DV WHERE MAHSBA = :id_hsba";
            cmd.Parameters.Add(":id_hsba", cellValue.ToUpper());
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable tableServiceMedicalRecord = new DataTable();
            tableServiceMedicalRecord.Load(dr);
            listMedicalRecord.DataSource = tableServiceMedicalRecord;

            con.Close();
        }
    }
}
