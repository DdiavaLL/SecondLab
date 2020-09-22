using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondLab{
    public partial class Task1 : Form{
        private Bitmap bmp;
        public Task1(){
            InitializeComponent();
        }

        //Gray PAL & NTSC
        private int gray1(Color color){
            return (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
        }

        //Gray HDTV
        private int gray2(Color color){
            return (int)(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B);
        }

        //Count minimum of gray 
        private int gray3(Bitmap bmp){
            int res = 0;
            //Getting the minimal difference
            for (int x = 0; x < bmp.Width; x++){
                for (int y = 0; y < bmp.Height; y++){
                    int g1 = gray1(bmp.GetPixel(x, y));
                    int g2 = gray2(bmp.GetPixel(x, y));
                    if (g1 - g2 < res){
                        res = g1 - g2;
                    }
                }
            }
            return res;
        }

        //Setting color for each pixel
        private void setPixelColor(Bitmap bmp, int x, int y, int graySub = 0, int number = 0){
            Color color = bmp.GetPixel(x, y);
            int a = color.A;
            int r = color.R;
            int g = color.G;
            int b = color.B;

            if (number == 0){
                //Gray PAL & NTSC
                int g1 = gray1(color);
                bmp.SetPixel(x, y, Color.FromArgb(a, g1, g1, g1));
            }
            else if (number == 1){
                //Gray HDTV

                int g2 = gray2(color);
                bmp.SetPixel(x, y, Color.FromArgb(a, g2, g2, g2));
            }
            else if (number == 2){
                //Gray substracted
                int gr1 = gray1(color);
                int gr2 = gray2(color);
                bmp.SetPixel(x, y, Color.FromArgb(a, gr1 - gr2 - graySub, gr1 - gr2 - graySub, gr1 - gr2 - graySub));
            }

        }



        private void Task1_Load(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e){
            string imageLocation = "";
            try{
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                    chart1.Images.Clear();
                    chart2.Images.Clear();
                    imageLocation = dialog.FileName;
                    if (pictureBox1.Image != null){
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    if (pictureBox2.Image != null){
                        pictureBox2.Image.Dispose();
                        pictureBox2.Image = null;
                    }
                    if (pictureBox3.Image != null){
                        pictureBox3.Image.Dispose();
                        pictureBox3.Image = null;
                    }
                    if (pictureBox4.Image != null){
                        pictureBox4.Image.Dispose();
                        pictureBox4.Image = null;
                    }
                    pictureBox1.ImageLocation = imageLocation;
                    pictureBox2.ImageLocation = imageLocation;
                    pictureBox3.ImageLocation = imageLocation;
                    pictureBox4.ImageLocation = imageLocation;
                    bmp = new Bitmap(pictureBox1.ImageLocation);
                }
            }
            catch (Exception){
                MessageBox.Show("An Error Occured", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createGrayPALAndNTS(){
            Bitmap newBmp = new Bitmap(pictureBox1.ImageLocation);
            int gr = gray3(newBmp);

            for (int x = 0; x < newBmp.Width; x++){
                for (int y = 0; y < newBmp.Height; y++){
                    setPixelColor(newBmp, x, y, gr);
                }
            }
            pictureBox2.Image = newBmp;
            doHystogramGRAY1(newBmp);
        }
        private void createGrayHDTV() {
            Bitmap newBmp = new Bitmap(pictureBox1.ImageLocation);
            int gr = gray3(newBmp);

            for (int x = 0; x < newBmp.Width; x++){
                for (int y = 0; y < newBmp.Height; y++){
                    setPixelColor(newBmp, x, y, gr, 1);
                }
            }
            pictureBox3.Image = newBmp;
            doHystogramGRAY2(newBmp);
        }

        private void createGraySub(){
            Bitmap newBmp = new Bitmap(pictureBox1.ImageLocation);
            int gr = gray3(newBmp);

            for (int x = 0; x < newBmp.Width; x++){
                for (int y = 0; y < newBmp.Height; y++){
                    setPixelColor(newBmp, x, y, gr, 2);
                }
            }
            pictureBox4.Image = newBmp;
        }

        private void doHystogramGRAY1(Bitmap bmp){

            chart1.Series.Clear();
            chart1.Name = "Gray Channels";

            chart1.Series.Add("Gray PAL and NTSC");
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            //chart1.Series.Add("Gray HDTV");
            //chart1.Series[1].Color = Color.Blue;
            //chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            Dictionary<int, int> countG1 = new Dictionary<int, int>();
            //Dictionary<int, int> countG2 = new Dictionary<int, int>();
            for (int i = 0; i < 256; i++){
                countG1[i] = 0;
                //countG2[i] = 0;
            }
            for (int x = 1; x < bmp.Width; x++){
                for (int y = 1; y < bmp.Height; y++){
                    Color color = bmp.GetPixel(x, y);
                    countG1[gray1(color)] += 1;
                    //countG2[gray2(color)] += 1;
                }
            }
            for (int i = 1; i < 256; i++){
                chart1.Series["Gray PAL and NTSC"].Points.AddXY(i, countG1[i]);
                //chart1.Series["Gray HDTV"].Points.AddXY(i, countG2[i]);
            }
        }

        private void doHystogramGRAY2(Bitmap bmp){
            chart2.Series.Clear();
            chart2.Name = "Gray Channels";

            //chart2.Series.Add("Gray PAL and NTSC");
            //chart2.Series[0].Color = Color.Red;
            //chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series.Add("Gray HDTV");
            chart2.Series[0].Color = Color.Blue;
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            //Dictionary<int, int> countG1 = new Dictionary<int, int>();
            Dictionary<int, int> countG2 = new Dictionary<int, int>();
            for (int i = 0; i < 256; i++){
                //countG1[i] = 0;
                countG2[i] = 0;
            }
            for (int x = 1; x < bmp.Width; x++){
                for (int y = 1; y < bmp.Height; y++){
                    Color color = bmp.GetPixel(x, y);
                    //countG1[gray1(color)] += 1;
                    countG2[gray2(color)] += 1;
                }
            }
            for (int i = 1; i < 256; i++){
                //chart2.Series["Gray PAL and NTSC"].Points.AddXY(i, countG1[i]);
                chart2.Series["Gray HDTV"].Points.AddXY(i, countG2[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e){
            createGrayPALAndNTS();
            createGrayHDTV();
            createGraySub();
        }
    }
}
