using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neural1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        List<Bitmap> lb;

        private void button1_Click(object sender, EventArgs e)
        {
            lb = new List<Bitmap>();
            i11.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49001.png", true);
            i12.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49002.png", true);
            i13.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49003.png", true);
            i14.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49004.png", true);
            i15.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49005.png", true);

            i21.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49006.png", true);
            i22.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49007.png", true);
            i23.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49008.png", true);
            i24.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49009.png", true);
            i25.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49010.png", true);

            i31.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49011.png", true);
            i32.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49012.png", true);
            i33.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49013.png", true);
            i34.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49014.png", true);
            i35.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49015.png", true);

            i41.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49016.png", true);
            i42.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49017.png", true);
            i43.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49018.png", true);
            i44.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49019.png", true);
            i45.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49020.png", true);

            i51.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49021.png", true);
            i52.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49022.png", true);
            i53.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49023.png", true);
            i54.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49024.png", true);
            i55.Image = new Bitmap(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\test\49025.png", true);

            lb.Add((Bitmap)i11.Image);
            lb.Add((Bitmap)i12.Image);
            lb.Add((Bitmap)i13.Image);
            lb.Add((Bitmap)i14.Image);
            lb.Add((Bitmap)i15.Image);

            lb.Add((Bitmap)i21.Image);
            lb.Add((Bitmap)i22.Image);
            lb.Add((Bitmap)i23.Image);
            lb.Add((Bitmap)i24.Image);
            lb.Add((Bitmap)i25.Image);

            lb.Add((Bitmap)i31.Image);
            lb.Add((Bitmap)i32.Image);
            lb.Add((Bitmap)i33.Image);
            lb.Add((Bitmap)i34.Image);
            lb.Add((Bitmap)i35.Image);

            lb.Add((Bitmap)i41.Image);
            lb.Add((Bitmap)i42.Image);
            lb.Add((Bitmap)i43.Image);
            lb.Add((Bitmap)i44.Image);
            lb.Add((Bitmap)i45.Image);

            lb.Add((Bitmap)i51.Image);
            lb.Add((Bitmap)i52.Image);
            lb.Add((Bitmap)i53.Image);
            lb.Add((Bitmap)i54.Image);
            lb.Add((Bitmap)i55.Image);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3];
            Bitmap filter;
            double gray1;
            Color pixel;

            kernel[0, 0] = double.Parse(c11.Text);
            kernel[0, 1] = double.Parse(c12.Text);
            kernel[0, 2] = double.Parse(c13.Text);

            kernel[1, 0] = double.Parse(c21.Text);
            kernel[1, 1] = double.Parse(c22.Text);
            kernel[1, 2] = double.Parse(c23.Text);

            kernel[2, 0] = double.Parse(c31.Text);
            kernel[2, 1] = double.Parse(c32.Text);
            kernel[2, 2] = double.Parse(c33.Text);

            foreach (Bitmap b in lb)
            {
                filter = new Bitmap(b.Width, b.Height);

                for (int y = 0; y < b.Height; y++)
                {
                    for (int x = 0; x < b.Width; x++)
                    {
                        gray1 = 0.00;

                        pixel = b.GetPixel(x, y);
                        gray1 += kernel[0, 0] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);

                        pixel = x + 1 < b.Width ? b.GetPixel(x + 1, y) : Color.FromArgb(0);
                        gray1 += kernel[0, 1] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);

                        pixel = x + 2 < b.Width ? b.GetPixel(x + 2, y) : Color.FromArgb(0);
                        gray1 += kernel[0, 2] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);


                        pixel = y + 1 < b.Height ? b.GetPixel(x, y + 1) : Color.FromArgb(0);
                        gray1 += kernel[1, 0] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);

                        pixel = (y + 1 < b.Height) && (x + 1 < b.Width) ? b.GetPixel(x + 1, y + 1) : Color.FromArgb(0);
                        gray1 += kernel[1, 1] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);

                        pixel = (y + 1 < b.Height) && (x + 2 < b.Width) ? b.GetPixel(x + 2, y + 1) : Color.FromArgb(0);
                        gray1 += kernel[1, 2] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);


                        pixel = y + 2 < b.Height ? b.GetPixel(x, y + 2) : Color.FromArgb(0);
                        gray1 += kernel[1, 0] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);

                        pixel = (y + 2 < b.Height) && (x + 1 < b.Width) ? b.GetPixel(x + 1, y + 2) : Color.FromArgb(0);
                        gray1 += kernel[1, 1] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);

                        pixel = (y + 2 < b.Height) && (x + 2 < b.Width) ? b.GetPixel(x + 2, y + 2) : Color.FromArgb(0);
                        gray1 += kernel[1, 2] * ((double)((pixel.R + pixel.G + pixel.B) / 3.00) / 255.00);

                        gray1 = gray1 / 9.00;
                        gray1 = gray1 > 0.00 ? gray1 : 0.00;
                        gray1 = gray1 * 2.00;

                        gray1 = gray1 > 1.00 ? 1.00 : gray1;

                        pixel = Color.FromArgb((int)(255.00 * gray1), (int)(255.00 * gray1), (int)(255.00 * gray1));

                        filter.SetPixel(x, y, pixel);
                    }
                }

                for (int y = 0; y < b.Height; y++)
                    for (int x = 0; x < b.Width; x++)
                        b.SetPixel(x, y, filter.GetPixel(x, y));
            }

            this.Refresh();
        }

        private void i11_Click(object sender, EventArgs e)
        {
            Bitmap destiny;
            Image origin = ((PictureBox)sender).Image;

            destiny = new Bitmap(origin, new Size(origin.Width * 4, origin.Height * 4));
            showImage.Image = destiny;
        }
    }
}
