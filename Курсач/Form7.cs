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
    public partial class Stats : Form
    {
        public List<double> Y;
        public Stats()
        {
            InitializeComponent();
        }
        private double dispersia(List<double> Y)
        {
            double sum_kvadrat = 0;
            foreach (double i in Y)
                sum_kvadrat=sum_kvadrat+i*i;
            return ((sum_kvadrat / Y.Count()) - (Y.Average() * Y.Average()));
        }
       

        private void Form7_Load(object sender, EventArgs e)
        {
            sred.Text = Y.Average().ToString();
            disp.Text = dispersia(Y).ToString();
            max.Text = Y.Max().ToString();
            min.Text = Y.Min().ToString();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var points = new List<PointF>();
            for (var i=0;i<Y.Count();i++)
                points.Add(new PointF(i*10, (float)Y[i]));//задаем точки,i*10 - расстояние между точкам по оси X =10
            var blackPen = new Pen(Color.Black, 3);//цвет и толщина в пикселях
            e.Graphics.TranslateTransform(pictureBox1.Location.X, pictureBox1.Height);//перемещаем график в центр
            e.Graphics.ScaleTransform(1, -1);//переворачиваем график
            e.Graphics.ScaleTransform(4,2);//увеличиваем размер
            //линия масштабируется вместе с остальным графиком,
            //поэтому настраиваем её отдельно
            //клонируем
            var penTransform = e.Graphics.Transform.Clone();
            //обращаем матрицу penTransform
            penTransform.Invert();
            // фиксируем матрицу перехода у пера, 
            // как обратную к матрице перехода e.Graphics 
            penTransform.Scale(1, (float)1.5);
            blackPen.Transform = penTransform;

            //серое перо для сетки
            var grayPen = new Pen(Color.LightGray, 1);
            grayPen.Transform = penTransform;//матрица перехода как у черного пера

            for (var x = 0; x <= 100; x=x+10) // рисуем сетку 10x10
            {
                var pen = x == 0 ? blackPen : grayPen; // чтобы центральные оси рисовались черным пером
                e.Graphics.DrawLine(pen, x, 0, x, 100);
                e.Graphics.DrawLine(pen, 0, x, 100, x);
            }

            e.Graphics.DrawLines(blackPen, points.ToArray());
        }

        private void Stats_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();//при изменении размера делает недействительной всю поверхность
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
