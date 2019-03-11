using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions
{
    
    class FunctionContainers
    {
            private Dictionary<string, Func<double, double>> hash;
            //private Dictionary<string, EventHandler> hash;
            public FunctionContainers()
            {
                hash = new Dictionary<string, Func<double, double>>();
                //hash = new Dictionary<string, EventHandler>();
            }
            public Func<double, double> this[string key]
            {
                get
                {
                    return hash[key];
                }
                set
                {
                    hash.Add(key, value);
                }
            }
    }
    
    public interface IMission
    {
        event EventHandler<double> OnCalculate; // An Event of when a mission is activated
        String Name { get; }
        String Type { get; }
        double Calculate(double value);
    }
    class SingleMission : IMission
    {
        public string Name { get; }
        //private double result;
        public string Type { get; }
        private Func<double, double> func;

        /*public void MyFunc(object sender, double value)
        {
            result = func(value);
        }*/

        public SingleMission(Func<double, double> func, string name)
        {
            this.func = func;
            Name = name;
            Type = "SingleMission";
            //OnCalculate += MyFunc;
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            double result = func(value);
            OnCalculate?.Invoke(this, result);
            return result;
            
        }
    }

    class ComposedMission : IMission
    {
        public string Name { get; }

        public string Type { get; }
        private List<Func<double, double>> funcs;
        public ComposedMission(string name)
        {
            Name = name;
            Type = "ComposedMission";
            funcs = new List<Func<double, double>>();
        }

        public event EventHandler<double> OnCalculate;
        public ComposedMission Add(Func<double ,double> func)
        {
            funcs.Add(func);

            return this;
        }
        public double Calculate(double value)
        {
            double result = value;
            foreach(var func in funcs)
            {

                result = func(result);
            }
            OnCalculate?.Invoke(this, result);
            return result;
            
                
                                                  
        }
    }


    class Program
    {
        
        static void Main(string[] args)
        {
            
            
            FunctionContainers containers = new FunctionContainers();
            containers["func1"] = x=>x*2;
            containers["func2"] = x=>x+3;

            SingleMission s = new SingleMission(containers["func1"], "hi");
            Console.WriteLine(s.Calculate(3));
            ComposedMission c = new ComposedMission("by");
            c.Add(containers["func1"]).Add(containers["func2"]);
            Console.WriteLine(c.Calculate(2));
            Console.ReadLine();
        }
    }
}
