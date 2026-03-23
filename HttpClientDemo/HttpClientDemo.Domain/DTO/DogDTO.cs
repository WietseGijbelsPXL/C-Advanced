using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo.Domain.DTO
{
    public class DogDTO
    {
        public Dictionary<string,List<string>> Message { get; set; }
        public string Status { get; set; }
    }
}
