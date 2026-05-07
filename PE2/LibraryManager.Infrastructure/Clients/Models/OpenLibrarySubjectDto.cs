using System.Text.Json.Serialization;

namespace LibraryManager.Infrastructure.Clients.Models
{
    internal class OpenLibrarySubjectDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
