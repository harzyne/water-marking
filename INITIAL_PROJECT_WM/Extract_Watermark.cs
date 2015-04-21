using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace watermark_invisible_level4project
{
    public partial class Extract_Watermark : Form
    {
        public Extract_Watermark()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg3 = new OpenFileDialog();

            dlg3.Title = "Open Image";
            dlg3.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";

            if (dlg3.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dlg3.FileName);
            }

            dlg3.Dispose();
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Extracted_Watermark frm4 = new Extracted_Watermark();
            frm4.Show();

            // Recover the hidden image.
            int num_bits = 2;
           frm4.pictureBox1.Image = Watermark_Invisible.RecoverImage(
                (Bitmap)pictureBox1.Image, num_bits);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
