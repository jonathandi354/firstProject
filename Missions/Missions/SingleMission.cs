﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions
{
    class SingleMission : IMission
    {
        public string Name { get; }
        public string Type { get; }
        private Func<double, double> func;

        

        public SingleMission(Func<double, double> func, string name)
        {
            this.func = func;
            Name = name;
            Type = "Single";
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
