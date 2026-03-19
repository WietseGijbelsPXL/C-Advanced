using SharkAttacks.Domain;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections.Immutable;

namespace SharkAttacks.Infrastructure
{
    public class SharkAttacksRepository
    {

        string ConnectionString = "Server=.\\SQLEXPRESS;Database=SharkAttackDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        public int GetTotalAttacks()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.ExecuteScalar<int>("select count (*) from sharkattacks");
            }
        }

        public int GetFatalAttacks()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.ExecuteScalar<int>("select count (*) from sharkattacks where Fatal = @fatal", new { fatal = "Y" });
            }
        }

        public Dictionary<int, int> GetAttacksByYear()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                Dictionary<int, int> returnDic = new Dictionary<int, int>();
                IEnumerable<int> years = conn.Query<int>("select distinct year from sharkattacks where year != 0");
                foreach (int year in years)
                {
                    int amnoutYear = conn.ExecuteScalar<int>("select count(*) from sharkattacks where year = @year", new { year = year });
                    returnDic.Add(year, amnoutYear);
                }
                return returnDic.OrderBy(x => x.Key).ToDictionary();
            }
        }

        public Dictionary<string, int> GetAttacksByActivity()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                Dictionary<string,int> returnDic = new Dictionary<string,int>();
                IEnumerable<string> activities = conn.Query<string>("select distinct activity from sharkattacks");
                foreach(string activity in activities)
                {
                    int amountActivity = conn.ExecuteScalar<int>("select count(*) from sharkattacks where activity = @activity", new { activity = activity});
                    returnDic.Add(activity, amountActivity);
                }
                return returnDic.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}


