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
    public partial class Task2 : Form
    {
        Bitmap[] BmpArr;

        public Task2()
        {
            InitializeComponent();
            Bitmap bmp = pictureBox1.Image as Bitmap;
            BmpArr = GetRgbChannels(bmp);
            HystogramRGB(bmp);
        }

        static Bitmap[] GetRgbChannels(Bitmap source)
        {
            Bitmap[] result = new Bitmap[3] { new Bitmap(source.Width, source.Height), new Bitmap(source.Width, source.Height), new Bitmap(source.Width, source.Height) };
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    result[0].SetPixel(i, j, Color.FromArgb(color.A, color.R, 0, 0));
                    result[1].SetPixel(i, j, Color.FromArgb(color.A, 0, color.G, 0));
                    result[2].SetPixel(i, j, Color.FromArgb(color.A, 0, 0, color.B));
                }
            }
            return result;
        }

        private void HystogramRGB(Bitmap bmp)
        {
            chart1.Series.Clear();
            chart1.Name = "RGB Channels";

            chart1.Series.Add("RED");
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series.Add("GREEN");
            chart1.Series[1].Color = Color.Green;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series.Add("BLUE");
            chart1.Series[2].Color = Color.Blue;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            Dictionary<int, int> countR = new Dictionary<int, int>();
            Dictionary<int, int> countG = new Dictionary<int, int>();
            Dictionary<int, int> countB = new Dictionary<int, int>();
            for (int i = 0; i < 256; i++)
            {
                countR[i] = 0;
                countG[i] = 0;
                countB[i] = 0;
            }
            for (int x = 1; x < bmp.Width; x++)
            {
                for (int y = 1; y < bmp.Height; y++)
                {
                    Color color = bmp.GetPixel(x, y);
                    countR[color.R] += 1;
                    countG[color.G] += 1;
                    countB[color.B] += 1;
                }
            }
            for (int i = 1; i < 256; i++)
            {
                chart1.Series["RED"].Points.AddXY(i, countR[i]);
                chart1.Series["GREEN"].Points.AddXY(i, countG[i]);
                chart1.Series["BLUE"].Points.AddXY(i, countB[i]);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = BmpArr[0];
            HystogramRGB(BmpArr[0]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = BmpArr[1];
            HystogramRGB(BmpArr[1]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = BmpArr[2];
            HystogramRGB(BmpArr[2]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.JPEG; *.JPG; *.PNG)|*.JPEG;*.JPG;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    Clear();
                    BmpArr = GetRgbChannels(pictureBox1.Image as Bitmap);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Clear()
        {
            HystogramRGB(pictureBox1.Image as Bitmap);
            try
            {
                pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                pictureBox4.Image = new Bitmap(pictureBox4.Width, pictureBox4.Height);
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Task2_Load(object sender, EventArgs e)
        {

        }
    }
}
