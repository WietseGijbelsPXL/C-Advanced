using HexiSure.Domain.Insurables;
using HexiSure.Domain.Insurances;
using HexiSure.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Application.Services
{
    public class InsuranceService
    {
        InsuranceRepository _insuranceRepository;

        public InsuranceService(InsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public List<InsurancePolicy> GetAllInsurances()
        {
            return _insuranceRepository.GetAll().ToList();
        }

        public void AddInsurance(InsurancePolicy insurance)
        {
            _insuranceRepository.Add(insurance);
        }

        public List<Municipality> GetMunicipalities()
        {
            MunicipalityData.RetrieveMunicipalities();
            return MunicipalityData.Municipalities;
        }
    }
}
