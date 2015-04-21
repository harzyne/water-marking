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
            btnGo.Enabled = false;
        }

        // Hide and then recover the image.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int num_bits = (int)nudHiddenBits.Value;

            // Hide the image.
            
            picCombined.Image = Watermark_Invisible.HideImage(
                (Bitmap)picVisible.Image,
                (Bitmap)picHidden.Image, num_bits);
          
            
            // Recover the hidden image.
            picRecovered.Image = Watermark_Invisible.RecoverImage(
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
            btnGo.Enabled = true;

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
            btnGo.Enabled = true;

        }
        
        //save watermarked image to local dir

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                frm2.pictureBox1.Image = (Bitmap)picCombined.Image.Clone();
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

        //show app details
        private void applicationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Level-4-Project-Invisible Watermarking  @Challenges@ ");
        }

        //open new form to extract watermark
        private void extractingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Extract_Watermark frm3 = new Extract_Watermark();
            frm3.Show();
        }

        //exit application
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        

       
    }
}
