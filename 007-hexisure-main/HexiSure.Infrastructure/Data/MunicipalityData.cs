using HexiSure.Domain.Insurables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HexiSure.Infrastructure.Data
{

    public static class MunicipalityData
    {
        public static List<Municipality> Municipalities { get; set; } = new List<Municipality>();

        public static void RetrieveMunicipalities()
        {
            using (StreamReader sr = new StreamReader("files/postal-codes-belgium.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] values = line.Split(",");

                    if (!string.IsNullOrWhiteSpace(values[2]))
                    {
                        Municipality m = new Municipality(int.Parse(values[0]), values[2]);
                        Municipalities.Add(m);
                    }
                    else if (!string.IsNullOrWhiteSpace(values[3]))
                    {
                        Municipality m = new Municipality(int.Parse(values[0]), values[3]);
                        Municipalities.Add(m);
                    }
                    else
                    {
                        Municipality m = new Municipality(int.Parse(values[0]), values[3]);
                        Municipalities.Add(m);
                    }

                }
            }
        }
    }
}
