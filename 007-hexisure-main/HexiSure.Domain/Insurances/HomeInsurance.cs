using HexiSure.Domain.Insurables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Domain.Insurances
{
    public class HomeInsurance : InsurancePolicy
    {
        public Residence Residence { get; set; }

        public HomeInsurance(double basePremium, int policyNumber, Residence residence) : base(basePremium, policyNumber)
        {
            Residence = residence;
        }

        public void AddHomeFireInsurance()
        {
            AddCoverage(new Coverage(100, "Brandverzekering", Residence));
        }

        public void AddTheftInsurance10K()
        {
            AddCoverage(new Coverage(40, "Diefstalverzekering", Residence));
        }

        public void AddTheftInsurance30K()
        {
            AddCoverage(new Coverage(80, "Diefstalverzekering", Residence));
        }

        public override double CalculateTotalPremiumPerMonth()
        {
            return BasePremium*Residence.CalculateCoverageModifier()*Coverages.Sum(c => c.CostPerMonth);
        }

        public override string ToString()
        {
            return $"Home Insurance: {base.ToString()}";
        }
    }
}
