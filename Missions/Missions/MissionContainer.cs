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


        public FunctionsContainer()
        {
            hash = new Dictionary<string, Func<double, double>>();
        }
        public Func<double, double> this[string key]
        {
            get
            {
                if (!hash.ContainsKey(key))
                {
                    if (key.Equals("Stam"))
                    {
                        hash["Stam"] = x => x;
                    }
                }
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
        public List<string> getAllMissions()
        {
            List<string> list = new List<string>();
           foreach(var name in hash)
            {
                list.Add(name.Key);
            }
            return list;
        }
    }
}
