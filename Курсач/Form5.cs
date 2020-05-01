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
        public List<Студент> lst = new List<Студент>();
        public EditGroupForm()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //записываем в поля атрибуты группы
            i = form1.dataGridView1.CurrentRow.Index;
            textBox1.Text = (Form1.lstG[i].Год).ToString();
            textBox2.Text = (Form1.lstG[i].Староста);
            textBox4.Text = (Form1.lstG[i].Почта);
            textBox5.Text = (Form1.lstG[i].Название);
            comboBox1.Text = (Form1.lstG[i].Факультет);
            студентBindingSource.DataSource = lst;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //изменяем группу
            int год;
            //проверяем правильность заполнения полей
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
            form1.Filter();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {//запуск формы с изменением студента
            if (dataGridView1.CurrentRow == null)
                return;
            n = dataGridView1.CurrentRow.Index;
            EditStudentForm formS = new EditStudentForm();

            formS.EditGroupForm = this;
            formS.ShowDialog();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {//закрытие формы
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {//удаление
            if (dataGridView1.CurrentCell == null)
                return;
            if (dataGridView1.SelectedRows.Count > 1)
            {//если выбрано несколько групп
                if (MessageBox.Show(
                    "Вы действительно хотите удалить несколько студентов?", "Внимание",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {//добавляем в listDel выбранные строки и удаляем эти строки из lstG
                    List<Студент> listDel = new List<Студент>();
                    foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                        listDel.Add(lst[item.Index]);
                    foreach (Студент item in listDel)
                        lst.Remove(item);
                    студентBindingSource.ResetBindings(false);
                    return;
                }
                else
                    return;
            }
            //удаление одной строки
            string stname = (string)dataGridView1.CurrentRow.Cells["имяDataGridViewTextBoxColumn"].Value;
            if (MessageBox.Show(
                    "Вы действительно хотите удалить студента " + stname + " ?", "Внимание",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            lst.RemoveAt(dataGridView1.CurrentRow.Index);
            студентBindingSource.ResetBindings(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {//открытие формы добавления студента
            AddStudentForm formS = new AddStudentForm();

            formS.EditGroupForm = this;
            formS.ShowDialog();
        }

    }
}
