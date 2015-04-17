using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Imagecomparision1
{
    public partial class Form1 : Form
    {
        Image file;
        public Form1()
        {
            InitializeComponent();
        }
        static string fname1, fname2;
        Bitmap img1, img2;
        int count1 = 0, count2 = 0;
        bool flag = true;
        private void Form1_Load(object sender, EventArgs e)
        {
           ProgressBar1.Visible = false;
            //pictureBox1.Visible = false;
        }


        private void openFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = ""; // allow to select files- setting openfile dialog to default
            openFileDialog1.Title = "Images"; //title of the dialog
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png"; //filter use to open the valid file
            openFileDialog1.ShowDialog();
            file = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = file;
            if (openFileDialog1.FileName.ToString() != "")
            {
                fname1 = openFileDialog1.FileName.ToString();
            }

        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)

{
    openFileDialog2.FileName = "";
    openFileDialog2.Title = "Images";
    openFileDialog2.Filter = "All Images|*.jpg; *.bmp; *.png";
    openFileDialog2.ShowDialog();

    file = Image.FromFile(openFileDialog2.FileName);
    pictureBox2.Image = file;
    if (openFileDialog2.FileName.ToString() != "")
    {
        fname2 = openFileDialog2.FileName.ToString();
    }
}



private void button1_Click(object sender, EventArgs e)
{
    ProgressBar1.Visible = true;
    string img1_ref, img2_ref;
    img1 = new Bitmap(fname1);
    img2 = new Bitmap(fname2);
    ProgressBar1.Maximum = img1.Width;
    if (img1.Width == img2.Width && img1.Height == img2.Height)
    {
        for (int i = 0; i < img1.Width; i++)
        {
            for (int j = 0; j < img1.Height; j++)
            {
                img1_ref = img1.GetPixel(i, j).ToString();


                img2_ref = img2.GetPixel(i, j).ToString();
                if (img1_ref != img2_ref)
                {
                    count2++;
                    flag = false;
                    break;
                }
                count1++;
            }
            ProgressBar1.Value++;
        }
        if (flag == false)
            MessageBox.Show("Sorry, Images are not same , " + count2 + " wrong pixels found");
        else
            MessageBox.Show(" Images are same , " + count1 + " same pixels found and " + count2 + " wrong pixels found");
    }
    else
        MessageBox.Show("Different Images!can not compare this images");
    this.Dispose();
}

private void exitToolStripMenuItem_Click(object sender, EventArgs e)
{
    this.Close();
}








    }
    }

