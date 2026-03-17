using Dapper;
using Fruitshop.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fruitshop.Infrastructure
{
    public class FruitRepository
    {
        const string _ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=FruitDb;Data Source=LAPTOP-I21TPKLD\\\\SQLEXPRESS;\r\nTrustServerCertificate=True";

        public IEnumerable<Fruit> LoadAllFruits()
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                conn.Open();
                return conn.Query<Fruit>("SELECT * FROM Fruits");
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                conn.Query<Fruit>("Delete from fruits where id = @ID", new { ID = id });
            }
        }

        public void Update(Fruit fruit)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                conn.Execute("UPDATE Fruits SET Name = @name, Color = @color, Season = @season WHERE Id = @id", fruit);
            }
        }

        public void Add(Fruit fruit) 
        {
            using(SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                conn.Execute("INSERT INTO Fruits (Id, Name, Color, Season) VALUES(@id, @name, @color, @season)", fruit);
            }
        }
    }
}
