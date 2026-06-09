using Dapper;
using HexiSure.Domain.Insurances;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Infrastructure.Data
{
    public class InsuranceRepository
    {
        public string _connectionstring;

        public InsuranceRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void Add(InsurancePolicy insurance)
        {
            // Vul onderstaande query aan met SqlParameters en voer ze uit.
            
            string query = @"INSERT INTO Insurances (PolicyNumber, CostPerMonth, BasePremium, ClientNumber, Description)
                                VALUES (@PolicyNumber, @CostPerMonth, @BasePremium, @ClientNumber, @Description)";

            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                con.Execute(query,new
                {
                    PolicyNumber = insurance.PolicyNumber,
                    CostPerMonth = insurance.CalculateTotalPremiumPerMonth(),
                    BasePremium = insurance.BasePremium,
                    ClientNumber = insurance.ClientNumber,
                    Description = insurance.ToString(),
                });
            }
        }

        public IEnumerable<InsurancePolicy> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                return con.Query<InsurancePolicy>("SELECT * FROM Insurances");
            }
        }

        private int GetTotalInsurances()
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                return con.ExecuteScalar<int>("select count() * from insurances");
            }
        }

        public int GetNextPolicyNumber()
        {
            return int.Parse($"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{GetTotalInsurances().ToString("0000")}");
            
        }
    }
}
