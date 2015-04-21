using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace howto_steganography_hide_image2
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
    }
}
