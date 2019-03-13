using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions
{
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
}
