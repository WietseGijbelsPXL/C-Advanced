using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Clients.Models
{
    internal class OpenLibraryBookDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("authors")]
        public List<OpenLibraryAuthorDto> Authors { get; set; }

        [JsonPropertyName("subjects")]
        public List<OpenLibrarySubjectDto> Subjects { get; set; }

        [JsonPropertyName("publish_date")]
        public string PublishDate { get; set; }
    }
}
