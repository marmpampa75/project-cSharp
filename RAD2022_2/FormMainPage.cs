using System;
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
        public static ClassStudent data;
        public FormMainPage(ClassStudent student)
        {
            InitializeComponent();
            data = student;
            usernameToolStripMenuItem.Text = "Welcome, "+ student.name;
            pictureBox2.ImageLocation = @"images\logo_piraeus.png";
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
            System.Diagnostics.Process.Start("IExplore", "http://www.youtube.com/watch?v=Xbc84gLheDc");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog2.Color;
            }
        }
    }
}
