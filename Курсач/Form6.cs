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
        public AddGroupForm AddGroupForm;
        public Form2 Form2;
        bool f2 = false;
        bool egf = false;
        bool agf = false;
        public EditStudentForm()
        {
            InitializeComponent();
        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            //узнаем, из какой формы была открыта эта форма
            foreach (Form f in Application.OpenForms)
            {//проверяем активированы ли Form2,AddGroupForm и EditGroupForm
                if (f.Name == "Form2")
                    f2 = true;
                if (f.Name == "EditGroupForm")
                    egf = true;
                if (f.Name == "AddGroupForm")
                    agf = true;
            }
            //заполнение полей данными из родительской формы
            if (f2)
            {
                textBox1.Text = Form2.lst[Form2.n].Имя;
                textBox2.Text = Form2.lst[Form2.n].Год.ToString();
                textBox5.Text = Form2.lst[Form2.n].Рейтинг.ToString();
                textBox4.Text = Form2.lst[Form2.n].Телефон;
            }
            if (egf)
            {
                textBox1.Text = EditGroupForm.lst[EditGroupForm.n].Имя;
                textBox2.Text = EditGroupForm.lst[EditGroupForm.n].Год.ToString();
                textBox5.Text = EditGroupForm.lst[EditGroupForm.n].Рейтинг.ToString();
                textBox4.Text = EditGroupForm.lst[EditGroupForm.n].Телефон;
            }
            if (agf)
            {
                textBox1.Text = AddGroupForm.lst[AddGroupForm.n].Имя;
                textBox2.Text = AddGroupForm.lst[AddGroupForm.n].Год.ToString();
                textBox5.Text = AddGroupForm.lst[AddGroupForm.n].Рейтинг.ToString();
                textBox4.Text = AddGroupForm.lst[AddGroupForm.n].Телефон;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//изменение студента в списке из родительской формы
            int год;
            int рейтинг;
            //проверяем правильность заполнения полей
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
            if (egf)
            {
                EditGroupForm.lst[EditGroupForm.n].Имя = textBox1.Text;
                EditGroupForm.lst[EditGroupForm.n].Год = год;
                EditGroupForm.lst[EditGroupForm.n].Рейтинг = рейтинг;
                EditGroupForm.lst[EditGroupForm.n].Телефон = textBox4.Text;
                EditGroupForm.студентBindingSource.ResetBindings(false);
                Close();
            }
            if (f2)
            {
                Form2.lst[Form2.n].Имя = textBox1.Text;
                Form2.lst[Form2.n].Год = год;
                Form2.lst[Form2.n].Рейтинг = рейтинг;
                Form2.lst[Form2.n].Телефон = textBox4.Text;
                Form2.студентBindingSource.ResetBindings(false);
                Form2.Filter();
                Close();
            }
            if (agf)
            {
                AddGroupForm.lst[AddGroupForm.n].Имя = textBox1.Text;
                AddGroupForm.lst[AddGroupForm.n].Год = год;
                AddGroupForm.lst[AddGroupForm.n].Рейтинг = рейтинг;
                AddGroupForm.lst[AddGroupForm.n].Телефон = textBox4.Text;
                AddGroupForm.студентBindingSource.ResetBindings(false);
                Close();
            }

         }


        private void button2_Click(object sender, EventArgs e)
        {//очищаем поля
            if (MessageBox.Show(
                   "Вы действительно хотите очистить все поля?", "Внимание",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//закрытие формы
            Close();
        }

       
    }
}
