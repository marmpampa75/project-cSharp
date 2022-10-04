using System;
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
    public partial class FormSignUp : System.Windows.Forms.Form
    {
        public static ClassStudent data;
        public ClassStudent student;

        private String connectionString = "Data source=.\\rad2022_4.db;Version=3";
        SQLiteConnection conn;
        public FormSignUp()
        {
            InitializeComponent();
        }

                    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // The password character is an asterisk.
            textBox2.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            textBox2.MaxLength = 14;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            Console.WriteLine("This is C#");

            conn.Open();
            string name = textBox1.Text;
            string email = textBox3.Text;
            string password = textBox2.Text;
            string date = dateTimePicker1.Text;
            string am = textBox6.Text;
            string insertSQL = "Insert into User(name,email,password,student_id,age) " +
            "values(@name,@email,@password,@am,@date)";
            SQLiteCommand cmd = new SQLiteCommand(insertSQL, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@am", am);
            cmd.Parameters.AddWithValue("@date", date);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
                MessageBox.Show(count.ToString() + " row affected"+ date);
            conn.Close();


            ClassStudent student = new ClassStudent(date, name, email, am, 1);
            this.Hide();
            FormMainPage f3 = new FormMainPage(student);
            f3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);

        }

        private void homePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassStudent student = new ClassStudent("unknown", "unknown", "unknown", "unknown", 0);
            this.Hide();
            FormMainPage f3 = new FormMainPage(student);
            f3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usernameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormLogIn fl = new FormLogIn();
            fl.Show();
        }

        private void profileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClassStudent student = new ClassStudent("unknown", "unknown", "unknown", "unknown", 0);
            this.Hide();
            FormUserProfile fp = new FormUserProfile(student);
            fp.Show();

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }
    }
}
