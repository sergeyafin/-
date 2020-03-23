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
    public partial class AddGroupForm : Form
    {
        public List<Студент> lst = new List<Студент>();

        public Form1 form1;
        bool add = false;

        public AddGroupForm()
        {
            InitializeComponent();
        }

        private void AddGroupForm_Load(object sender, EventArgs e)
        {
            студентBindingSource.DataSource = lst;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int год; 
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Не введено название группы");
                textBox5.Focus();
                return;
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Не выбран факультет");
                comboBox1.Focus();
                return;
            }

            if (!int.TryParse(textBox1.Text,out год))
            {
                MessageBox.Show("Год должен быть задан числом");
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Не задан староста");
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Не задана почта группы");
                textBox4.Focus();
                return;
            }
            Form1.lstG.Add(new Учебная_группа(textBox5.Text, год, comboBox1.Text, textBox2.Text, textBox4.Text,lst));
            add = true;
            MessageBox.Show("Группа добавлена");
            form1.учебнаягруппаBindingSource.ResetBindings(false);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
             if (add)
            {
                form1.учебнаягруппаBindingSource.ResetBindings(false);
            }
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddStudentForm formS = new AddStudentForm();
            
            formS.AddGroupForm = this;
            formS.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
