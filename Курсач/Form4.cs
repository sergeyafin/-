using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class AddStudentForm : Form
    {
        public AddGroupForm AddGroupForm;
        bool add = false;
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            AddGroupForm.lst.Add(new Студент(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox5.Text), textBox4.Text));
            
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Close();
        }
    }
}
