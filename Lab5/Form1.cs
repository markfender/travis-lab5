using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        Form2 Form2 = new Form2();

        public Form1()
        {
            Location = new Point(0, 0);
            InitializeComponent();
           
            Form2.Hide();
            Form2.Show();

        }


        /// <summary>
        /// Информация об авторе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form2.Form3.Hide();
            Form2.Form3.ShowDialog();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
          
        }

        /// <summary>
        /// Валидация данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) && 1 < int.Parse(e.KeyChar.ToString()) && int.Parse(e.KeyChar.ToString()) <= numericUpDown1.Value)
            {
                Form2.Nulleble = false;
                dataGridView1.Rows.Add(e.KeyChar.ToString());
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Form2.percent = new float[10];

            try
            {
                for (int i = 0; ; i++)
                {
                    int value = int.Parse((string)dataGridView1[0, i].Value);
                    Form2.percent[value]++;
                }
            }
            catch (ArgumentNullException)
            {

            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
         

        }
        /// <summary>
        /// Сортировка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);        
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form2.Circle = radioButton1.Checked;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
