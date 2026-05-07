using HexiSure.Domain.Insurables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Domain.Insurances
{
    public class CarInsurance : InsurancePolicy
    {
        public Car Car { get; set; }

        public CarInsurance(double basePremium, int policyNumber, Car car) : base(basePremium, policyNumber)
        {
            Car = car;
        }
        
        public void AddOmnium()
        {
            AddCoverage(new Coverage(95, "Omnium", Car));
        }

        public override string ToString()
        {
            return $"Car Insurance: {base.ToString()}";
        }
    }
}
