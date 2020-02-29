using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prepper.Service.Services
{
    public class MovieDatabaseResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<MovieDatabaseResult> Results { get; set; }
    }
}
