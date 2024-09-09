using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NEA_Interactive
{
    internal class Network
    {
        Random RNG = new Random();
        public Node[][] net;
        public int inputLength;

        public Network(int[] init)
        {
            //creates net structure according to the number of nodes per layer specified in nNums
            inputLength = init[0];
            net = new Node[init.Length - 1][];
            for (int i = 0; i < init.Length - 1; i++)
            {
                net[i] = new Node[init[i + 1]];
                //sets number of weights of each node in each layer according to the
                //number of preceding nodes or the number of inputs
                for (int j = 0; j < net[i].Length; j++)
                {
                    //if its the first layer the nodes need as many weights as there are inputs
                    if (i == 0)
                    {
                        net[i][j] = new Node(RNG, inputLength);
                    }
                    //if its not the first layer the nodes need as many weights as there are nodes in the previous layer
                    else
                    {
                        net[i][j] = new Node(RNG, net[i - 1].Length);
                    }
                }
            }
        }

        public void CalculateOutputs(double[] input)
        {
            for (int i = 0; i < net.Length; i++)
            {
                for (int j = 0; j < net[i].Length; j++)
                {
                    //if its the first layer it takes the inputs
                    if (i == 0)
                    {
                        net[i][j].CalculateOutput(input);
                    }
                    //if its not, it takes the output of the preceding layer
                    else
                    {
                        net[i][j].CalculateOutput(net[i - 1]);
                    }
                }
            }
        }

        public void Backpropagate(double targetOutput)
        {
            for (int i = 0; i < net[net.Length - 1].Length; i++)
            {
                if (i == targetOutput)
                {
                    net[net.Length - 1][i].AdjustWeights(targetOutput, net[net.Length - 2]);
                }
                else
                {
                    net[net.Length - 1][i].AdjustWeights(0, net[net.Length - 2]);
                }
            }
        }

        public void DisplayNetworkStructure()
        {
            //shows each layer and the nodes in each vertically
            foreach (Node[] layer in net)
            {
                Console.WriteLine();
                Console.Write($"{layer.Length} : ");
                foreach (Node node in layer)
                {
                    Console.Write($"o ");
                }
            }
            Console.WriteLine();
        }

        public void DisplayNetworkWeights0()
        {
            //shows each layer and the outputs of the nodes in each vertically
            foreach (Node[] layer in net)
            {
                Console.WriteLine();
                Console.WriteLine();
                foreach (Node node in layer)
                {
                    Console.Write($"{node.weights[0]} ");
                }
            }
            Console.WriteLine();
        }

        public void DisplayNetworkOutputs()
        {
            //shows each layer and the outputs of the nodes in each vertically
            foreach (Node[] layer in net)
            {
                Console.WriteLine();
                Console.WriteLine();
                foreach (Node node in layer)
                {
                    Console.Write($"{Math.Round(node.output, 2)} ");
                }
            }
            Console.WriteLine();
        }
    }
}
