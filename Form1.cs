using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_NEA_Interactive
{
    public partial class Form1 : Form
    {
        public MemoryStream memory = new MemoryStream();
        public Point newLocation = new Point();
        public Point originalLocation = new Point();

        public Graphics g;
        public Graphics graphic;

        public Pen pen = new Pen(Color.Black, 20);

        public Bitmap image;

        bool mouseDown = false;

        public Form1()
        {
            InitializeComponent();

            g = background.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;

            pen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);

            image = new Bitmap(background.Width, background.Height);
            graphic = Graphics.FromImage(image);

            background.BackgroundImage = image;
            background.BackgroundImageLayout = ImageLayout.None;

            g.Clear(Color.White);
            graphic.Clear(Color.White);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            //clears canvas and sets mouse position
            g.Clear(Color.White);
            graphic.Clear(Color.White);
            originalLocation = e.Location;
            mouseDown = true;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //updates mouse location and draws onto canvas
            newLocation = e.Location;
            if (mouseDown)
            {
                g.DrawLine(pen, originalLocation, newLocation);
                graphic.DrawLine(pen, originalLocation, newLocation);
            }

            originalLocation = newLocation;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            //saves drawn image to memory stream
            mouseDown = false;

            //surface.Save(memory, ImageFormat.Bmp);
            Bitmap resized = new Bitmap(image, new Size(28, 28));
            resized.Save(memory, ImageFormat.Bmp);

            //how to retrieve from memorystream
            //Bitmap test = (Bitmap)Image.FromStream(memory);
        }

        private void reloadTrainingImagesButton_Click(object sender, EventArgs e)
        {
            //turns input data from the training data csv into bitmap images
            StreamReader sr = new StreamReader("mnist_test.csv");
            int imageNum = 0;
            while (sr.EndOfStream == false)
            {
                Console.WriteLine(imageNum);
                sr.ReadLine();
                string[] line = sr.ReadLine().Split(',');
                double[] input = new double[line.Length - 1];
                Bitmap trainingImage = new Bitmap(28, 28);

                ////displays csv line data to console
                //Console.WriteLine(line[0]);
                //for (int i = 1; i < line.Length; i++)
                //{
                //    input[i - 1] = double.Parse(line[i]) / 256;
                //    Console.Write($"{line[i]} ");
                //    if (i % 28 == 0)
                //    {
                //        Console.WriteLine();
                //    }
                //}

                int j = 0;
                for (int i = 1; i < line.Length; i++)
                {
                    //Console.WriteLine($"{(i - 1) - (j * 28)},{j},{int.Parse(line[i])}");
                    trainingImage.SetPixel((i - 1) - (j * 28), j, Color.FromArgb(255 - int.Parse(line[i]), 255 - int.Parse(line[i]), 255 - int.Parse(line[i])));
                    if (i % 28 == 0)
                    {
                        j++;
                    }
                }
                trainingImage.Save($"trainingImage{imageNum}.Bmp", ImageFormat.Bmp);
                imageNum++;
            }
        }
    }
}
