using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
namespace CG_Lab3
{
    //Вариант-5
    public partial class Form1 : Form
    {
        Graphics g;
        string filename = @"Strings.txt";
        string[] sm = { "First line", "Second line", "Third line", "Fourth line", "Fifth line", "Sixth line", "Seventh line", "Eighth line", "Ninth line", "Tenth line", "Eleven line" };

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        // Запись в файл
        private void InFile_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename,
            FileMode.Create, FileAccess.Write));

            foreach (string s in sm) { f.WriteLine(s); }
            f.Close();
            MessageBox.Show("Строки записаны в файл.");
        }
        // Очистка файла и PictureBox 
        private void ClearFile_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
            File.Delete(filename);
            MessageBox.Show("Удален Файл Strings.txt");
        }

        //Отображение строк текста
        private void ShowT_Click(object sender, EventArgs e)
        {
            int k = 0;
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename,
                FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 11; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            pictureBox1.BackColor = Color.FromArgb(31, 217, 112);
            pictureBox1.Refresh();

            for (int i = 0; i < 10; i++)
            {
                if ((i >= 0) && (i < 6))
                {
                    k = i - 9;
                    Font fn = new Font("Arial", 36, FontStyle.Underline);
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(sm[i], fn, Brushes.DarkCyan,
                    new RectangleF(0 + k * 45, 10, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 100), sf);
                    fn.Dispose();
                }
                if ((i >= 6) && (i < 9))
                {
                    Font fn = new Font("Broadway", 24, FontStyle.Regular);
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Yellow,
                    new RectangleF(0, -130 + i * 50, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 90), sf);
                    fn.Dispose();
                }
                if (i == 9)
                {
                    Font fn = new Font("Times New Roman", 48, FontStyle.Strikeout); // 1 дюйм = 96; 96/2 = 48
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    g.DrawString(sm[i], fn, Brushes.Black,
                    new RectangleF(0, 0 + i * 1, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 2), sf);
                    fn.Dispose();
                }
            }
        }
    }
}