using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Neural1
{
    delegate void LOGF(string s);

    class NeuralUtility : NeuralNetwork
    {
        public LOGF LogFunction = null;

        private void Log(string s)
        {
            if (LogFunction != null)
                LogFunction(s);
        }

        public void ShowDefinition()
        {
            Layer l;
            string s;

            Log("Current Neural Network:");
            Log("");
            for (int i = 0; i < layers.Count; i++)
            {
                l = layers[i];

                Log("    Layer " + (i + 1).ToString() + " -");
                Log("        Synapses: " + l.Synapses.Count.ToString());
                Log("        Neurons: " + l.Neurons.Count.ToString());
                Log("        Activation: " + l.activation.ToString());
                Log("        Loss: " + l.loss.ToString());

                if (l.Synapses.Count > 0)
                    Log("        Learn Factor: " + l.Synapses[0].learnFactor.ToString());

                Log("");
            }

        }

        public void trainningFromDirectoryLayout1(string directory, string trainningFile, int start, int finish)
        {
            string line;
            string imgFile;
            string sExpected;
            int iExpected;
            int cursor;

            Log("Staring trainning...");
            Log("Directory: " + directory);
            Log("Trainning File: " + trainningFile);

            System.IO.StreamReader file = new System.IO.StreamReader(directory + @"\" + trainningFile);
            line = file.ReadLine();

            for (cursor = 1; cursor <= start; cursor++)
                file.ReadLine();

            while ((line = file.ReadLine()) != null && cursor <= finish)
            {
                cursor++;

                imgFile = line.Split(',')[0];
                sExpected = line.Split(',')[1];

                Log("Image: " + imgFile);
                Log("Cursor: " + cursor.ToString() + " of " + finish.ToString());
                Log("");
                Log("Expected: " + sExpected);

                LoadFromFile(directory + @"\" + imgFile);
                Process();

                iExpected = 0;
                int.TryParse(sExpected, out iExpected);

                Learn(iExpected);

                LogResultLayout1();
            }

            file.Close();
        }

        public void LoadNetwork(string file)
        {
            List<string> netstr = new List<string>();
            string line;

            System.IO.StreamReader _file = new System.IO.StreamReader(file);

            while ((line = _file.ReadLine()) != null)
                netstr.Add(line);

            _file.Close();

            LoadFromCode(netstr);
        }

        public void SaveNetwork(string file)
        {
            List<string> netstr = new List<string>();

            GenerateSaveCode(netstr);

            System.IO.StreamWriter _file = new System.IO.StreamWriter(file);

            foreach (string s in netstr)
                _file.WriteLine(s);

            _file.Close();
        }

        public void testFromDirectoryLayout1(string directory, string TestFile, int start, int finish)
        {
            string line;
            string imgFile;
            string sExpected;
            int iExpected;
            int cursor;

            int total_tests = 0;
            int success = 0;
            float fSuccess;

            Log("Staring test...");
            Log("Directory: " + directory);
            Log("Test File: " + TestFile);
            Dictionary<int, int> partial = new Dictionary<int, int>();

            System.IO.StreamReader file = new System.IO.StreamReader(directory + @"\" + TestFile);
            line = file.ReadLine();

            for (cursor = 1; cursor <= start; cursor++)
                file.ReadLine();

            while ((line = file.ReadLine()) != null && cursor <= finish)
            {
                cursor++;

                imgFile = line.Split(',')[0];
                sExpected = line.Split(',')[1];

                Log("Image: " + imgFile);
                Log("Cursor: " + cursor.ToString() + " of " + finish.ToString());
                Log("");


                LoadFromFile(directory + @"\" + imgFile);

                Process();

                total_tests++;

                iExpected = 0;
                int.TryParse(sExpected, out iExpected);

                if (!partial.ContainsKey(index))
                    partial.Add(index, 0);

                partial[index]++;

                if (index == iExpected)
                    success++;

                fSuccess = ((float)success) / ((float)total_tests);

                fSuccess = fSuccess * 100.0f;

                Log("Tests: " + total_tests.ToString());
                Log("Success (%): " + fSuccess);
                Log("");
                Log("Results:");

                foreach (KeyValuePair<int, int> item in partial.OrderBy(x => x.Key))
                {
                    Log(item.Key.ToString() + ": " + item.Value.ToString());
                }

                Log("");
                Log("Expected: " + sExpected);
                LogResultLayout1();
            }

            file.Close();
        }

        public void LogResultLayout1()
        {
            Log("Result: " + index.ToString());
            Log("Accuracy: " + layers.Last().Neurons[index].output.ToString("0.0000"));
        }

        public void LoadFromBMP(Bitmap image1)
        {
            int x, y;
            int colori;
            Color pixelColor;

            entry.Clear();


            // Loop through the images pixels to reset color.
            for (x = 0; x < image1.Width; x++)
            {
                for (y = 0; y < image1.Height; y++)
                {
                    pixelColor = image1.GetPixel(x, y);
                    colori = pixelColor.R + pixelColor.G + pixelColor.B;
                    colori = colori / 3;

                    entry.Add(((double)colori) / 255.00);
                }
            }
        }

        public void LoadFromFile(string file, bool createFirstLayer = false)
        {
            try
            {
                Bitmap image1 = new Bitmap(file, true);

                if (createFirstLayer)
                {
                    layers.Clear();
                    AddLayer(image1.Width * image1.Height);
                }

                LoadFromBMP(image1);

            }
            catch
            {
            }
        }
    }
}
