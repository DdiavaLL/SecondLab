using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondLab
{
    public partial class Task3 : Form
    {
        Graphics g;

        public Task3()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        bool MyEqual(double a, double b)
        {
            return Math.Abs(a - b) < 0.0001;
        }

        // Преобразование RGB -> HSV
        double[] ConvertRGBtHSV(double R, double G, double B)
        {
            // MAX - максимальное значение из RGB, MIN - минимальное
            double MAX = Math.Max(Math.Max(R, G), B);
            double MIN = Math.Min(Math.Min(R, G), B);
            double H, S, V;

            // Вычисление Hue
            if (MyEqual(MAX, MIN))
            {
                H = 0;
            }
            else if (MyEqual(MAX, R) && G >= B)
            {
                H = 60 * ((G - B) / (MAX - MIN));
            }
            else if (MyEqual(MAX, R) && G < B)
            {
                H = 60 * ((G - B) / (MAX - MIN)) + 360;
            }
            else if (MyEqual(MAX, G))
            {
                H = 60 * ((B - R) / (MAX - MIN)) + 120;
            }
            else
            {
                H = 60 * ((R - G) / (MAX - MIN)) + 240;
            }

            // Вычисление Saturation
            if (MyEqual(MAX, 0))
            {
                S = 0;
            }
            else
            {
                S = 1 - (MIN / MAX);
            }

            //Вычисление Value
            V = MAX;

            double[] rez = new double[3] { H, S, V };
            return rez;
        }

        // Преобразование HSV -> RGB
        double[] ConvertHSVtRGB(double H, double S, double V)
        {
            var Hi = Math.Floor(H / 60.0) % 6;
            double f = (H / 60.0) - Math.Floor(H / 60.0);
            double p = V * (1 - S);
            double q = V * (1 - f * S);
            double t = V * (1 - (1 - f) * S);

            switch(Hi)
            {
                case 0:
                    return new double[3] { V, t, p };
                case 1: 
                    return new double[3] { q, V, p };
                case 2:
                    return new double[3] { p, V, t };
                case 3:
                    return new double[3] { p, q, V };
                case 4:
                    return new double[3] { t, p, V };
                case 5:
                    return new double[3] { V, p, q };
                default:
                    return new double[3] { 0, 0, 0 };
            }
        }

        //Конвертируем изображение
        void Draw()
        {
            double tH = h_trackBar.Value;
            double tS = s_trackBar.Value / 100.0;
            double tV = v_trackBar.Value / 100.0;
            Bitmap new_bitmap = (Bitmap)pictureBox1.Image.Clone();

            for (int i = 0; i < new_bitmap.Width; ++i)
            {
                for (int i1 = 0; i1 < new_bitmap.Height; ++i1)
                {
                    var next_pixel = new_bitmap.GetPixel(i, i1);
                    var pixel_change = ConvertRGBtHSV(next_pixel.R / 255.0, next_pixel.G / 255.0, next_pixel.B / 255.0);

                    pixel_change[0] += tH;
                    if (pixel_change[0] < 0)
                    {
                        pixel_change[0] += 360;
                    } else if (pixel_change[0] > 360)
                    {
                        pixel_change[0] -= 360;
                    }

                    pixel_change[1] += tS;
                    if (pixel_change[1] > 1)
                    {
                        pixel_change[1] = 1;
                    }
                    else if (pixel_change[1] < 0)
                    {
                        pixel_change[1] = 0;
                    }

                    pixel_change[2] += tV;
                    if (pixel_change[2] > 1)
                    {
                        pixel_change[2] = 1;
                    }
                    else if (pixel_change[2] < 0)
                    {
                        pixel_change[2] = 0;
                    }

                    var pixel_rezult = ConvertHSVtRGB(pixel_change[0], pixel_change[1], pixel_change[2]);
                    new_bitmap.SetPixel(i, i1, Color.FromArgb((int)(pixel_rezult[0] * 255), (int)(pixel_rezult[1] * 255), (int)(pixel_rezult[2] * 255)));
                }
                pictureBox1.Image = new_bitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.JPEG; *.JPG; *.PNG)|*.JPEG;*.JPG;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true;     //предложение о перезаписывании существующего файла
                sfd.CheckPathExists = true;     //предупреждение о несуществующем пути для сохранения
                sfd.Filter = "Image Files(*.JPEG)|*.JPEG|Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG";
                sfd.ShowHelp = true;            //отображение кнопки справки

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
