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
    public partial class FormUserProfile : System.Windows.Forms.Form
    {
        public static String data;
        public FormUserProfile(String k)
        {
            InitializeComponent();
            data = k;
            usernameToolStripMenuItem.Text = "Welcome, " + k;
            richTextBox1.LoadFile("textfiles\\programma.txt", RichTextBoxStreamType.PlainText);

        }
        public FormUserProfile()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"images\maxresdefault.jpg";
            button2.Text = "Click img -> mute";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("IExplore", "http://www.google.com");
            System.Diagnostics.Process.Start("IExplore", "http://www.youtube.com/watch?v=Dqhy54VV4LY&ab_channel=alexkord1");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("textfiles\\mathimata.txt",RichTextBoxStreamType.PlainText);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath+"\\textfiles";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("BSB.wav");
            player.Play();
            button7.Text = "Click img Button";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

            FormSignUp f2 = new FormSignUp();
            f2.Show();
        }

    }
}
