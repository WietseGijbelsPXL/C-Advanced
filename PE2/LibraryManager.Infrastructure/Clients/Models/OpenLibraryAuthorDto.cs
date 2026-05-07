using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Clients.Models
{
    internal class OpenLibraryAuthorDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
