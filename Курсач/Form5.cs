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
    public partial class EditGroupForm : Form

    {
        public Form1 form1;
        int i;
        public int n;
        bool add = false;
        public List<Студент> lst = new List<Студент>();
        public EditGroupForm()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            i = form1.dataGridView1.CurrentRow.Index;
            textBox1.Text = (Form1.lstG[i].Год).ToString();
            textBox2.Text = (Form1.lstG[i].Староста);
            textBox4.Text = (Form1.lstG[i].Почта);
            textBox5.Text = (Form1.lstG[i].Название);
            comboBox1.Text = (Form1.lstG[i].Факультет);
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

            if (!int.TryParse(textBox1.Text, out год))
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
            Form1.lstG[i].Год=год;
            Form1.lstG[i].Староста=textBox2.Text ;
            Form1.lstG[i].Почта=textBox4.Text;
            Form1.lstG[i].Название=textBox5.Text;
            Form1.lstG[i].Факультет=comboBox1.Text;
            form1.учебнаягруппаBindingSource.ResetItem(i);
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            n = dataGridView1.CurrentRow.Index;
            EditStudentForm formS = new EditStudentForm();

            formS.EditGroupForm = this;
            formS.ShowDialog();
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
            Close();
        }
    }
}
