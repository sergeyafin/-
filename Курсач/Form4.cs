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
            int год;
            int рейтинг;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Не задано имя");
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Не задан телефон");
                textBox4.Focus();
                return;
            }
            if (!int.TryParse(textBox2.Text, out год))
            {
                MessageBox.Show("Год должен быть задан числом");
                textBox2.Focus();
                return;
            }
            if (!int.TryParse(textBox5.Text, out рейтинг))
            {
                MessageBox.Show("Рейтинг должен быть задан числом");
                textBox5.Focus();
                return;
            }
            AddGroupForm.lst.Add(new Студент(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox5.Text), textBox4.Text));
            add = true;
            AddGroupForm.студентBindingSource.ResetBindings(false);
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
            if (add)
            {
                AddGroupForm.студентBindingSource.ResetBindings(false);
                
            }
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
