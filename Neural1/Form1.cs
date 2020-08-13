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
    public partial class Form1 : Form
    {
        NeuralUtility nn = null;
        DateTime deltaT = DateTime.Now;
        bool draw = false;

        int start;
        int finish;
        int test;

        public Form1()
        {
            InitializeComponent();
        }

        void Clear()
        {
            lLog.Items.Clear();
            lLog2.Items.Clear();
        }

        void Log(string l)
        {
            lLog.Items.Add(l);
        }

        void Log2(string l)
        {

            if (l.Length >= 6)
            {
                if (l.Substring(0, 6) == "Image:")
                    lLog2.Items.Clear();
            }

            lLog2.Items.Add(l);

            if (l.Length >= 9)
            {
                if (l.Substring(0, 9) == "Accuracy:")
                {
                    if (deltaT.AddSeconds(1) < DateTime.Now)
                    {
                        lLog2.Refresh();
                        lLog.Refresh();

                        deltaT = DateTime.Now;
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            nn = new NeuralUtility();
            nn.activation = ACTIVATION.SIGMOID;
            nn.loss = LOSS.MSE;
            nn.connection = CONNECTIONS.ALL_IN_ALL;
            nn.bias = 0.000;
            nn.learnFactor = 0.01;

            nn.LoadFromFile(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\0.png", true);
            nn.AddLayer(196);
            nn.AddLayer(49);

            nn.activation = ACTIVATION.SOFTMAX;
            nn.loss = LOSS.CROSS_ENTROPY;

            nn.AddLayer(10);

            nn.Randomize(2, 9, -1, true);

            // entry
            /*
            nn.AddLayer(2);

            //hidden
            nn.activation = ACTIVATION.SIGMOID;
            nn.AddLayer(2);

            //output
            nn.AddLayer(1);

            nn.Randomize(2, 9, -1, true);

            List<Tuple<double, double, double>> trainList = new List<Tuple<double, double, double>>();
            Tuple<double, double, double> value;

            value = new Tuple<double, double, double>(0.00, 0.00, 0.00);
            trainList.Add(value);

            value = new Tuple<double, double, double>(0.00, 1.00, 1.00);
            trainList.Add(value);

            value = new Tuple<double, double, double>(1.00, 0.00, 1.00);
            trainList.Add(value);

            value = new Tuple<double, double, double>(1.00, 1.00, 0.00);
            trainList.Add(value);


            //train    
            for (int i = 0; i < 10000; i++)
            {
                foreach (Tuple<double, double, double> item in trainList)
                {
                    nn.entry.Clear();
                    nn.entry.Add(item.Item1);
                    nn.entry.Add(item.Item2);

                    nn.expected.Clear();
                    nn.expected.Add(item.Item3);

                    nn.Process();
                    nn.Learn();
                }
            }


            lLog2.Items.Clear();

            foreach (Tuple<double, double, double> item in trainList)
            {
                nn.entry.Clear();
                nn.entry.Add(item.Item1);
                nn.entry.Add(item.Item2);
                nn.Process();

                lLog2.Items.Add("Test: " + ((int)item.Item1).ToString() + " - " + ((int)item.Item2).ToString());
                lLog2.Items.Add("    result: " + nn.output[0].ToString("0.0000"));
            }
            */
            start = 1;
            finish = 40000;
            test = 1000;

            nn.LogFunction = Log;
            nn.ShowDefinition();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log("");
            Log("Training...");
            nn.LogFunction = Log2;

            nn.trainningFromDirectoryLayout1(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\train", "train.csv", start, finish);

            Log("Finish!");
            Log2("Finish!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nn == null)
                return;

            Log("");
            Log("Testing...");
            nn.LogFunction = Log2;

            nn.testFromDirectoryLayout1(@"C:\Users\Jonathan\Documents\Visual Studio 2012\Projects\Train_MNIST\Images\train", "train.csv", finish + 1, finish + test);

            Log("Finish!");
            Log2("Finish!");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button3_Click(null, null);
            button5_Click(null, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(28, 28);

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                    bmp.SetPixel(j, i, Color.FromArgb(0, 0, 0));
            }

            pbTest.Image = bmp;

            bmp = new Bitmap(112, 112);

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                    bmp.SetPixel(j, i, Color.FromArgb(0, 0, 0));
            }

            pbTest2.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nn.LoadFromBMP((Bitmap)pbTest.Image);
            nn.Process();
            lbresult.Text = nn.index.ToString();
            lacc.Text = "acc: " + (nn.accuracy * 100.00).ToString("0.00") + "%";

            Color c;

            if (nn.accuracy >= 0.80)
                c = Color.SeaGreen;
            else
                if (nn.accuracy >= 0.75)
                    c = Color.DarkGoldenrod;
                else
                    c = Color.Tomato;


            label1.BackColor = c;
            lbresult.BackColor = c;
            lacc.BackColor = c;
        }

        private void pbTest2_MouseLeave(object sender, EventArgs e)
        {
            draw = false;
        }

        private void pbTest2_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                try
                {
                    for (int i = -5; i < 3; i++)
                        for (int j = -5; j < 3; j++)
                            ((Bitmap)pbTest2.Image).SetPixel(e.X + i, e.Y + j, Color.FromArgb(255, 255, 255));

                    for (int i = -2; i < 0; i++)
                        for (int j = -2; j < 0; j++)
                        {
                            if ((((i + j) * -1) % 2 == 1) || (i == -1 && j == -1))
                                ((Bitmap)pbTest.Image).SetPixel(e.X / 4 + i, e.Y / 4 + j, Color.FromArgb(255, 255, 255));
                            else
                                ((Bitmap)pbTest.Image).SetPixel(e.X / 4 + i, e.Y / 4 + j, Color.FromArgb(130, 130, 130));
                        }

                    pbTest.Refresh();

                    pbTest2.Refresh();
                }
                catch
                {
                }
            }
        }

        private void pbTest2_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
        }

        private void pbTest2_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void pbTest2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                button5_Click(null, null);
        }

        private void pbTest2_DoubleClick(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (!int.TryParse(meTrain.Text, out i))
                return;

            Log2("Learning " + meTrain.Text);

            nn.LoadFromBMP((Bitmap)pbTest.Image);
            nn.Process();
            nn.Learn(i);

            Log2("Done");
            button5_Click(null, null);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lLog2.Items.Add("Saving... wait...");
            nn.SaveNetwork("net.txt");
            lLog2.Items.Add("Saved on net.txt");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            nn = new NeuralUtility();
            lLog2.Items.Add("Loading... wait...");
            nn.LoadNetwork("net1.txt");
            lLog2.Items.Add("Loaded from net.txt");

            lLog.Items.Clear();

            nn.LogFunction = Log;

            nn.ShowDefinition();

            nn.LogFunction = Log2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            f2.ShowDialog();
        }
    }
}
