using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural1
{
    public enum CONNECTIONS { ALL_IN_ALL };
    public enum ACTIVATION { RELU, LeakRELU, SOFTMAX, SIGMOID };
    public enum LOSS { MSE, CROSS_ENTROPY };


    public class NeuralNetwork : NeuralObject
    {
        public CONNECTIONS connection = CONNECTIONS.ALL_IN_ALL;
        public ACTIVATION activation = ACTIVATION.LeakRELU;
        public LOSS loss = LOSS.MSE;

        public double learnFactor = 0.05;

        public double bias = 0.00;

        public List<Layer> layers;

        public List<double> entry;
        public List<double> output;
        public List<double> expected;

        private int _lastid = 1;

        private int _index;
        public int index { get { return _index; } }

        private double _accuracy;
        public double accuracy { get { return _accuracy; } }

        public int GetNewId()
        {
            return _lastid++;
        }

        public void Learn(int lIndex = -1)
        {
            if (lIndex == -1)
            {
                for (int i = 0; i < layers.Last().Neurons.Count(); i++)
                {
                    switch (layers.Last().Neurons[i].loss)
                    {
                        case LOSS.MSE:
                            layers.Last().Neurons[i].Learn(layers.Last().Neurons[i].output - expected[i]);
                            break;

                        case LOSS.CROSS_ENTROPY:
                            layers.Last().Neurons[i].Learn(layers.Last().Neurons[i].output - expected[i]);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < layers.Last().Neurons.Count(); i++)
                    layers.Last().Neurons[i].Learn(i == lIndex ? layers.Last().Neurons[i].output - 1.00 : layers.Last().Neurons[i].output);
            }

            for (int i = layers.Count - 1; i >= 1; i--)
            {
                for (int j = 0; j < layers[i].Synapses.Count(); j++)
                    layers[i].Synapses[j].Learn();
            }
        }

        public void Process()
        {
            int i = 0;
            Layer last = layers.Last();

            if (layers.Count < 1)
            {
                output.Clear();
                return;
            }

            layers[0].PreCalc();

            for (int j = 0; j < layers[0].Neurons.Count(); j++)
            {
                if (entry.Count >= i)
                    layers[0].Neurons[j].output = entry[i++];
                else
                    layers[0].Neurons[j].output = 0.00;
            }

            i = 0;
            for (int j = 1; j < layers.Count(); j++)
            {
                for (int k = 0; k < layers[j].Synapses.Count(); k++)
                    layers[j].Synapses[k].Process();

                layers[j].PreCalc();

                for (int k = 0; k < layers[j].Neurons.Count(); k++)
                    layers[j].Neurons[k].Process();
            }

            output.Clear();

            _accuracy = 0.00;
            _index = -1;

            for (i = 0; i < last.Neurons.Count(); i++)
            {
                if (last.Neurons[i].output > _accuracy)
                {
                    _index = i;
                    _accuracy = last.Neurons[i].output;
                }

                output.Add(last.Neurons[i].output);
            }
        }

        public NeuralNetwork()
            : base(null, "NeuralNetwork")
        {
            this.Owner = this;

            layers = new List<Layer>();
            entry = new List<double>();
            output = new List<double>();
            expected = new List<double>();
        }

        public void AddLayer(int size)
        {
            Layer newLayer = new Layer(this.Owner);
            newLayer.Add(size, activation, loss, bias);

            if (layers.Count == 0)
            {
                layers.Add(newLayer);
            }
            else
            {
                Layer previousLayer = layers.Last();
                layers.Add(newLayer);

                switch (connection)
                {
                    case CONNECTIONS.ALL_IN_ALL:
                        //previousLayer.Synapses.Clear();

                        foreach (Neuron n1 in previousLayer.Neurons)
                        {
                            foreach (Neuron n2 in newLayer.Neurons)
                            {
                                Synapse s = new Synapse(this.Owner);

                                s.previous = n1;
                                s.next = n2;
                                s.learnFactor = learnFactor;

                                newLayer.Synapses.Add(s);
                            }
                        }

                        break;

                    default:
                        break;
                }
            }
        }

        public void LoadFromCode(List<string> code)
        {
            string s;
            string s2;
            string tag;
            string[] ss;
            string[] ss2;

            Synapse _synapse;
            Neuron _neuron;
            Layer _layer;

            Dictionary<int, NeuralObject> mapping = new Dictionary<int, NeuralObject>();

            int _id = -1;
            string _class = "";
            ACTIVATION _activation = ACTIVATION.SOFTMAX;
            LOSS _loss = LOSS.CROSS_ENTROPY;
            int _father = -1;
            double _bias = 0.00;
            double _weight = 0.00;
            double _learnfactor = 0.00;
            int _previous = -1;
            int _next = -1;

            int maxID = -1;

            for (int i = 0; i < code.Count; i++)
            {
                s = code[i].Trim();
                ss = s.Split('|');

                for (int j = 0; j < ss.Length; j++)
                {
                    s = ss[j].Trim();
                    ss2 = s.Split(':');
                    s = ss2[0].Trim();
                    s2 = ss2[1].Trim();

                    switch (s)
                    {
                        default:
                            throw new System.Exception("unknow parameter");

                        case "ID":
                            if (!int.TryParse(s2, out _id))
                                throw new System.Exception("id not integer");
                            break;

                        case "Class":
                            _class = s2;
                            break;

                        case "Activation":
                            if (!Enum.TryParse<ACTIVATION>(s2, out _activation))
                                throw new System.Exception("invalid activation");
                            break;

                        case "Loss":
                            if (!Enum.TryParse<LOSS>(s2, out _loss))
                                throw new System.Exception("invalid loss");
                            break;

                        case "Bias":
                            if (!double.TryParse(s2, out _bias))
                                throw new System.Exception("bias is not double");
                            break;

                        case "Father":
                            if (!int.TryParse(s2, out _father))
                                throw new System.Exception("father not integer");
                            break;

                        case "Weight":
                            if (!double.TryParse(s2, out _weight))
                                throw new System.Exception("weight is not double");
                            break;

                        case "Learn Factor":
                            if (!double.TryParse(s2, out _learnfactor))
                                throw new System.Exception("learn factor is not double");
                            break;

                        case "Previous":
                            if (!int.TryParse(s2, out _previous))
                                throw new System.Exception("previous not integer");
                            break;

                        case "Next":
                            if (!int.TryParse(s2, out _next))
                                throw new System.Exception("next not integer");
                            break;
                    }
                }

                maxID = maxID < _id ? _id : maxID;
                _lastid = _id;

                switch (_class)
                {
                    case "NeuralNetwork":
                        break;

                    case "Layer":
                        _layer = new Layer(this);
                        _layer.activation = _activation;
                        _layer.loss = _loss;

                        layers.Add(_layer);
                        mapping.Add(_id, _layer);
                        break;

                    case "Neuron":
                        _neuron = new Neuron(this);
                        _neuron.father = (Layer)mapping[_father];
                        _neuron.bias = _bias;
                        _neuron.activation = _activation;
                        _neuron.loss = _loss;

                        layers.Last().Neurons.Add(_neuron);
                        mapping.Add(_id, _neuron);
                        break;

                    case "Synapse":
                        _synapse = new Synapse(this);
                        _synapse.weight = _weight;
                        _synapse.learnFactor = _learnfactor;
                        _synapse.previous = (Neuron)mapping[_previous];
                        _synapse.next = (Neuron)mapping[_next];

                        layers.Last().Synapses.Add(_synapse);
                        mapping.Add(_id, _synapse);
                        break;
                    default:
                        break;
                }
            }

            _lastid = maxID + 1;
        }

        public void Randomize(int min, int max, int exp, bool b = false)
        {
            Random rnd = new Random();
            double _base = Math.Pow(10.00, exp);

            for (int j = 1; j < layers.Count(); j++)
            {
                for (int k = 0; k < layers[j].Synapses.Count(); k++)
                    layers[j].Synapses[k].weight = ((double)rnd.Next(min, max)) * _base;

                if (b)
                {
                    for (int k = 0; k < layers[j].Neurons.Count(); k++)
                        layers[j].Neurons[k].bias = ((double)rnd.Next(min, max)) * _base;
                }
            }
        }
    }

    public class Layer : NeuralObject
    {
        public List<Synapse> Synapses;
        public List<Neuron> Neurons;

        public ACTIVATION activation;
        public LOSS loss;

        private double _sumEZKSoftMax = 0.00;
        public double sumEZKSoftMax { get { return _sumEZKSoftMax; } }

        private double _MaxZ = 0.00;
        public double MaxZ { get { return _MaxZ; } }

        public double delta;

        public Layer(NeuralNetwork _Owner = null)
            : base(_Owner, "Layer")
        {
            Synapses = new List<Synapse>();
            Neurons = new List<Neuron>();
        }

        public void PreCalc()
        {
            switch (activation)
            {
                case ACTIVATION.SOFTMAX:
                    if (Neurons != null)
                    {
                        _sumEZKSoftMax = 0.00;

                        _MaxZ = Neurons[0].entry;

                        for (int i = 1; i < Neurons.Count; i++)
                            _MaxZ = _MaxZ >= Neurons[i].entry ? _MaxZ : Neurons[i].entry;

                        for (int i = 0; i < Neurons.Count; i++)
                            _sumEZKSoftMax += Math.Exp(Neurons[i].entry - _MaxZ);
                    }
                    break;
            }
        }

        public void Add(int size, ACTIVATION a, LOSS l, double bias)
        {
            activation = a;
            loss = l;

            for (int i = 0; i < size; i++)
            {
                Neuron n = new Neuron(this.Owner);
                n.activation = activation;
                n.loss = loss;
                n.bias = bias;
                n.father = this;

                Neurons.Add(n);
            }
        }
    }

    public class NeuralObject
    {
        private int _id;
        public int id { get { return _id; } }

        public NeuralNetwork Owner;

        private string _ClassName;
        public string ClassName { get { return _ClassName; } }

        public NeuralObject(NeuralNetwork _Owner = null, string __ClassName = "NeuralObject")
        {
            Owner = _Owner;

            if (Owner != null)
                _id = Owner.GetNewId();

            _ClassName = __ClassName;
        }

        public string GenerateSaveCode(List<string> values = null, int tab = 0)
        {
            string value = "";

            for (int i = 1; i < tab; i++)
                value += " ";

            value += "ID: " + this._id.ToString() + " | Class: " + _ClassName;

            if (Owner == null)
                return "";

            switch (_ClassName)
            {
                case "Synapse":
                    Synapse oSynapse = (Synapse)this;

                    value += " | Weight: " + oSynapse.weight.ToString();
                    value += " | Learn Factor: " + oSynapse.learnFactor.ToString();
                    value += " | Previous: " + oSynapse.previous.id.ToString();
                    value += " | Next: " + oSynapse.next.id.ToString();

                    if (values != null)
                        values.Add(value);

                    value += "\n";
                    break;

                case "Neuron":
                    Neuron oNeuron = (Neuron)this;

                    value += " | Father: " + oNeuron.father.id.ToString();
                    value += " | Bias: " + oNeuron.bias.ToString();
                    value += " | Activation: " + oNeuron.activation.ToString();
                    value += " | Loss: " + oNeuron.loss.ToString();

                    if (values != null)
                        values.Add(value);

                    value += "\n";
                    break;

                case "Layer":
                    Layer oLayer = (Layer)this;

                    value += " | Activation: " + oLayer.activation.ToString();
                    value += " | Loss: " + oLayer.loss.ToString();

                    if (values != null)
                        values.Add(value);

                    value += "\n";

                    foreach (Neuron item in oLayer.Neurons)
                        value += item.GenerateSaveCode(values, tab + 4);

                    foreach (Synapse item in oLayer.Synapses)
                        value += item.GenerateSaveCode(values, tab + 4);

                    break;

                case "NeuralNetwork":
                    NeuralNetwork oNeuralNetwork = (NeuralNetwork)this;

                    if (values != null)
                        values.Add(value);

                    value += "\n";

                    foreach (Layer item in oNeuralNetwork.layers)
                        value += item.GenerateSaveCode(values, tab + 4);

                    break;
            }

            return value;
        }
    }

    public class Neuron : NeuralObject
    {
        public Layer father = null;
        public double entry;

        public double delta = 0.00;

        private double _body = 0.00;
        public double body { get { return _body; } }

        public double bias = 0.00;

        public ACTIVATION activation = ACTIVATION.RELU;
        public LOSS loss = LOSS.MSE;

        private static double ALPHA = 0.01;

        private double sWeight = 0.00;
        private double gWeight = 0.00;
        public double getWeight { get { return gWeight; } }

        public Neuron(NeuralNetwork _Owner = null)
            : base(_Owner, "Neuron")
        {
        }

        public void AddWeight(double w)
        {
            sWeight += w;
        }

        public void Process()
        {
            switch (activation)
            {
                case ACTIVATION.RELU:
                    output = (entry + bias < 0.00 ? 0.00 : entry + bias);
                    break;

                case ACTIVATION.LeakRELU:
                    output = (entry + bias < 0.00 ? ALPHA * (entry + bias) : entry + bias);
                    break;

                case ACTIVATION.SIGMOID:
                    output = 1.00 / (1 + Math.Exp(-(entry + bias)));
                    break;

                case ACTIVATION.SOFTMAX:
                    output = Math.Exp(entry - father.MaxZ) / father.sumEZKSoftMax;
                    break;

                default:
                    output = 0.00;
                    break;
            }

            _body = entry;
            entry = 0.00;

            gWeight = sWeight;
            sWeight = 0.00;
        }

        public void Learn(double frontDeltaW)
        {

            switch (activation)
            {
                case ACTIVATION.RELU:
                    // calc delta
                    switch (loss)
                    {
                        case LOSS.MSE:
                            //delta = (output - frontDeltaW) * (1 - output);
                            delta = 0;
                            break;

                        default:
                            throw new System.Exception("iteration not implemented: " + activation.ToString() + " + " + loss.ToString());
                    }
                    break;

                case ACTIVATION.LeakRELU:
                    // calc delta
                    switch (loss)
                    {
                        default:
                            throw new System.Exception("iteration not implemented: " + activation.ToString() + " + " + loss.ToString());
                    }
                    break;

                case ACTIVATION.SOFTMAX:
                    // calc delta
                    switch (loss)
                    {
                        case LOSS.CROSS_ENTROPY:
                            if (father.id == Owner.layers.Last().id)
                                delta = frontDeltaW;
                            else
                                delta = frontDeltaW * output * (1 - output);
                            break;

                        default:
                            throw new System.Exception("iteration not implemented: " + activation.ToString() + " + " + loss.ToString());
                    }
                    break;
                case ACTIVATION.SIGMOID:
                    // calc delta
                    switch (loss)
                    {
                        case LOSS.MSE:
                            delta = frontDeltaW * output * (1 - output);
                            break;

                        default:
                            throw new System.Exception("iteration not implemented: " + activation.ToString() + " + " + loss.ToString());
                    }
                    break;

                default:
                    throw new System.Exception("iteration not implemented: " + activation.ToString() + " + " + loss.ToString());
            }
        }

        public double output;
    }

    public class Synapse : NeuralObject
    {
        public double weight = 0.00;
        public double learnFactor = 0.50; // learn factor

        public Neuron previous = null;
        public Neuron next = null;

        public Synapse(NeuralNetwork _Owner = null)
            : base(_Owner, "Synapse")
        {
        }

        public void Process()
        {
            if (previous == null || next == null)
                return;

            next.AddWeight(weight);
            next.entry += previous.output * weight;
        }

        public void Learn()
        {
            if (previous == null || next == null)
                return;                        
            
            next.bias -= learnFactor * next.delta;
            weight -= learnFactor * next.delta * previous.output;
            previous.Learn(next.delta * next.getWeight);
        }
    }
}
