﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAD2022_2
{
    public partial class FormMainPage : Form
    {
        public static String data;
        public FormMainPage(String k)
        {
            InitializeComponent();
            data = k;
            usernameToolStripMenuItem.Text = "Welcome, "+k;
            pictureBox2.ImageLocation = @"images\download.jpg";
        }
        public FormMainPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


   

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", "http://www.youtube.com/watch?v=Dqhy54VV4LY&ab_channel=alexkord1");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
            FormSignUp f2 = new FormSignUp();
            f2.Show();
        }

        private void usernameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMainPage f3 = new FormMainPage(data);
            f3.Show();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
                    }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();

            FormSignUp f2 = new FormSignUp();
            f2.Show();
        }

        private void profileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUserProfile fp = new FormUserProfile(data);
            fp.Show();
        }
    }
}
