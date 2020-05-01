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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<Учебная_группа> lstG = new List<Учебная_группа>();
        int rowAdd;
        int sort_order=-1;
        bool first_sort = true;
        int current_column=50;
        private void Form1_Load(object sender, EventArgs e)
        {
            //добавление в список 
            rowAdd = dataGridView1.RowCount;
            List<Студент> lst = new List<Студент>();
            lst.Add(new Студент("Иванов", 2000, 60, "+7 (927) 159-25-89"));
            lst.Add(new Студент("Иванова", 2000, 50, "+7 (965) 023-77-51"));
            lst.Add(new Студент("Иванбек", 2001, 87, "+7 (941) 103-88-41"));
            lst.Add(new Студент("Иванка", 2000, 30, "+7 (927) 163-23-79"));
            lst.Add(new Студент("Иванидзе", 2000, 99, "+7 (927) 193-12-51"));
            lst.Add(new Студент("Иванчик", 2001, 1, "+7 (979) 128-91-12"));
            lst.Add(new Студент("Ивуля", 2000, 50, "+7 (922) 121-88-11"));
            lst.Add(new Студент("Ивлев", 2000, 61, "+7 (911) 122-05-91"));
            lst.Add(new Студент("Ивашка", 2001, 79, "+7 (999) 678-10-44"));
            lst.Add(new Студент("Иванов", 2000, 37, "+7 (912) 342-44-36"));


            lstG.Add(new Учебная_группа("ПИ18-3", 2018, "Факультет АРиЭБ", lst[2].Имя, "PI18-3@edu.fa.ru", lst));

            lst = new List<Студент>();
            lst.Add(new Студент("Красоткина", 2000, 70, "+7 (923) 701-49-36"));
            lst.Add(new Студент("Красотина", 2000, 89, "+7 (97) 5 43-35-78"));
            lst.Add(new Студент("Красулина", 2001, 97, "+7 (969) 123-05-77"));
            lst.Add(new Студент("Краска", 2000, 78, "+7 (911) 729-98-05"));
            lst.Add(new Студент("Красотуля", 2000, 59, "+7 (935) 916-23-78"));
            lst.Add(new Студент("Краснюк", 2001, 50, "+7 (970) 429-11-78"));


            lstG.Add(new Учебная_группа("ПИ18-4", 2018, "Юридический факультет", lst[3].Имя, "PI18-4@edu.fa.ru", lst));

            lst = new List<Студент>();
            lst.Add(new Студент("Николашкин", 2000, 70, "+7 (923) 701-49-36"));
            lst.Add(new Студент("Никиткин", 2000, 89, "+7 (97) 5 43-35-78"));
            lst.Add(new Студент("Никин", 2001, 97, "+7 (969) 123-05-77"));
            lst.Add(new Студент("Ник", 2000, 78, "+7 (911) 729-98-05"));
            lst.Add(new Студент("Николидзе", 2000, 59, "+7 (935) 916-23-78"));
            lst.Add(new Студент("Николятор", 2001, 50, "+7 (970) 429-11-78"));

            lstG.Add(new Учебная_группа("ПИ19-5", 2019, "Факультет менеджмента", lst[5].Имя, "PI19-5@edu.fa.ru", lst));

            учебнаягруппаBindingSource.DataSource = lstG;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //открытие формы со списком студентов
            if (dataGridView1.CurrentRow == null)
                return;
            int n = dataGridView1.CurrentRow.Index;
            Form2 formS = new Form2();
            //передаем форме список студентов выбранной группы
            formS.lst=lstG[n].Студенты;
            
            
            formS.ShowDialog();
            учебнаягруппаBindingSource.ResetCurrentItem();
            Filter();
              
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //открытие формы с добавлением групп
            AddGroupForm formS = new AddGroupForm();
            formS.form1 = this;
            formS.ShowDialog();
            Filter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //открытие формы с изменением группы
            if (dataGridView1.CurrentRow == null)
                return;
            int n = dataGridView1.CurrentRow.Index;
            EditGroupForm formS = new EditGroupForm();
            //передаем форме список студентов выбранной группы
            formS.lst = lstG[n].Студенты;
            
            formS.form1 = this;
            formS.ShowDialog();
            учебнаягруппаBindingSource.ResetCurrentItem();
            Filter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
                return;
            //если выбрано несколько групп
            if (dataGridView1.SelectedRows.Count>1)
            {
                if (MessageBox.Show(
                    "Вы действительно хотите удалить несколько групп?", "Внимание",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //добавляем в listDel выбранные строки и удаляем эти строки из lstG
                    List<Учебная_группа> listDel = new List<Учебная_группа>();
                    foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                        listDel.Add(lstG[item.Index]);
                    foreach (Учебная_группа item in listDel)
                        lstG.Remove(item);
                    учебнаягруппаBindingSource.ResetBindings(false);
                    Filter();
                    return;
                }
                else
                    return;
            }
            //удаление одной строки
            string grname = (string)dataGridView1.CurrentRow.Cells["название"].Value;
            if (MessageBox.Show(
                    "Вы действительно хотите удалить группу " + grname + " ?", "Внимание",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            lstG.RemoveAt(dataGridView1.CurrentRow.Index);
            учебнаягруппаBindingSource.ResetBindings(false);
            Filter();
        }

        private void button5_Click(object sender, EventArgs e)
        {//закрытие
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {//фильтрация
            Filter();
        }
        public void Filter()
        {//фильтрация
            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Rows.Count - rowAdd; i++)
            {
                if (TestRow(i))
                    //если строка проходит по критериям, показываем её
                    dataGridView1.Rows[i].Visible = true;
                else
                    //иначе скрываем её
                    dataGridView1.Rows[i].Visible = false;
            }
        }
        private bool TestRow(int i)
        {
            //критерии
            if (textBox1.Text != "" && lstG[i].Название.ToUpper().StartsWith(textBox1.Text.ToUpper())==false) return false;

            if (textBox2.Text != "" && lstG[i].Год.ToString().ToUpper().StartsWith(textBox2.Text.ToUpper()) == false) return false;

            if (textBox3.Text != "" && lstG[i].Староста.ToUpper().StartsWith(textBox3.Text.ToUpper()) == false) return false;

            if (textBox4.Text != "" && lstG[i].Почта.ToUpper().StartsWith(textBox4.Text.ToUpper()) == false) return false;

            if (comboBox2.Text != "" && lstG[i].Факультет.ToUpper().StartsWith(comboBox2.Text.ToUpper()) == false) return false;

            return true;
        }

        private void button7_Click(object sender, EventArgs e)
        {//очищаем текстбоксы
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {//показываем все строки в таблице
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Visible = true;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {//сортировка
            if (dataGridView1.Rows.Count > rowAdd)
            {
                //если нажали на столбец не в первый раз подряд, нужно стереть добавление стрелочки в прошлый раз
                if (current_column == e.ColumnIndex)
                    dataGridView1.Columns[e.ColumnIndex].HeaderText = dataGridView1.Columns[e.ColumnIndex].HeaderText.Substring(0, dataGridView1.Columns[e.ColumnIndex].HeaderText.Length-1);
                //если нажали на другой столбец или нажали в первый раз
                if (current_column != e.ColumnIndex)
                {
                    sort_order = -1;
                    //если нажали на другой столбец, надо стереть изменения в предыдущем столбце
                    if (!first_sort)
                        dataGridView1.Columns[current_column].HeaderText = dataGridView1.Columns[current_column].HeaderText.Substring(0, dataGridView1.Columns[current_column].HeaderText.Length - 1);
                    //если нажали в первый раз, стирать ничего не надо
                    else
                        first_sort = false;
                    //запоминаем колонку
                    current_column = e.ColumnIndex;
                }


                sort_order = -1 * sort_order;
                //sort_order = -1 - по убыванию
                //sort_order = 1 - по возрастанию

                //добавляем стрелку
                if (sort_order == 1)
                    dataGridView1.Columns[e.ColumnIndex].HeaderText = dataGridView1.Columns[e.ColumnIndex].HeaderText + "↓";
                if (sort_order == -1)
                    dataGridView1.Columns[e.ColumnIndex].HeaderText = dataGridView1.Columns[e.ColumnIndex].HeaderText + "↑";
                //сортировка
                switch (dataGridView1.Columns[e.ColumnIndex].Name)
                {//сортируем таблицу в зависимости от того, какое имя у выбранного столбца
                    case "название":
                        lstG.Sort(delegate (Учебная_группа a1, Учебная_группа a2)
                        {
                            return sort_order * a1.Название.CompareTo(a2.Название);
                        });
                            break;
                    case "год":
                        lstG.Sort(delegate (Учебная_группа a1, Учебная_группа a2)
                        {
                            return sort_order * a1.Год.CompareTo(a2.Год);
                        });
                        break;
                    case "факультет":
                        lstG.Sort(delegate (Учебная_группа a1, Учебная_группа a2)
                        {
                            return sort_order * a1.Факультет.CompareTo(a2.Факультет);
                        });
                        break;
                    case "староста":
                        lstG.Sort(delegate (Учебная_группа a1, Учебная_группа a2)
                        {
                            return sort_order * a1.Староста.CompareTo(a2.Староста);
                        });
                        break;
                    case "почта":
                        lstG.Sort(delegate (Учебная_группа a1, Учебная_группа a2)
                        {
                            return sort_order * a1.Почта.CompareTo(a2.Почта);
                        });
                        break;
                    default:
                        return;

                }
                учебнаягруппаBindingSource.ResetBindings(false);
                Filter();

            }
        }

        private void учебнаягруппаBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

       
    }
    public class Учебная_группа
    {

        public int Год { get; set; }
        public string Староста { get; set; }
        public string Почта { get; set; }
        public string Название { get; set; }
        public string Факультет { get; set; }
        public int ID { get; set; }

        static int id_now = 1;
        public List<Студент> Студенты { get; set; }
        public void Список_группы()
        {
            Console.WriteLine("Список группы " + Название + ":");
            foreach (Студент s in Студенты)
                Console.WriteLine(s);
        }
        public Учебная_группа(string название, int год, string факультет, string староста, string почта, List<Студент> студенты)
        {

            Год = год;
            Староста = староста;
            Факультет = факультет;
            Почта = почта;
            Название = название;
            Студенты = студенты;
            ID = id_now;
            id_now = id_now + 1;

        }
        public Учебная_группа(string название, int год, string факультет, string староста, string почта)
        {

            Год = год;
            Староста = староста;
            Факультет = факультет;
            Почта = почта;
            Название = название;
            List<Студент> lst = new List<Студент>();
            Студенты = lst;
            ID = id_now;
            id_now = id_now + 1;

        }
        public override string ToString()
        {
            return string.Format("Группа {3}, год набора {0}, " +
                "староста {1}, почта {2}", Год, Староста, Почта, Название);
        }

        public int Количество_студентов()
        {
            int Количество = Студенты.Count();
            return Количество;


        }
        public double Средний_рейтинг()
        {
            double rate = 0;
            foreach (Студент st in Студенты)
                rate = rate + st.Рейтинг;
            return rate / Студенты.Count();

        }

    }
    //----------------------------------------------------------------------------------------------------------------------
    public class Студент
    {

        public int Год { get; set; }
        public int Рейтинг { get; set; }
        public string Телефон { get; set; }
        public string Имя { get; set; }
        public int ID { get; set; }

        static int id_now = 1;

        public Студент(string имя, int год, int рейтинг, string телефон)
        {

            Год = год;
            Рейтинг = рейтинг;
            Телефон = телефон;
            Имя = имя;
            ID = id_now;
            id_now = id_now + 1;
        }

        public override string ToString()
        {
            return string.Format("Студент {3}, год рождения {0}, " +
                "рейтинг {1}, телефон {2}", Год, Рейтинг, Телефон, Имя);



        }

    }
}

