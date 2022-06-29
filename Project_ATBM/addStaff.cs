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
    public partial class addStaff : Form
    {
        public addStaff()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            ); User Id = DB_ADMIN;password=1234";
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            OracleCommand command = new OracleCommand();
            command.Connection = con;
            string str = cb.SelectedItem.ToString();
            try
            {
                con.Open();
                command.CommandText = "soytex.proc_insert_nhanvien ";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(":p_id", textbox_nvID.Text);
                command.Parameters.Add(":p_name", textbox_nvName.Text);
                command.Parameters.Add(":p_gender", textbox_nvGender.Text);
                command.Parameters.Add(":p_date", textbox_nvDate.Text);
                command.Parameters.Add(":p_cmnd", textbox_nvCMND.Text);
                command.Parameters.Add(":p_address", textbox_nvAddress.Text);
                command.Parameters.Add(":p_phonenum", textbox_nvPhoneNum.Text);
                command.Parameters.Add(":p_csyt", textbox_nvCSYT.Text);
                command.Parameters.Add(":p_khoaID", textbox_nvMaKhoa.Text);
                if (str == "Thanh tra") 
                {
                    command.Parameters.Add(":p_role", "Thanh tra");
                }
                else if (str == "Cơ sở y tế")
                {
                    command.Parameters.Add(":p_role", "Co so y te");
                }
                else if (str == "Y sĩ/ bác sĩ")
                {
                    command.Parameters.Add(":p_role", "Y si/ Bac si");

                }
                else
                {
                    command.Parameters.Add(":p_role", "Nghien cuu");

                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
