using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;


namespace system10
{
    public partial class Form1 : Form
    {
        private Bitmap captured;
        public Form1()
        {

            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {


            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int colourDepth = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat format;
            switch (colourDepth)
            {
                case 8:
                case 16:
                    format = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    format = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    format = PixelFormat.Format32bppArgb;
                    break;

                default:
                    format = PixelFormat.Format32bppArgb;
                    break;
            }
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            this.pictureBox1.BackgroundImage = captured;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (captured != null)
            {
                saveFileDialog1.Filter = "Jpeg image|*.jpg|All files|*.*";
                saveFileDialog1.Title = "Save captured screen as jpeg";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    captured.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (captured != null)
            {
                saveFileDialog1.Filter = "PNG image|*.png|All files|*.*";
                saveFileDialog1.Title = "Save captured screen as png";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    captured.Save(saveFileDialog1.FileName, ImageFormat.Png);
                }
            }
        }
    }
}
