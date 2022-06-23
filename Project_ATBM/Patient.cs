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
    public partial class Patient : Form
    {
        string user_name = "";
        string pass = "";
        public Patient(string username, string name, string password)
        {
            InitializeComponent();
            Header.Text = Header.Text + " " + name;
            user_name = username;
            pass = password;
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void labelAllergy_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpdateProfile_Click(object sender, EventArgs e)
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

            OracleCommand cmdInfo = new OracleCommand();
            cmdInfo.CommandText = $"SELECT MaBN, MaCSYT, TenBN, CMND, NgaySinh, SoNha, TenDuong, QuanHuyen, TinhTP, TienSuBenh, TienSuBenhGD, DiUngThuoc FROM SOYTEX.BenhNhan WHERE MaBN = '%{user_name}%'";
            cmdInfo.CommandType = CommandType.Text;
            cmdInfo.Connection = con;
            
            OracleDataReader patientInfo = cmdInfo.ExecuteReader();
            textBoxMaBN.Text = patientInfo.GetValue(0).ToString();
            textBoxMaCSYT.Text = patientInfo.GetValue(1).ToString();
            textBoxName.Text = patientInfo.GetValue(2).ToString();
            textBoxID.Text = patientInfo.GetValue(3).ToString();
            textBoxDOB.Text = patientInfo.GetValue(4).ToString();
            textBoxNum.Text = patientInfo.GetValue(5).ToString();
            textBoxStreet.Text = patientInfo.GetValue(6).ToString();
            textBoxDistrict.Text = patientInfo.GetValue(7).ToString();
            textBoxCity.Text = patientInfo.GetValue(8).ToString();
            textBoxMedicalHistory.Text = patientInfo.GetValue(9).ToString();
            textBoxFamilyMedicalHistory.Text = patientInfo.GetValue(10).ToString();
            textBoxAllergy.Text = patientInfo.GetValue(11).ToString();

            string v_mabn = textBoxMaBN.Text;
            string v_name = textBoxName.Text;
            string v_id = textBoxID.Text;
            string v_dob = textBoxDOB.Text;
            string v_num = textBoxNum.Text;
            string v_street = textBoxStreet.Text;
            string v_district = textBoxDistrict.Text;
            string v_city = textBoxCity.Text;
            string v_medicalHistory = textBoxMedicalHistory.Text;
            string v_familyMedicalHistory = textBoxFamilyMedicalHistory.Text;
            string v_allergyt = textBoxAllergy.Text;

            OracleCommand command = new OracleCommand();
            command.Connection = con;
            command.CommandText = $"UPDATE SOYTEX.BenhNhan SET TenBN = '%{v_name}%', CMND = '%{v_id}%', NgaySinh = '%{v_dob}%', SoNha = '%{v_num}%', TenDuong = '%{v_street}%', QuanHuyen = '%{v_district}%', TinhTP = '%{v_city}%', TienSuBenh = '%{v_medicalHistory}%', TienSuBenhGD = '%{v_familyMedicalHistory}%', DiUngThuoc = '%{v_allergyt}%' WHERE MaBN = '%{v_mabn}%'";
            command.CommandType = CommandType.Text;
            int rows_affected = (int)command.ExecuteNonQuery();

            if (rows_affected == 1)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            con.Close();
        }
    }
}
