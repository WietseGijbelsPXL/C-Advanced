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

        public void AddCoverage(Coverage coverage)
        {
            if (!Coverages.Contains(coverage))
            {
                Coverages.Add(coverage);
            }
        }

        public void RemoveCoverage(Coverage coverage)
        {
            Coverages.Remove(coverage);
        }
    }
}
