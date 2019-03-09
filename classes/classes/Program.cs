using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes
{
    

    class FunctionContainers
    {
        private Dictionary<string, Func<double, double>> hash;
        
        public FunctionContainers()
        {
            hash = new Dictionary<string, Func<double, double>>();
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
    class Program
    {
        static void Main(string[] args)
        {
            FunctionContainers f = new FunctionContainers();
            f["hi"] = x => x * 2;

            Console.WriteLine(f["hi"](3));
        }
    }
}
