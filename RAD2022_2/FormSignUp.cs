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
        public static String data;
        public ClassStudent student;

        private String connectionString = "Data source=.\\rad2022_4.db;Version=3";
        SQLiteConnection conn;
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            conn.Open();
            String name = textBox3.Text;
            String email = textBox1.Text;
            String password = textBox2.Text;
            String selectSQL = "Select * from User where " +
            "email=@email and password=@password";

            SQLiteCommand cmd = new SQLiteCommand(selectSQL, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                ClassStudent student = new ClassStudent(22,password,email,name);

                //student.name = name.ToString();
                //student.email(email);
                MessageBox.Show("Welcome, "+student.name);
                conn.Close();
                this.Hide();
                if (name != "" || name != null)
                {

                    data = student.name;
                } else
                {
                    data = student.id;
                }

                FormMainPage f3 = new FormMainPage(student.name);
                f3.Show();
            } else {
                conn.Close();
                Application.Exit();
            }
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
            String name = textBox1.Text;
            String email = textBox3.Text;
            String password = textBox2.Text;
            String insertSQL = "Insert into User(name,email,password) " +
            "values(@name,@email,@password)";
            SQLiteCommand cmd = new SQLiteCommand(insertSQL, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
                MessageBox.Show(count.ToString() + " row affected");
            conn.Close();
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
            data = "unknown";
            this.Hide();
            FormMainPage f3 = new FormMainPage(data);
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
            data = "unknown";
            this.Hide();
            FormUserProfile fp = new FormUserProfile(data);
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
    }
}
