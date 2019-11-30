using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()

        {
            InitializeComponent();
            //label1.Text = Resource1.LastName;
            //label2.Text = Resource1.FirstName;
            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.Felirat;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                //LastName = textBox1.Text,
                // FirstName = textBox2.Text
                FullName = textBox1.Text
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Comma Seperated Values (*.csv)|*.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {

                sw.Write("ID:");
                sw.Write(";");
                sw.Write("Fullname:");
                sw.WriteLine();

                foreach (User u in listBox1.Items) sw.WriteLine(string.Format("{0};{1}", u.ID, u.FullName));

            }

            MessageBox.Show("A fájlba írás megtörtént");

            Application.Exit();
        }
    }
 }

