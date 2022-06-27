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
    public partial class MedicalRecord : Form
    {
        string user_name = "";
        string pass = "";
        public MedicalRecord(string username, string password)
        {
            InitializeComponent();
            user_name = username;
            pass = password;
        }


        private void buttonAdd_Click(object sender, EventArgs e)
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

            if (textBoxPatient.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân!");
            }
            else if (textBoxDiagnose.Text == "")
            {
                MessageBox.Show("Vui lòng nhập chẩn đoán!");
            }
            else if (textBoxDoctor.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã Bác sĩ!");
            }
            else if (textBoxMajor.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã Khoa!");
            }
            else if (textBoxMaHSBA.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hồ sơ bệnh án!");
            }
            else if (textBoxCSYT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã cơ sở y tế!");
            }
            else if (textBoxDate.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày!");
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SOYTEX.proc_insert_HSBA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_mahsba", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxMaHSBA.Text; ;
                cmd.Parameters.Add(new OracleParameter("p_patient", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxPatient.Text;
                cmd.Parameters.Add(new OracleParameter("p_date", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxDate.Text;
                cmd.Parameters.Add(new OracleParameter("p_diagnose", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxDiagnose.Text;
                cmd.Parameters.Add(new OracleParameter("p_doctor", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxDoctor.Text;
                cmd.Parameters.Add(new OracleParameter("p_major", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxMajor.Text;
                cmd.Parameters.Add(new OracleParameter("p_csyt", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxCSYT.Text;
                cmd.Parameters.Add(new OracleParameter("p_result", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxResult.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm hồ sơ bệnh án mới");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
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
            if (cellValue.ToUpper().StartsWith("HSBA_DV"))
            {
                cmd.CommandText = "DELETE FROM SOYTEX.HSBA_DV WHERE MAHSBA = :id_hsba";
            }
            else
            {
                cmd.CommandText = "DELETE FROM SOYTEX.HSBA WHERE MAHSBA = :id_hsba";
            }

            cmd.Parameters.Add(":id_hsba", cellValue.ToUpper());
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable tableServiceMedicalRecord = new DataTable();
            tableServiceMedicalRecord.Load(dr);
            listMedicalRecord.DataSource = tableServiceMedicalRecord;

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

        private void MedicalRecord_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
