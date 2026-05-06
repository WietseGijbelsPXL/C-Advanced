using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Domain.Insurables
{
    public interface IInsurable
    {
        double CalculateCoverageModifier();
    }
}
