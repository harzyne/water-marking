using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace watermark_invisible_level4project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //saving watermarked image to disk
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sDlg = new SaveFileDialog(); // Save Dialog Initialization
            sDlg.RestoreDirectory = true;
            sDlg.Title = "Save Image";
            //sDlg.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";

            if (sDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var img = new Bitmap(pictureBox1.Image);
                    img.Save(@"C:\Users\Harzyne\Pictures\randoms\embedded.jpg", ImageFormat.Jpeg);
                    //pictureBox1.Image.Save(@"C:\Users\Harzyne\Pictures\randoms",ImageFormat.Jpeg);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Exception catch here - details  : " + ex.ToString());
                }
                finally
                {
                    //MessageBox.Show("Enter finally block ");
                }
                 
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
