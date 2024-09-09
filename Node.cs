using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NEA_Interactive
{
    internal class Node
    {
        Random RNG = new Random();
        public double[] weights;
        public double output;
        public double total_weight;
        public double error;
        public double learningRate = 0.5;

        public Node(Random r, int weightNum)
        {
            RNG = r;
            weights = new double[weightNum + 1];
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = RNG.NextDouble();
            }
        }

        public void CalculateOutput(double[] inputs)
        {
            //multiplies each input by its corresponding weight then passes it thru the activation function
            for (int i = 0; i < weights.Length - 1; i++)
            {
                output += weights[i] * inputs[i];
            }
            output += weights[weights.Length - 1];
            output = Sigmoid(output);
        }

        public void CalculateOutput(Node[] oinput)
        {
            //adds 1 to end of input for bias
            double[] inputs = new double[weights.Length];
            for (int i = 0; i < oinput.Length; i++)
            {
                inputs[i] = oinput[i].output;
            }
            inputs[oinput.Length] = 1;

            //multiplies each input by its corresponding weight then passes it thru the activation function
            for (int i = 0; i < weights.Length - 1; i++)
            {
                output += weights[i] * inputs[i];
            }
            output += weights[weights.Length - 1];
            output = Sigmoid(output);
        }

        //only for output layer nodes
        public void AdjustWeights(double targetOutput, Node[] inputs)
        {
            error = targetOutput - output;
            for (int i = 0; i < weights.Length - 1; i++)
            {
                weights[i] += learningRate * error * inputs[i].output;
            }
            weights[weights.Length - 1] += learningRate * error;
        }

        //activation functions
        static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        static double ReLU(double x)
        {
            if (x >= 0) { return x; }
            else { return 0; }
        }
    }
}
