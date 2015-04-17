using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;


namespace watermark_invisible_level4project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Hide and then recover the image.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int num_bits = (int)nudHiddenBits.Value;

            // Hide the image.
            picCombined.Image = Stego.HideImage(
                (Bitmap)picVisible.Image,
                (Bitmap)picHidden.Image, num_bits);

            // Recover the hidden image.
            picRecovered.Image = Stego.RecoverImage(
                (Bitmap)picCombined.Image, num_bits);
            Cursor = Cursors.Default;
        }

        //open original image
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg1 = new OpenFileDialog();

            dlg1.Title = "Open Image";
            dlg1.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";

            if (dlg1.ShowDialog() == DialogResult.OK)
            {
                picVisible.Image = Image.FromFile(dlg1.FileName);

            }

            dlg1.Dispose();
        }

        //open invisible watermark image
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg2 = new OpenFileDialog();

            dlg2.Title = "Open Image";
            dlg2.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";

            if (dlg2.ShowDialog() == DialogResult.OK)
            {
                picHidden.Image = Image.FromFile(dlg2.FileName);

            }

            dlg2.Dispose();
        }

        //exit application
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Level-4-Project-Invisible Watermarking  @Challenges@ ");
        }
    }
}
