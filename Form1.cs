using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace CS_NEA_Interactive
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Network myNetwork = null;
        int[] layout;
        int inputLength;
        double learningRate;

        List<double[]> trainingInputs = null;
        List<double[]> trainingOutputs = null;
        List<double[]> testingInputs = null;
        List<double[]> testingOutputs = null;
        public List<String> imageLocations = null;

        //for user input
        public MemoryStream memory = new MemoryStream();
        public Point newLocation = new Point();
        public Point originalLocation = new Point();

        public Graphics g;
        public Graphics graphic;

        public Pen pen = new Pen(Color.Black, 25);

        public Bitmap image;
        public Bitmap resized;

        bool mouseDown = false;

        public double[] userInputArray;


        public Form1()
        {
            //creates canvas and clears to white
            //also sets up basic pen for drawing
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

            //resizes image and copies to the input picture box
            resized = new Bitmap(image, new Size(28, 28));
            MNISTDatasetInputPictureBox.Image = resized;
        }

        //feeds user input through the network
        private void button1_Click(object sender, EventArgs e)
        {
            userInputArray = new double[784];
            int count = 0;
            try
            {
                //loops thru each pixel in the image and puts into an array
                for (int x = 0; x < resized.Width; x++)
                {
                    for (int y = 0; y < resized.Height; y++)
                    {
                        Color pixelColour = resized.GetPixel(y, x);
                        userInputArray[count] = 255 - pixelColour.R;
                        count++;
                    }
                }
                //then passes the array thru the network and shows the outputs
                if (mnistBinCheckbox.Checked || mnistQuadCheckbox.Checked || mnistFullCheckbox.Checked)
                {
                    double[] outputs = myNetwork.FeedForward(userInputArray);

                    Console.WriteLine("outputs:");
                    for (int j = 0; j < outputs.Length; j++)
                    {
                        Console.Write($"{outputs[j]} ");
                    }
                    Console.WriteLine();
                    return;
                }
            }
            catch { return; }
        }

        private void reloadTrainingImagesButton_Click(object sender, EventArgs e)
        {
            //turns input data from the training data csv into bitmap images for displaying
            StreamReader sr = new StreamReader("mnist_train.csv");
            int imageNum = 0; 
            sr.ReadLine();
            while (sr.EndOfStream == false)
            {
                Console.WriteLine(imageNum);
                string[] line = sr.ReadLine().Split(',');
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
                if (mnistBinCheckbox.Checked || mnistQuadCheckbox.Checked)
                {
                    if (inputLength != 784)
                    {
                        Console.WriteLine("Warning: Input length must be 784 to train on MNIST dataset");
                    }
                }
                if (xorGateCheckbox.Checked || andGateCheckbox.Checked)
                {
                    if (inputLength != 2)
                    {
                        Console.WriteLine("Warning: Input length must be 2 to emulate logic gate");
                    }
                }
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
            else if (mnistFullCheckbox.Checked)
            {
                trainingInputs = LoadMnistInputsFull(true);
                trainingOutputs = LoadMnistOutputsFull(true);
                Console.WriteLine("Loading Testing Data...");
                testingInputs = LoadMnistInputsFull(false);
                testingOutputs = LoadMnistOutputsFull(false);
            }
            Console.WriteLine($"Training Dataset Size: {trainingInputs.Count}");
            Console.WriteLine("Finished");
        }

        private void trainNetworkButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Training...");
            int epochs = int.Parse(epochsInput.Text);
            int sampleSize = int.Parse(sampleSizeTextBox.Text);
            if (andGateCheckbox.Checked || xorGateCheckbox.Checked)
            {
                myNetwork.TrainBetter(trainingInputs, trainingOutputs, epochs, sampleSize, setImage, false);
            }
            else
            {
                myNetwork.TrainBetter(trainingInputs, trainingOutputs, epochs, sampleSize, setImage, true);
            }
            Console.WriteLine("Finished");
            try
            {
                
            }
            catch
            {
                Console.WriteLine("Invalid network for training on this model / dataset");
            }
        }

        private void networkTestButton_Click(object sender, EventArgs e)
        {
            if (andGateCheckbox.Checked || xorGateCheckbox.Checked)
            {
                //only four possible inputs for a logic gate
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
            else if (mnistBinCheckbox.Checked || mnistQuadCheckbox.Checked || mnistFullCheckbox.Checked)
            {
                //selects random point in the testing data to start and feeds thru the ten proceding inputs
                int startPoint = r.Next(testingInputs.Count-10);
                Console.WriteLine("sample outputs:");
                for (int i = startPoint; i < startPoint + 10; i++)
                {
                    double[] outputs = myNetwork.FeedForward(testingInputs[i]);
                    for (int j = 0; j < testingOutputs[0].Length; j++)
                    {
                        Console.Write($"{testingOutputs[i][j]} ");
                    }
                    Console.WriteLine();
                    for (int j = 0; j < testingOutputs[0].Length; j++)
                    {
                        Console.Write($"{outputs[j]} ");
                    }
                    Console.WriteLine();



                    //Console.WriteLine($"{testingOutputs[i][0]} {testingOutputs[i][1]}");
                    //Console.WriteLine($"{outputs[0]} {outputs[1]}");
                }
            }
            //else if (mnistQuadCheckbox.Checked)
            //{
            //    //selects random point in the testing data to start and feeds thru the ten proceding inputs
            //    int startPoint = r.Next(testingInputs.Count - 10);
            //    Console.WriteLine("sample outputs:");
            //    for (int i = startPoint; i < startPoint + 10; i++)
            //    {
            //        double[] outputs = myNetwork.FeedForward(testingInputs[i]);
            //        Console.WriteLine($"{testingOutputs[i][0]} {testingOutputs[i][1]} {testingOutputs[i][2]} {testingOutputs[i][3]}");
            //        Console.WriteLine($"{outputs[0]} {outputs[1]} {outputs[2]} {outputs[3]}");
            //    }
            //}
        }

        private void saveNetworkButton_Click(object sender, EventArgs e)
        {
            //if the network exists, passes file path to the save method
            if (myNetwork != null)
            {
                Console.WriteLine("Saved");
                myNetwork.SaveNetworkToFile(networkFilePathInput.Text);
            }
        }

        List<double[]> LoadMnistInputsBin(bool trainNotTest)
        {
            List<double[]> dataset = new List<double[]>();
            StreamReader sr;
            //selects wanted csv file
            if (trainNotTest)
            {
                sr = new StreamReader("/mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("/mnist_test.csv");
            }
            sr.ReadLine();
            //loops thru every line of the csv
            while (!sr.EndOfStream)
            {
                //each line has 785 values, the first tells you what number is being represented,
                //the others correspond to the pixel values of the image (28x28 image means 784 pixels)
                //only selects data corresponding to the numbers we want
                //then adds the image file path and the pixel data
                double[] arr = Array.ConvertAll(sr.ReadLine().Split(','), double.Parse);
                if (arr[0] == 0 || arr[0] == 1)
                {
                    double[] datapoint = new double[arr.Length - 1];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        datapoint[i - 1] = arr[i] / 256;
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
            //selects wanted csv file
            if (trainNotTest)
            {
                sr = new StreamReader("/mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("/mnist_test.csv");
            }
            sr.ReadLine();
            //loops thru every line of the csv
            while (!sr.EndOfStream)
            {
                //each line has 785 values, the first tells you what number is being represented,
                //the others correspond to the pixel values of the image (28x28 image means 784 pixels)
                //only selects data corresponding to the numbers we want
                //then adds the image file path and the output
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
            //selects wanted csv file
            if (trainNotTest)
            {
                sr = new StreamReader("/mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("/mnist_test.csv");
            }
            sr.ReadLine();
            //loops thru every line of the csv
            while (!sr.EndOfStream)
            {
                //each line has 785 values, the first tells you what number is being represented,
                //the others correspond to the pixel values of the image (28x28 image means 784 pixels)
                //only selects data corresponding to the numbers we want
                //then adds the image file path and the pixel data
                double[] arr = Array.ConvertAll(sr.ReadLine().Split(','), double.Parse);
                if (arr[0] == 0 || arr[0] == 1 || arr[0] == 2 || arr[0] == 3)
                {
                    double[] datapoint = new double[arr.Length - 1];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        datapoint[i - 1] = arr[i] / 256;
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
                // if training create new list for all the image locations
                imageLocations = new List<string>();
            }
            List<double[]> outputs = new List<double[]>();
            StreamReader sr;
            //selects corresponding csv file for training / testing
            if (trainNotTest)
            {
                sr = new StreamReader("/mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("/mnist_test.csv");
            }
            sr.ReadLine();
            //loops thru every line of the csv
            while (!sr.EndOfStream)
            {
                //each line has 785 values, the first tells you what number is being represented,
                //the others correspond to the pixel values of the image (28x28 image means 784 pixels)
                //only selects data corresponding to the numbers we want
                //then adds the image file path and the output
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

        List<double[]> LoadMnistInputsFull(bool trainNotTest)
        {
            List<double[]> dataset = new List<double[]>();
            StreamReader sr;
            //selects wanted csv file
            if (trainNotTest)
            {
                sr = new StreamReader("/mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("/mnist_test.csv");
            }
            sr.ReadLine();
            //loops thru every line of the csv
            while (!sr.EndOfStream)
            {
                //each line has 785 values, the first tells you what number is being represented,
                //the others correspond to the pixel values of the image (28x28 image means 784 pixels)
                //only selects data corresponding to the numbers we want
                //then adds the image file path and the pixel data
                double[] arr = Array.ConvertAll(sr.ReadLine().Split(','), double.Parse);
                double[] datapoint = new double[arr.Length - 1];
                for (int i = 1; i < arr.Length; i++)
                {
                    datapoint[i - 1] = arr[i] / 256;
                }
                dataset.Add(datapoint);
            }
            return dataset;
        }
        List<double[]> LoadMnistOutputsFull(bool trainNotTest)
        {
            int count = 0;
            if (trainNotTest)
            {
                // if training create new list for all the image locations
                imageLocations = new List<string>();
            }
            List<double[]> outputs = new List<double[]>();
            StreamReader sr;
            //selects corresponding csv file for training / testing
            if (trainNotTest)
            {
                sr = new StreamReader("/mnist_train.csv");
            }
            else
            {
                sr = new StreamReader("/mnist_test.csv");
            }
            sr.ReadLine();
            //loops thru every line of the csv
            while (!sr.EndOfStream)
            {
                //each line has 785 values, the first tells you what number is being represented,
                //the others correspond to the pixel values of the image (28x28 image means 784 pixels)
                //only selects data corresponding to the numbers we want
                //then adds the image file path and the output
                double[] arr = Array.ConvertAll(sr.ReadLine().Split(','), double.Parse);
                if (trainNotTest)
                {
                    imageLocations.Add($"{arr[0]}/trainingImage{count}.Bmp");
                }
                if (arr[0] == 0)
                {
                    outputs.Add(new double[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                }
                else if (arr[0] == 1)
                {
                    outputs.Add(new double[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
                }
                else if (arr[0] == 2)
                {
                    outputs.Add(new double[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 }); 
                }
                else if (arr[0] == 3)
                {
                    outputs.Add(new double[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }); 
                }
                else if (arr[0] == 4)
                {
                    outputs.Add(new double[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }); 
                }
                else if (arr[0] == 5)
                {
                    outputs.Add(new double[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }); 
                }
                else if (arr[0] == 6)
                {
                    outputs.Add(new double[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }); 
                }
                else if (arr[0] == 7)
                {
                    outputs.Add(new double[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }); 
                }
                else if (arr[0] == 8)
                {
                    outputs.Add(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }); 
                }
                else if (arr[0] == 9)
                {
                    outputs.Add(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }); 
                }
                count++;
            }
            return outputs;
        }



        private void learnRateInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //checks a network exists then changes the learn rate
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
            //for cycling through images when training
            MNISTDatasetInputPictureBox.Load($"D:/0.College/Computer Science/programs/CS-NEA-Interactive/bin/Debug/images/{imageLocations[i]}");
            MNISTDatasetInputPictureBox.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (true)
            {
                int epochs = int.Parse(epochsInput.Text);
                int sampleSize = int.Parse(sampleSizeTextBox.Text);
                //myNetwork.TrainBetter(trainingInputs, trainingOutputs, epochs, sampleSize, setImage);

                int startPoint = r.Next(testingInputs.Count - 10);
                double[] outputs = myNetwork.FeedForward(testingInputs[startPoint]);
                double out0 = outputs[0];
                double out1 = outputs[1];
                double out2 = outputs[2];
                double out3 = outputs[3];

                startPoint = r.Next(testingInputs.Count - 10);
                outputs = myNetwork.FeedForward(testingInputs[startPoint]);

                Console.WriteLine($"{out0} {out1} {out2} {out3}");
                Console.WriteLine($"{outputs[0]} {outputs[1]} {outputs[2]} {outputs[3]}");

                if (Math.Abs(out0 - outputs[0]) > 0.1 || Math.Abs(out1 - outputs[1]) > 0.1 || Math.Abs(out2 - outputs[2]) > 0.1 || Math.Abs(out3 - outputs[3]) > 0.1)
                {
                    return;
                }
                //layout = Array.ConvertAll(netLayoutInput.Text.Split(','), s => int.Parse(s));
                //inputLength = int.Parse(inputLengthInput.Text);
                //learningRate = double.Parse(learnRateInput.Text);
                //myNetwork = new Network(r, layout, inputLength, learningRate);
            }
        }
    }
}
