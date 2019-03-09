using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class FunctionContainers
    {
        private Dictionary<string, int> hash;

        public FunctionContainers()
        {
            hash = new Dictionary<string, int>();
        }
        public int this[string key]
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
            f["hi"] = 2;
            f["by"] = 3;
            Console.WriteLine(f["hi"]);
        }
    }
}
