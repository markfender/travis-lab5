using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing;

namespace Lab5
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// Процентное соотношение
        /// </summary>
        public float[] percent = new float[10];
        /// <summary>
        /// Разрешение экрана
        /// </summary>
        Rectangle screenSize = Screen.PrimaryScreen.Bounds;
        /// <summary>
        /// Цвета
        /// </summary>
        public Color[] Color = new Color[10];
        /// <summary>
        /// Пуст ли список
        /// </summary>
        public bool Nulleble = true;
        /// <summary>
        /// Выбор операции
        /// </summary>
        internal bool Circle = false;


        /// <summary>
        /// Форма с информацией об авторе
        /// </summary>
        internal Form3 Form3 = new Form3();

        public Form2()
        {
          
            InitializeComponent();
           

            Color = new Color[] { System.Drawing.Color.FromArgb(255, 200, 0), System.Drawing.Color.FromArgb(255, 175, 175), System.Drawing.Color.FromArgb(0, 255, 255), System.Drawing.Color.FromArgb(255, 0, 255), System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.FromArgb(0, 0, 0), System.Drawing.Color.FromArgb(128, 128, 128), System.Drawing.Color.FromArgb(255, 0, 0), System.Drawing.Color.FromArgb(0, 255, 0), System.Drawing.Color.FromArgb(0, 0, 255) };
         
        }

        /// <summary>
        /// Вызов формы с информацией об авторе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form3.Hide();
            Form3.ShowDialog();
          
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        /// <summary>
        /// Обработчик событий для отрисовки диаграмм и гистограмм
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            if (Nulleble)
                return;
            Graphics value = CreateGraphics();
            value.Clear(DefaultBackColor);
            Random Random= new Random();
            if (Circle)
            {
                float Sum = 0;
                Rectangle Rectangle = new Rectangle(Width / 4, 0, Width / 2, Width / 2);
                percent = Methods.K_Circle(percent);
                for (int i = 2; i <= 9; i++)
                {
                    Brush color = new SolidBrush(Color[i]);
                    value.FillPie(color, Rectangle, Sum, percent[i]);
                    Sum += percent[i];
                }
            }
            else
            {
                PointF[][] value2 = Methods.Bar_chart(percent, screenSize.Width,screenSize.Height*0.94f);

                for(int i = 0;i<10;i++)
                {
                    RectangleF Rec = new RectangleF(value2[i][0],new SizeF(value2[i][1].X, value2[i][1].Y));
                    Brush color = new SolidBrush(Color[i]);

                    value.FillRectangle(color, Rec);
                }
            }
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            Form2_Paint(null,null);
        }
    }

    public static class Methods
    {
        /// <summary>
        /// Метод расчёта коефициентов для круга
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="array"></param>
        public static float[] K_Circle(float[] array)
        {
            float[] rezult = P(array);
            
            for(int i = 0;i<array.Length;i++)
            {
                rezult[i] *= 360;
            }
            return rezult;
        }

        /// <summary>
        /// Метод для вычисления процентного соотношения коефициентов
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static float[] P(float[] array)
        {
            float[] percent = new float[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                float Sum = 0;

                Array.ForEach(array, j => Sum += j);
                try
                {
                    percent[i] = array[i] / Sum;
                }
                catch (DivideByZeroException)
                {

                }
            }
            return percent;
        }

        /// <summary>
        /// Метод для вычисления процентного соотношения между коефициентами
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static float[] K(float[] array)
        {
            float Max = float.MinValue;
            Array.ForEach(array, j =>
            {
                if (j > Max)
                    Max = j;
            });

            if (Max == float.MinValue)
                return null;

            float[] rezult = new float[array.Length];

            for(int i = 0;i < array.Length;i++)
            {
                rezult[i] = array[i] / Max;
            }

            return rezult;
        }

        /// <summary>
        /// Метод расчёта координат и размера гистограмм
        /// </summary>
        public static PointF[][] Bar_chart(float[] array, float Width, float Height)
        {
            PointF[][] rezult = new PointF[array.Length][];
            for(int i = 0;i < array.Length;i++)
            {
                rezult[i] = new PointF[2];
            }
                     
            float A = Height / 25, B = Height / 25 * 2;
            float []percent = P(array);
            percent = K(percent);  

            for(int i = 2; i < rezult.Length;i++)
            {
                rezult[i][0] = new PointF(Width*0.01f, A + (A + B) * (i-2));
                rezult[i][1] = new PointF(Width*percent[i] * 0.98f, B);
            }
            return rezult;
        }

    }

}
