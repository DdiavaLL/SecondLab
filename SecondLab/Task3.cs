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
    }
}
