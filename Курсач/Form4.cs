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
        public EditGroupForm EditGroupForm;
        public Form2 Form2;
        bool add = false;
        bool egf = false;
        bool agf = false;
        bool f2 = false;
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//записывам студента в список из родительской формы
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
            if (agf)
            {//если форма была открыта из AddGroupForm
                AddGroupForm.lst.Add(new Студент(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox5.Text), textBox4.Text));
                add = true;
                AddGroupForm.студентBindingSource.ResetBindings(false);
            }
            if (egf)
            {//если форма была открыта из EditGroupForm
            EditGroupForm.lst.Add(new Студент(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox5.Text), textBox4.Text));
            add = true;
            EditGroupForm.студентBindingSource.ResetBindings(false); }
            if (f2)
            {//если форма была открыта из Form2
                Form2.lst.Add(new Студент(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox5.Text), textBox4.Text));
                add = true;
                Form2.студентBindingSource.ResetBindings(false);
                Form2.Filter();
            }
            
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {//узнаем, из какой формы была открыта эта форма
            foreach (Form f in Application.OpenForms)
            {//проверяем активированы ли Form2,AddGroupForm и EditGroupForm
                if (f.Name == "AddGroupForm")
                    agf = true;
                if (f.Name == "EditGroupForm")
                    egf = true;
                if (f.Name == "Form2")
                    f2 = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//очищаем поля
            if (MessageBox.Show(
                         "Вы действительно хотите очистить все поля?", "Внимание",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBox5.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {//закрытие
            if (add)
            {
                //обновляем отображение значений в bindingSource родительской формы
                if (agf)
                    AddGroupForm.студентBindingSource.ResetBindings(false);
                if (egf)
                    EditGroupForm.студентBindingSource.ResetBindings(false);
                if (f2)
                {
                    Form2.студентBindingSource.ResetBindings(false);
                    Form2.Filter();
                        }

            }
            Close();
        }

       
    }
}
