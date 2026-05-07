using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Domain
{
    public interface IInsurable
    {
        decimal CalculateInsuranceCost(int days);

        string GetInsuranceType();
    }
}
