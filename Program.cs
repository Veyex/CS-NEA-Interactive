using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_NEA_Interactive
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            ////when creating a network, the first number determines how many inputs there are
            ////the following numbers determine the number of nodes in each layer
            ////so {3, 6, 4} creates a network which can take 3 inputs and has two layers of 6 and 4
            //Network nn = new Network(new int[] { 784, 100, 10 });
            //nn.DisplayNetworkStructure();
            //nn.DisplayNetworkWeights0();

            //Console.WriteLine("calcing");
            //nn.CalculateOutputs(input);
            //Console.WriteLine("backing");
            //nn.Backpropagate(7);
            //Console.WriteLine("new weights");
            //nn.DisplayNetworkWeights0();
        }
    }
}
