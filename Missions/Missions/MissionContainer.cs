using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions
{
    class FunctionsContainer
    {
        private Dictionary<string, Func<double, double>> hash;
        //private Dictionary<string, EventHandler> hash;


        public FunctionsContainer()
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
                if (hash.ContainsKey(key))
                {
                    hash[key] = value;
                }
                else
                {
                    hash.Add(key, value);
                }

            }
        }
    }
}
