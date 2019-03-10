﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions
{
    public class Args : EventArgs
    {
        public Double value { get; set; }
        public Func<double, double> func { get; set; }
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
        private double result;
        public string Type { get; }
        private Func<double, double> func;

        public void MyFunc(object sender, double value)
        {
            result = func(value);
        }

        public SingleMission(Func<double, double> func, string name)
        {
            this.func = func;
            Name = name;
            Type = "SingleMission";
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            OnCalculate += MyFunc;
            OnCalculate(this, value);
            return result;


            
        }
    }


    class Program
    {
        
        static void Main(string[] args)
        {


        }
    }
}
