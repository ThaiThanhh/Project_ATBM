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

        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );DBA Privilege=SYSDBA; User Id = SYS;password=oracleqa1409";
        public MedicalRecord()
        {
            InitializeComponent();
        }

        private void label_Header_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            if (comboBoxPatient == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!");
            }
            else if (textBoxDiagnose == null)
            {
                MessageBox.Show("Vui lòng nhập chẩn đoán!");
            }
            else if (comboBoxDoctor == null)
            {
                MessageBox.Show("Vui lòng chọn Bác sĩ!");
            }
            else if (comboBoxMajor == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa!");
            }

            string hsba = null;
            string patient = null;
            string doctor = null;
            string major = null;
            string csyt = null;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "INSERT INTO SOYTEX.HSBA VALUES(':id_hsba', ':id_patient', TO_DATE(NOW(),'dd/mm/yyyy'), ':diagnose', ':id_doctor', ':id_major', ':id_csyt', ':result');";
            cmd.Parameters.Add(":id_hsba", hsba);
            cmd.Parameters.Add(":id_patient", patient);
            cmd.Parameters.Add(":diagnose", textBoxDiagnose.Text);
            cmd.Parameters.Add(":id_doctor", doctor);
            cmd.Parameters.Add(":id_major", major);
            cmd.Parameters.Add(":id_csyt", csyt);
            cmd.Parameters.Add(":result", textBoxDiagnose.Text);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonViewHSBADV_Click(object sender, EventArgs e)
        {
            //get clicked cell value
            int selectedrowindex = listMedicalRecord.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = listMedicalRecord.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["MAHSBA"].Value);

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT * FROM SOYTEX.HSBA WHERE MAHSBA = :id_hsba";
            cmd.Parameters.Add(":id_hsba", cellValue.ToUpper());
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable checkList = new DataTable();
            checkList.Load(dr);

            if (checkList.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Hồ sơ bệnh án!");
            }
            else
            {
                //grant privs
                try
                {
                    if (cellValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn Hồ sơ bệnh án!");
                    }
                    else
                    {
                        OracleCommand getListServiceMedicalRecord = new OracleCommand();
                        getListServiceMedicalRecord.CommandText = "SELECT * FROM SOYTEX.HSBA_DV WHERE MAHSBA = = :id_hsba";
                        cmd.Parameters.Add(":id_hsba", cellValue.ToUpper());
                        getListServiceMedicalRecord.Connection = con;
                        getListServiceMedicalRecord.CommandType = CommandType.Text;
                        OracleDataReader listServiceRecord = getListServiceMedicalRecord.ExecuteReader();
                        DataTable tableListMedicalRecord = new DataTable();
                        tableListMedicalRecord.Load(listServiceRecord);
                        listMedicalRecord.DataSource = tableListMedicalRecord;
                        MessageBox.Show("");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();
        }

        private void buttonViewHSBA_Click(object sender, EventArgs e)
        {
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
    }
}
