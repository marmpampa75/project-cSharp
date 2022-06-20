﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAD2022_2
{
    public partial class FormLogIn : Form
    {
        public static String data;
        public ClassStudent student;

        private String connectionString = "Data source=.\\rad2022_4.db;Version=3";
        SQLiteConnection conn;
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void profileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            data = "unknown";
            this.Hide();
            FormUserProfile fp = new FormUserProfile(data);
            fp.Show();
        }

        private void homePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data = "unknown";
            this.Hide();
            FormMainPage f3 = new FormMainPage(data);
            f3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            conn.Open();
            String email = textBox1.Text;
            String password = textBox2.Text;
            String selectSQL = "Select * from User where " +
            "email=@email and password=@password";

            SQLiteCommand cmd = new SQLiteCommand(selectSQL, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ClassStudent student = new ClassStudent(22, password, email, "name");

                //student.name = name.ToString();
                //student.email(email);
                MessageBox.Show("Welcome, " + student.name);
                conn.Close();
                this.Hide();
                if (email != "" || email != null)
                {

                    data = student.name;
                }
                else
                {
                    data = student.id;
                }

                FormMainPage f3 = new FormMainPage(student.name);
                f3.Show();
            }
            else
            {
                conn.Close();
                Application.Exit();
            }
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormLogIn f3 = new FormLogIn();
            f3.Show();
        }
    }
}
