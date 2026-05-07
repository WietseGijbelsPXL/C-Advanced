using HexiSure.Domain.Insurables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Domain.Insurances
{
    public class Coverage
    {
        private double _baseCostPerMonth;

        public double CostPerMonth
        {
            get { return _baseCostPerMonth*InsuredObject.CalculateCoverageModifier(); }
        }

        public IInsurable? InsuredObject { get; set; }
        public string Name { get; set; }

        public Coverage(double baseCostPerMonth, string name)
        {
            _baseCostPerMonth = baseCostPerMonth;
            Name = name;
        }

        public Coverage(double baseCostPerMonth, string name, IInsurable? insuredObject) : this(baseCostPerMonth, name)
        {
            InsuredObject = insuredObject;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
