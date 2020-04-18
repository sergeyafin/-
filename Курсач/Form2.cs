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
    public partial class Form2 : Form
    {
        public Form1 form1;
        public List<Студент> lst = new List<Студент>();
        int rowAdd;
        int rating;
        public int n;
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rowAdd = dataGridView1.RowCount;
            студентBindingSource.DataSource = lst;
            radioButton3.Checked = Properties.Settings.Default.rb1;
            radioButton2.Checked = Properties.Settings.Default.rb2;
            radioButton1.Checked = Properties.Settings.Default.rb3;
            textBox4.Text = Properties.Settings.Default.tb4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            n = dataGridView1.CurrentRow.Index;
            EditStudentForm formS = new EditStudentForm();

            formS.Form2 = this;
            formS.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddStudentForm formS = new AddStudentForm();

            formS.Form2 = this;
            formS.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
                return;
            if (dataGridView1.SelectedRows.Count > 1)
            {
                if (MessageBox.Show(
                    "Вы действительно хотите удалить несколько студентов?", "Внимание",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
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
            string stname = (string)dataGridView1.CurrentRow.Cells["имяDataGridViewTextBoxColumn"].Value;
            if (MessageBox.Show(
                    "Вы действительно хотите удалить студента " + stname + " ?", "Внимание",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            lst.RemoveAt(dataGridView1.CurrentRow.Index);
            студентBindingSource.ResetBindings(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
            if (textBox4.Text!="")
            if (!int.TryParse(textBox4.Text,out rating))
            {
                MessageBox.Show("Рейтинг должен быть задан числом");
                textBox4.Focus();
                return;
            }

            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Rows.Count - rowAdd; i++)
            {
                if (TestRow(i))
                    dataGridView1.Rows[i].Visible = true;
                else
                    dataGridView1.Rows[i].Visible = false;
            }
        }
        private bool TestRow(int i)
        {
            if (textBox1.Text != "" && lst[i].Имя.ToUpper().StartsWith(textBox1.Text.ToUpper()) == false) return false;

            if (textBox2.Text != "" && lst[i].Год.ToString().ToUpper().StartsWith(textBox2.Text.ToUpper()) == false) return false;

            if (radioButton3.Checked && textBox4.Text != "" && lst[i].Рейтинг < int.Parse(textBox4.Text)) return false;

            if (radioButton2.Checked && textBox4.Text != "" && lst[i].Рейтинг > int.Parse(textBox4.Text)) return false;

            if (radioButton1.Checked && textBox4.Text != "" && lst[i].Рейтинг != int.Parse(textBox4.Text)) return false;

            if (textBox3.Text != "" && lst[i].Телефон.ToUpper().StartsWith(textBox3.Text.ToUpper()) == false) return false;

            return true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Visible = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.tb4 = textBox4.Text;
            Properties.Settings.Default.rb1 = radioButton3.Checked;
            Properties.Settings.Default.rb2 = radioButton2.Checked;
            Properties.Settings.Default.rb3 = radioButton1.Checked;
        }
    }
}
