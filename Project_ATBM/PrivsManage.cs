﻿using System;
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
    public partial class PrivsManage : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );User Id = DB_ADMIN;password=1234";
        public PrivsManage(string username)
        {
            InitializeComponent();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "select * from dba_tab_privs where grantee = :user_name";
                cmd_drop_user.CommandType = CommandType.Text;
                cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2)).Value = username;
                OracleDataReader user = cmd_drop_user.ExecuteReader();
                DataTable tableUserList = new DataTable();

                tableUserList.Load(user);

                dataGridView1.DataSource = tableUserList;
                label1.Text = username;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
   
            string user_name = Convert.ToString(selectedRow.Cells["GRANTEE"].Value);
            string table = Convert.ToString(selectedRow.Cells["TABLE_NAME"].Value);
            string priv = Convert.ToString(selectedRow.Cells["PRIVILEGE"].Value);

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            try
            {
              
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "SYS.proc_revoke_privilege";
                cmd_drop_user.CommandType = CommandType.StoredProcedure;
                cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = user_name;
                cmd_drop_user.Parameters.Add(new OracleParameter("p_table", OracleDbType.Varchar2, ParameterDirection.Input)).Value = table;
                cmd_drop_user.Parameters.Add(new OracleParameter("privilege", OracleDbType.Varchar2, ParameterDirection.Input)).Value = priv;

                cmd_drop_user.ExecuteNonQuery();
                MessageBox.Show("Đã thu hồi quyền!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = label1.Text.Trim().ToUpper();

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            GrantPrivelegetoUser form = new GrantPrivelegetoUser(user_name);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string user_name = label1.Text.Trim().ToUpper();

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            GrantRoletoUser form = new GrantRoletoUser(user_name);
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrivsManage_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string username = label1.Text.Trim().ToUpper();
            OracleCommand cmd_drop_user = new OracleCommand();
            cmd_drop_user.Connection = con;
            cmd_drop_user.CommandText = " select * from DBA_ROLE_PRIVS  where grantee = :user_name";
            cmd_drop_user.CommandType = CommandType.Text;
            cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2)).Value = username;
            OracleDataReader user = cmd_drop_user.ExecuteReader();
            DataTable tableUserList = new DataTable();

            tableUserList.Load(user);

            dataGridView1.DataSource = tableUserList;
            label1.Text = username;

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string username = label1.Text.Trim().ToUpper();
            OracleCommand cmd_drop_user = new OracleCommand();
            cmd_drop_user.Connection = con;
            cmd_drop_user.CommandText = "select * from dba_tab_privs where grantee = :user_name";
            cmd_drop_user.CommandType = CommandType.Text;
            cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2)).Value = username;
            OracleDataReader user = cmd_drop_user.ExecuteReader();
            DataTable tableUserList = new DataTable();

            tableUserList.Load(user);

            dataGridView1.DataSource = tableUserList;
            label1.Text = username;

            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string role_name = Convert.ToString(selectedRow.Cells["GRANTED_ROLE"].Value);
            string user_name = Convert.ToString(selectedRow.Cells["GRANTEE"].Value);
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            try
            {
                
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.CommandType = CommandType.Text;
                cmd_drop_user.CommandText = "REVOKE :role_name FROM :user";
                cmd_drop_user.Parameters.Add(":role_name", role_name);
                cmd_drop_user.Parameters.Add(":user", user_name);
                cmd_drop_user.Connection = con;
                cmd_drop_user.ExecuteNonQuery();

                MessageBox.Show("Đã thu hồi quyền!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
