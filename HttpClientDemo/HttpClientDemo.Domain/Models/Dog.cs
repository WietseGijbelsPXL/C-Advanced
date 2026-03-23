using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo.Domain.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public string? SubBreed { get; set; }

        public override string ToString()
        {
            return SubBreed==null ? $"{Name}" : $"{Name} {SubBreed}";
        }
    }
}
