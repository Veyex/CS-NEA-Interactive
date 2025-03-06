using System;

namespace CS_NEA_Interactive
{
    internal class Node
    {
        public double[] weights;
        double totalWeight = 0;
        public double error = 0;
        double output = 0;
        double[] inputs;
        double learnRate = 0.2;

        public Node(Random r, int inputLength, double _learnRate)
        {
            learnRate = _learnRate;
            //creates as many weights as there are inputs (+1 for the bias) and randomly initialises them
            //also adds up the weights and puts the total into totalWeight
            weights = new double[inputLength + 1];
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = (r.NextDouble() * 2) - 1;
                totalWeight += weights[i];
            }
        }

        public Node(double[] _weights, double _learnRate)
        {
            //sets learn rate and initialises weights
            learnRate = _learnRate;
            weights = _weights;
            totalWeight = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                totalWeight += weights[i];
            }
        }

        public double Calculate(double[] newInputs)
        {
            inputs = newInputs;
            //multiplies each input by corresponding weight and adds to output
            //then adds bias at the end and passes thru activation function
            for (int i = 0; i < newInputs.Length; i++)
            {
                output += weights[i] * newInputs[i];
            }
            output += weights[weights.Length - 1];
            output = SigmoidActivation(output);
            return output;
        }

        //the error of the output nodes is just the difference between the calculated output and the target output
        public double CalculateError(double targetOutput)
        {
            error = targetOutput - output;
            return error;
        }

        //the weight / total weight is how much the preceding node affected the error of this node
        //therefore that portion of this nodes error is passed back to it
        public double CalculateErrorPortion(int posInLayer)
        {
            return (weights[posInLayer] / totalWeight) * error;
        }

        public void AdjustWeights()
        {
            //added to each weight is its correpsonding input multiplied by the nodes error,
            //multiplied by the learn rate multiplied by the derivative of the activation function at the output
            for (int i = 0; i < (weights.Length - 1); i++)
            {
                weights[i] += inputs[i] * error * learnRate * (output * (1 - output));
            }
            weights[weights.Length - 1] += error * learnRate * (output * (1 - output));

            //then total weight is also adjusted since the weights have all changed
            totalWeight = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                totalWeight += weights[i];
            }
        }

        public void AdjustLearnRate(double _learnRate)
        {
            learnRate = _learnRate;
        }


        //                       1
        // Sigmoid Function = --------
        //                     1+e^-x
        public double SigmoidActivation(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
