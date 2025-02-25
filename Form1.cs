using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace CS_NEA_Interactive
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Network myNetwork = null;
        int[] layout;
        int inputLength;
        double learningRate;

        List<double[]> trainingInputs;
        List<double[]> trainingOutputs;
        List<double[]> testingInputs;
        List<double[]> testingOutputs;
        public List<String> imageLocations;

        //for user input
        public MemoryStream memory = new MemoryStream();
        public Point newLocation = new Point();
        public Point originalLocation = new Point();

        public Graphics g;
        public Graphics graphic;

        public Pen pen = new Pen(Color.Black, 20);

        public Bitmap image;
        public Bitmap resized;

        bool mouseDown = false;

        public double[] userInputArray;


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
            mouseDown = false;

            resized = new Bitmap(image, new Size(28, 28));
            //resized.Save(memory, ImageFormat.Bmp);
            //MNISTDatasetInputPictureBox.Image = (Bitmap)Image.FromStream(memory);
            MNISTDatasetInputPictureBox.Image = resized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userInputArray = new double[784];
            int count = 0;
            try
            {
                for (int x = 0; x < resized.Width; x++)
                {
                    for (int y = 0; y < resized.Height; y++)
                    {
                        Color pixelColour = resized.GetPixel(y, x);
                        userInputArray[count] = 255 - pixelColour.R;
                        //Console.WriteLine($"{count} {255 - pixelColour.R}");
                        count++;
                    }
                }
                if (mnistBinCheckbox.Checked)
                {
                    double[] outputs = myNetwork.FeedForward(userInputArray);
                    Console.WriteLine("outputs:");
                    Console.WriteLine($"{outputs[0]} {outputs[1]}");
                }
                else if (mnistQuadCheckbox.Checked)
                {
                    double[] outputs = myNetwork.FeedForward(userInputArray);
                    Console.WriteLine("outputs:");
                    Console.WriteLine($"{outputs[0]} {outputs[1]} {outputs[2]} {outputs[3]}");
                }
            }
            catch { }
        }

        private void reloadTrainingImagesButton_Click(object sender, EventArgs e)
        {
            //turns input data from the training data csv into bitmap images
            StreamReader sr = new StreamReader("mnist_train.csv");
            int imageNum = 0; 
            sr.ReadLine();
            while (sr.EndOfStream == false)
            {
                Console.WriteLine(imageNum);
                //sr.ReadLine();
                string[] line = sr.ReadLine().Split(',');
                //double[] input = new double[line.Length - 1];
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
                trainingImage.Save($"images/{line[0]}/trainingImage{imageNum}.Bmp", ImageFormat.Bmp);
                imageNum++;
            }
        }

        private void newNetworkButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Loading Network...");
            try
            {
                layout = Array.ConvertAll(netLayoutInput.Text.Split(','), s=> int.Parse(s));
                inputLength = int.Parse(inputLengthInput.Text);
                learningRate = double.Parse(learnRateInput.Text);
                myNetwork = new Network(r, layout, inputLength, learningRate);
            }
            catch
            {
                Console.WriteLine("network parameters invalid");
            }
            Console.WriteLine("Finished");
        }

        private void loadNetworkButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Loading Network...");
            try
            {
                myNetwork = new Network(r, new int[] { 2, 1 }, 2, 0.2);
                myNetwork.LoadNetworkFromFile(networkFilePathInput.Text);
            }
            catch
            {
                Console.WriteLine("network file path invalid");
            }
            Console.WriteLine("Finished");
        }

        private void andGateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            xorGateCheckbox.Checked = false;
            mnistBinCheckbox.Checked = false;
            mnistQuadCheckbox.Checked = false;
            mnistFullCheckbox.Checked = false;
        }

        private void xorGateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            andGateCheckbox.Checked = false;
            mnistBinCheckbox.Checked = false;
            mnistQuadCheckbox.Checked = false;
            mnistFullCheckbox.Checked = false;
        }

        private void mnistBinCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            xorGateCheckbox.Checked = false;
            andGateCheckbox.Checked = false;
            mnistQuadCheckbox.Checked = false;
            mnistFullCheckbox.Checked = false;
        }

        private void mnistQuadCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            xorGateCheckbox.Checked = false;
            andGateCheckbox.Checked = false;
            mnistBinCheckbox.Checked = false;
            mnistFullCheckbox.Checked = false;
        }

        private void mnistFullCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            xorGateCheckbox.Checked = false;
            andGateCheckbox.Checked = false;
            mnistBinCheckbox.Checked = false;
            mnistQuadCheckbox.Checked = false;
        }

        private void loadTrainingDataButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Loading Training Data...");
            if (andGateCheckbox.Checked)
            {
                trainingInputs = new List<double[]>() { new double[] { 0, 0 },
                                                        new double[] { 0, 1 },
                                                        new double[] { 1, 0 },
                                                        new double[] { 1, 1 } };

                trainingOutputs = new List<double[]>() { new double[] { 0 },
                                                         new double[] { 0 },
                                                         new double[] { 0 },
                                                         new double[] { 1 } };
            }
            else if (xorGateCheckbox.Checked)
            {
                trainingInputs = new List<double[]>() { new double[] { 0, 0 },
                                                        new double[] { 0, 1 },
                                                        new double[] { 1, 0 },
                                                        new double[] { 1, 1 } };

                trainingOutputs = new List<double[]>() { new double[] { 0 },
                                                         new double[] { 1 },
                                                         new double[] { 1 },
                                                         new double[] { 0 } };
            }
            else if (mnistBinCheckbox.Checked)
            {
                trainingInputs = LoadMnistInputsBin(true);
                trainingOutputs = LoadMnistOutputsBin(true);
                Console.WriteLine("Loading Testing Data...");
                testingInputs = LoadMnistInputsBin(false);
                testingOutputs = LoadMnistOutputsBin(false);
            }
            else if (mnistQuadCheckbox.Checked)
            {
                trainingInputs = LoadMnistInputsQuad(true);
                trainingOutputs = LoadMnistOutputsQuad(true);
                Console.WriteLine("Loading Testing Data...");
                testingInputs = LoadMnistInputsQuad(false);
                testingOutputs = LoadMnistOutputsQuad(false);
            }
            Console.WriteLine("Finished");
        }

        private void trainNetworkButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Training...");
            int epochs = int.Parse(epochsInput.Text);
            myNetwork.TrainBetter(trainingInputs, trainingOutputs, epochs, setImage);
            Console.WriteLine("Finished");
        }

        private void networkTestButton_Click(object sender, EventArgs e)
        {
            if (andGateCheckbox.Checked || xorGateCheckbox.Checked)
            {
                Console.WriteLine("inputs:");
                Console.WriteLine("0 0");
                Console.WriteLine("0 1");
                Console.WriteLine("1 0");
                Console.WriteLine("1 1");

                Console.WriteLine("outputs:");
                for (int i = 0; i < trainingInputs.Count; i++)
                {
                    double[] outputs = myNetwork.FeedForward(trainingInputs[i]);
                    for (int j = 0; j < outputs.Length; j++)
                    {
                        Console.WriteLine(outputs[j]);
                    }
                }
            }
            else if (mnistBinCheckbox.Checked)
            {
                int startPoint = r.Next(testingInputs.Count-10);
                Console.WriteLine("sample outputs:");
                for (int i = startPoint; i < startPoint + 10; i++)
                {
                    double[] outputs = myNetwork.FeedForward(testingInputs[i]);
                    Console.WriteLine($"{testingOutputs[i][0]} {testingOutputs[i][1]}");
                    Console.WriteLine($"{outputs[0]} {outputs[1]}");
                }
            }
            else if (mnistQuadCheckbox.Checked)
            {
                int startPoint = r.Next(testingInputs.Count - 10);
                Console.WriteLine("sample outputs:");
                for (int i = startPoint; i < startPoint + 10; i++)
                {
                    double[] outputs = myNetwork.FeedForward(testingInputs[i]);
                    Console.WriteLine($"{testingOutputs[i][0]} {testingOutputs[i][1]} {testingOutputs[i][2]} {testingOutputs[i][3]}");
                    Console.WriteLine($"{outputs[0]} {outputs[1]} {outputs[2]} {outputs[3]}");
                }
            }
        }

        private void saveNetworkButton_Click(object sender, EventArgs e)
        {
            if (myNetwork != null)
            {
                myNetwork.SaveNetworkToFile(networkFilePathInput.Text);
            }
        }

        List<double[]> LoadMnistInputsBin(bool trainNotTest)
        {
            List<double[]> dataset = new List<double[]>();
            StreamReader sr;
            if (trainNotTest)
            {
                sr = new StreamReader("mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("mnist_test.csv");
            }
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                double[] arr = Array.ConvertAll(sr.ReadLine().Split(','), double.Parse);
                if (arr[0] == 0 || arr[0] == 1)
                {
                    double[] datapoint = new double[arr.Length - 1];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        datapoint[i - 1] = arr[i];
                    }
                    dataset.Add(datapoint);
                }
            }
            return dataset;
        }

        List<double[]> LoadMnistOutputsBin(bool trainNotTest)
        {
            int count = 0;
            if (trainNotTest)
            {
                imageLocations = new List<string>();
            }
            List<double[]> outputs = new List<double[]>();
            StreamReader sr;
            if (trainNotTest)
            {
                sr = new StreamReader("mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("mnist_test.csv");
            }
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                double[] arr = Array.ConvertAll(sr.ReadLine().Split(','), double.Parse);
                if (arr[0] == 0)
                {
                    outputs.Add(new double[] { 1, 0 });
                    if (trainNotTest)
                    {
                        imageLocations.Add($"0/trainingImage{count}.Bmp");
                    }
                }
                else if (arr[0] == 1)
                {
                    outputs.Add(new double[] { 0, 1 });
                    if (trainNotTest)
                    {
                        imageLocations.Add($"1/trainingImage{count}.Bmp");
                    }
                }
                count++;
            }
            return outputs;
        }

        List<double[]> LoadMnistInputsQuad(bool trainNotTest)
        {
            List<double[]> dataset = new List<double[]>();
            StreamReader sr;
            if (trainNotTest)
            {
                sr = new StreamReader("mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("mnist_test.csv");
            }
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                double[] arr = Array.ConvertAll(sr.ReadLine().Split(','), double.Parse);
                if (arr[0] == 0 || arr[0] == 1 || arr[0] == 2 || arr[0] == 3)
                {
                    double[] datapoint = new double[arr.Length - 1];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        datapoint[i - 1] = arr[i];
                    }
                    dataset.Add(datapoint);
                }
            }
            return dataset;
        }

        List<double[]> LoadMnistOutputsQuad(bool trainNotTest)
        {
            int count = 0;
            if (trainNotTest)
            {
                imageLocations = new List<string>();
            }
            List<double[]> outputs = new List<double[]>();
            StreamReader sr;
            if (trainNotTest)
            {
                sr = new StreamReader("mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("mnist_test.csv");
            }
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                double[] arr = Array.ConvertAll(sr.ReadLine().Split(','), double.Parse);
                if (arr[0] == 0)
                {
                    outputs.Add(new double[] { 1, 0, 0, 0 }); if (trainNotTest)
                    {
                        imageLocations.Add($"0/trainingImage{count}.Bmp");
                    }
                }
                else if (arr[0] == 1)
                {
                    outputs.Add(new double[] { 0, 1, 0, 0 }); if (trainNotTest)
                    {
                        imageLocations.Add($"1/trainingImage{count}.Bmp");
                    }
                }
                else if (arr[0] == 2)
                {
                    outputs.Add(new double[] { 0, 0, 1, 0 }); if (trainNotTest)
                    {
                        imageLocations.Add($"2/trainingImage{count}.Bmp");
                    }
                }
                else if (arr[0] == 3)
                {
                    outputs.Add(new double[] { 0, 0, 0, 1 }); if (trainNotTest)
                    {
                        imageLocations.Add($"3/trainingImage{count}.Bmp");
                    }
                }
                count++;
            }
            return outputs;
        }

        private void learnRateInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (myNetwork != null)
                {
                    myNetwork.AdjustLearnRate(Convert.ToDouble(learnRateInput.Text));
                    Console.WriteLine("Changed Learn Rate");
                }
            }
            catch { }
        }

        public void setImage(int i)
        {
            MNISTDatasetInputPictureBox.Load($"D:/0.College/Computer Science/programs/CS-NEA-Interactive/bin/Debug/images/{imageLocations[i]}");
            MNISTDatasetInputPictureBox.Refresh();
        }

    }
}
