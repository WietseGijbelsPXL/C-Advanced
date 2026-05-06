using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Domain.Insurables
{
    public class Car : IInsurable
    {
        public string Brand { get; set; }
        public DateTime DateBuilt { get; set; }
        public double InitialPrice { get; set; }
        public int KmPerYear { get; set; }
        public string LicensePlate { get; set; }
        public int Power { get; set; }


        public double CalculateCoverageModifier()
        {
            int age = DateTime.Now.Year - DateBuilt.Year;
            return InitialPrice / 10000.0 * (KmPerYear / 10000.0) * (Power / 120.0) * (1 - age / 50);
        }
    }
}
