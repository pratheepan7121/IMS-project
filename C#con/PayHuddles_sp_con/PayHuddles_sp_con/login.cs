﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PayHuddles_sp_con
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
         SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-VJT4USD0\SQLEXPRESS;Initial Catalog=PayHuddles_SP_DB;User ID=sa;Password=Pratheek123");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;

            try
            {
                string querry = "select * from login_new where username = '" + txt_username.Text + "' and password = '" + txt_password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password = txt_password.Text;

                    //page that needed to be load next
                    info form = new info();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_username.Clear();

                    //to focus username
                    txt_username.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                 conn.Close();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();

            txt_username.Focus();
        }
    }
}
