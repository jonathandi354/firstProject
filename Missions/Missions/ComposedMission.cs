using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions
{
    class ComposedMission : IMission
    {
        public string Name { get; }

        public string Type { get; }
        private List<Func<double, double>> funcs;
        public ComposedMission(string name)
        {
            Name = name;
            Type = "Composed";
            funcs = new List<Func<double, double>>();
        }

        public event EventHandler<double> OnCalculate;
        public ComposedMission Add(Func<double, double> func)
        {
            funcs.Add(func);

            return this;
        }
        public double Calculate(double value)
        {
            double result = value;
            foreach (var func in funcs)
            {

                result = func(result);
            }
            OnCalculate?.Invoke(this, result);
            return result;



        }
    }
}
