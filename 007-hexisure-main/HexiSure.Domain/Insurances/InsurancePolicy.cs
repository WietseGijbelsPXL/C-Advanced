using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Domain.Insurances
{
    public abstract class InsurancePolicy
    {
		private List<Coverage> _coverages;

		public List<Coverage> Coverages
		{
			get { return _coverages; }
		}
        public double BasePremium { get; set; }
        public int ClientNumber { get; set; }
        public int PolicyNumber { get; set; }

        protected InsurancePolicy(double basePremium, int policyNumber)
        {
            BasePremium = basePremium;
            PolicyNumber = policyNumber;
        }

        public virtual void AddCoverage(Coverage coverage)
        {
            if (!Coverages.Any( c => c.Name == coverage.Name))
            {
                _coverages.Add(coverage);
            }
        }

        public virtual void RemoveCoverage(Coverage coverage)
        {
            _coverages.Remove(coverage);
        }

        public virtual void AddCivilLiability()
        {
            _coverages.Add(new Coverage(10, "Burgelijke aansprakelijkheid"));
        }

        public virtual void AddLegalAid()
        {
            _coverages.Add(new Coverage(20, "Rechtsbijstand"));
        }

        public virtual double CalculateTotalPremiumPerMonth()
        {
            return Coverages.Sum(c => c.CostPerMonth*BasePremium);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Coverage coverage in Coverages)
            {
                sb.Append($"{coverage.ToString()} ");
            }
            return sb.ToString();
        }
    }
}
