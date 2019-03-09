using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions
{
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

        public string Type { get; }

        public SingleMission(string name)
        {
            Name = name;
            Type = "SingleMission";
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            throw new NotImplementedException();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
