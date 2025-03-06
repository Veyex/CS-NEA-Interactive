using System;
using System.Collections.Generic;
using System.IO;

namespace CS_NEA_Interactive
{
    internal class Network
    {
        //holds all the nodes in the given structure
        Node[][] net;
        Random RNG;
        int[] netLayout;
        int inputLength;
        double learnRate;

        public Network(Random r, int[] _netLayout, int _inputLength, double _learnRate)
        {
            RNG = r;
            netLayout = _netLayout;
            inputLength = _inputLength;
            learnRate = _learnRate;
            //sets net width to the number of layers specified in the netLayout
            //then loops thru each layer in the net, creating a new array of nodes each time
            net = new Node[_netLayout.Length][];
            for (int i = 0; i < _netLayout.Length; i++)
            {
                net[i] = new Node[_netLayout[i]];

                //then loops thru the layer creating a new node each time
                //if the new node is in the first layer (i == 0) then the input length is the same as the whole networks input length
                //otherwise the new node needs as many inputs as there are nodes in the last layer as each node gives a single output
                for (int j = 0; j < _netLayout[i]; j++)
                {
                    if (i == 0)
                    {
                        net[i][j] = new Node(r, _inputLength, _learnRate);
                    }
                    else
                    {
                        net[i][j] = new Node(r, _netLayout[i - 1], _learnRate);
                    }
                }
            }
        }

        public double[] FeedForward(double[] inputs)
        {
            double[] newInputs = inputs;
            double[] outputs = new double[1];

            //loops thru each layer in the net, reseting outputs each time
            //if its the first layer each node calculates using the inputs of the function
            //if its not then each nodes calculates using the outputs of the last layer
            for (int i = 0; i < net.Length; i++)
            {
                outputs = new double[net[i].Length];
                for (int j = 0; j < net[i].Length; j++)
                {
                    outputs[j] = net[i][j].Calculate(newInputs);
                }
                //the next layer needs to use this layers outputs to calculate but also needs
                //to overwrite the output array to put its own outputs in
                newInputs = outputs;
            }
            return outputs;
        }

        public void BackPropagate(double[] targetOutputs)
        {
            //loops thru the net backwards as the error of the output nodes needs to be calculated first
            //then the errors can be split up and passed back thru the network
            for (int i = net.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < net[i].Length; j++)
                {
                    if (i == (net.Length - 1))
                    {
                        net[i][j].CalculateError(targetOutputs[j]);
                    }
                    else
                    {
                        double error = 0;
                        for (int k = 0; k < net[i + 1].Length; k++)
                        {
                            error += net[i + 1][k].CalculateErrorPortion(j);
                        }
                        net[i][j].error = error;
                    }
                }
            }

            //once each node has calculated its error it can use this to adjust all of its weights
            for (int i = 0; i < net.Length; i++)
            {
                for (int j = 0; j < net[i].Length; j++)
                {
                    net[i][j].AdjustWeights();
                }
            }
        }

        //deprecated function replaced with train better
        ////loops thru the training inputs at random until its done the requested number of epochs
        ////each loop it feeds the input thru the network then calculates all the errors and adjust weights accordingly
        //public void Train(List<double[]> trainingInputs, List<double[]> trainingOutputs, int epochs)
        //{
        //    for (int i = 0; i < epochs; i++)
        //    {
        //        int choice = RNG.Next(trainingInputs.Count);
        //        FeedForward(trainingInputs[choice]);
        //        BackPropagate(trainingOutputs[choice]);
        //        Console.WriteLine($"Epoch {i + 1} complete");
        //    }
        //}


        public void TrainBetter(List<double[]> trainingInputs, List<double[]> trainingOutputs, int epochs, int sampleSize, Action<int> setImage, bool imagesIncluded)
        {
            for (int i = 0; i < epochs; i++)
            {
                List<double[]> trainingInputsTemp = new List<double[]>(trainingInputs);
                List<double[]> trainingOutputsTemp = new List<double[]>(trainingOutputs);
                int originalCount = trainingInputsTemp.Count;

                while (trainingInputsTemp.Count > originalCount - sampleSize)
                {
                    //randomly selects image from training data array
                    //then puts corresponding bitmap to picture box
                    //feeds data forward thru the network then backpropagates
                    //then removes image from array
                    //all loops until all images have been used and resets for next epoch
                    int choice = RNG.Next(trainingInputsTemp.Count);
                    if (imagesIncluded)
                    {
                    setImage(choice);
                    }
                    FeedForward(trainingInputsTemp[choice]);
                    BackPropagate(trainingOutputsTemp[choice]);
                    trainingInputsTemp.RemoveAt(choice);
                    trainingOutputsTemp.RemoveAt(choice);
                }
                Console.WriteLine($"Epoch {i + 1} complete");
            }
        }

        //deprecated function for testing in console only mode
        //public void OutputResults(List<double[]> trainingInputs, List<double[]> trainingOutputs)
        //{
        //    for (int i = 0; i < trainingInputs.Count; i++)
        //    {
        //        double total = 0;
        //        double[] outputs = FeedForward(trainingInputs[i]);
        //        for (int j = 0; j < trainingInputs[i].Length; j++)
        //        {
        //            Console.Write($"{trainingInputs[i][j]} ");
        //        }
        //        Console.Write("    ");
        //        for (int j = 0; j < trainingOutputs[i].Length; j++)
        //        {
        //            Console.Write($"{trainingOutputs[i][j]} ");
        //        }
        //        Console.Write("    ");
        //        for (int j = 0; j < outputs.Length; j++)
        //        {
        //            Console.Write($"{outputs[j]} ");
        //        }
        //        Console.Write($"    {outputs[0] - trainingOutputs[i][0]} ");
        //        total += outputs[0] - trainingOutputs[i][0];
        //        Console.WriteLine();
        //        Console.WriteLine(total / trainingInputs.Count);
        //    }
        //}

        public void AdjustLearnRate(double learnRate)
        {
            //loops thru each node and changes the learn rate
            for (int i = 0; i < net.Length; ++i)
            {
                for (int j = 0; j < net[i].Length; j++)
                {
                    net[i][j].AdjustLearnRate(learnRate);
                }
            }
        }

        //just shows how many layers there are and how many nodes in each (for debugging purposes)
        //public void PrintNetworkStructure()
        //{
        //    for (int i = 0; i < net.Length; i++)
        //    {
        //        for (int j = 0; j < net[i].Length; j++)
        //        {
        //            Console.Write("o ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine();
        //}

        public void SaveNetworkToFile(string fileName)
        {
            //writes layout then input length then learn rate to file
            StreamWriter sw = new StreamWriter($"{fileName}");
            string line = "";
            for (int i = 0; i < netLayout.Length; i++)
            {
                line += netLayout[i];
                if (i != netLayout.Length - 1)
                {
                    line += " ";
                }
            }
            sw.WriteLine(line);
            sw.WriteLine(inputLength);
            sw.WriteLine(learnRate);
            //then loops thru all nodes and writes weights to file
            for (int i = 0; i < net.Length; i++)
            {

                for (int j = 0; j < net[i].Length; j++)
                {
                    line = "";
                    for (int k = 0; k < net[i][j].weights.Length; k++)
                    {
                        line += net[i][j].weights[k];
                        if (k != net[i][j].weights.Length - 1)
                        {
                            line += " ";
                        }
                    }
                    sw.WriteLine(line);
                }
            }
            sw.Close();
        }

        public void LoadNetworkFromFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            netLayout = Array.ConvertAll(sr.ReadLine().Split(' '), s => int.Parse(s));
            inputLength = int.Parse(sr.ReadLine());
            learnRate = double.Parse(sr.ReadLine());

            //sets net width to the number of layers specified in the netLayout
            //then loops thru each layer in the net, creating a new array of nodes each time
            net = new Node[netLayout.Length][];
            for (int i = 0; i < netLayout.Length; i++)
            {
                net[i] = new Node[netLayout[i]];

                //then loops thru the layer creating a new node each time
                //if the new node is in the first layer (i == 0) then the input length is the same as the whole networks input length
                //otherwise the new node needs as many inputs as there are nodes in the last layer as each node gives a single output
                for (int j = 0; j < netLayout[i]; j++)
                {
                    if (i == 0)
                    {
                        net[i][j] = new Node(Array.ConvertAll(sr.ReadLine().Split(' '), s => double.Parse(s)), learnRate);
                    }
                    else
                    {
                        net[i][j] = new Node(Array.ConvertAll(sr.ReadLine().Split(' '), s => double.Parse(s)), learnRate);
                    }
                }
            }
            sr.Close();
        }
    }
}
