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
    public partial class EditStudentForm : Form
    {
        public EditGroupForm EditGroupForm;
        bool add = false;
        public EditStudentForm()
        {
            InitializeComponent();
        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = EditGroupForm.lst[EditGroupForm.n].Имя;
            textBox2.Text = EditGroupForm.lst[EditGroupForm.n].Год.ToString();
            textBox5.Text = EditGroupForm.lst[EditGroupForm.n].Рейтинг.ToString();
            textBox4.Text = EditGroupForm.lst[EditGroupForm.n].Телефон;
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
            
            EditGroupForm.lst[EditGroupForm.n].Имя = textBox1.Text;
            EditGroupForm.lst[EditGroupForm.n].Год = год;
            EditGroupForm.lst[EditGroupForm.n].Рейтинг = рейтинг;
            EditGroupForm.lst[EditGroupForm.n].Телефон= textBox4.Text;
            add = true;
            EditGroupForm.студентBindingSource.ResetBindings(false);

        }
    }
}
