using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
        public static String myLessons = "";
        public static ClassStudent data;
        public static ClassLessons lessons;
        private String connectionString = "Data source=.\\rad2022_4.db;Version=3";
        SQLiteConnection conn;

        public FormUserProfile(ClassStudent student)
        {
            InitializeComponent();
            data = student;
            usernameToolStripMenuItem.Text = "Welcome, " + data.name;
            richTextBox1.LoadFile("textfiles\\programma.txt", RichTextBoxStreamType.PlainText);
            myLessons = "";
            if (!(data.name == "unknown"))
            {
                conn = new SQLiteConnection(connectionString);
                conn.Open();
                String name = data.name;
                int index = Convert.ToInt32(data.index);
                String selectLessonsSQL = "Select subject from Lessons where " +
                "student_name=@name and student_idx=@index";

                SQLiteCommand cmd = new SQLiteCommand(selectLessonsSQL, conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("@index", index);
                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Object[] values = new Object[reader.FieldCount];
                    int fieldCount = reader.GetValues(values);
                    //fieldCount = reader.GetValues(values);  
                    values = new Object[1];
                    Console.Out.WriteLine(values);
                    //reader.GetValues(values);
                    List<string> list = (from IDataRecord r in reader
                                         select (string)r["subject"]
                    ).ToList();
                    ClassLessons Mylessons = new ClassLessons(list);
                    lessons = Mylessons;
                    //MessageBox.Show("Welcome, " + list[0]);
                    foreach (var v in lessons.lessons)
                    {
                        myLessons += v + "\n";
                    }

                    richTextBox2.Text = myLessons;
                    
                    //reader.Close();
                    conn.Close();
                    //this.Hide();
                    //if (name != "" || name != null)
                    //{

                    //    lessons = lessons;
                    //}
                    //else
                    //{
                    //    lessons = lessons;
                    //}
                    //
                }
            }
            else
            {
                List<string> list = new List<string>();
                ClassLessons mylessons = new ClassLessons(list);
                lessons = mylessons;
                foreach (var v in lessons.lessons)
                {
                    myLessons += v + "\n";
                }

                richTextBox2.Text = myLessons;
                }
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



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (data.name == "unknown")
            {
                MessageBox.Show("No permissions!");
                this.Hide();
                FormSignUp fs = new FormSignUp();
                fs.Show();
            } else
            {

            conn = new SQLiteConnection(connectionString);
            conn.Open();
            string subject = textBox2.Text.ToString();
            string student_name = data.name.ToString();
            int student_index = data.index;
            string insertLessonsSQL = "Insert into Lessons(subject,student_name,student_idx) " +
            "values(@subject,@student_name,@student_index)";
            SQLiteCommand cmd = new SQLiteCommand(insertLessonsSQL, conn);
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@student_name", student_name);
            cmd.Parameters.AddWithValue("@student_index", student_index);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
                MessageBox.Show(count.ToString() + " row affected" + subject);
            conn.Close();
                this.Hide();
                FormUserProfile fp = new FormUserProfile(data);
                fp.Show();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            conn.Open();
            string subject = textBox2.Text.ToString();
            string student_name = data.name.ToString();
            int student_index = data.index;
            string insertLessonsSQL = "Insert into Lessons(subject,student_name,student_idx) " +
            "values(@subject,@student_name,@student_index)";
            SQLiteCommand cmd = new SQLiteCommand(insertLessonsSQL, conn);
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@student_name", student_name);
            cmd.Parameters.AddWithValue("@student_index", student_index);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            if (count > 0)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Error no lessons added");
            }
        }

        private void FormUserProfile_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
             
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
