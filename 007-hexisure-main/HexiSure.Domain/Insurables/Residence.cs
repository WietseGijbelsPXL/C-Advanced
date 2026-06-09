using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Domain.Insurables
{
    public class Residence : IInsurable
    {
        public string Address { get; set; }
        public DateTime DateBuilt { get; set; }
        public double LivingArea { get; set; }
        public double MarketValue { get; set; }
        public Municipality Municipality { get; set; }
        private string _type;

        string[] PossibleTypes = ["Open", "Half open", "Gesloten", "Appartement"];

        public string Type
        {
            get { return _type; }
            set
            {
                if (PossibleTypes.Contains(value))
                {
                    _type = value;
                }
                else
                {
                    throw new Exception("Enkel Open, Half open, Gesloten en Appartement zijn toegestaan");
                }
            }
        }

        public Residence(string address, DateTime dateBuilt, double livingArea, double marketValue, Municipality municipality, string type)
        {
            Address = address;
            DateBuilt = dateBuilt;
            LivingArea = livingArea;
            MarketValue = marketValue;
            Municipality = municipality;
            Type = type;
        }

        public double CalculateCoverageModifier()
        {
            int age = (int)(DateTime.Now - DateBuilt).TotalDays / 365;
            double ageFactor = 1 - Math.Min(age / 50.0, 0.5);
            double sizeFactor = Math.Max(Math.Min(LivingArea / 100.0, 2.0), 0.7);
            double valueFactor = Math.Min(Math.Max(MarketValue / 250000, 0.7), 3.0);
            return ageFactor * sizeFactor * valueFactor;
        }
    }
}
