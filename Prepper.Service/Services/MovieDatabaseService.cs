using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Prepper.Service.Services
{
    public class MovieDatabaseService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "923a557cb64c9fb40825e0fcdccad9ab";

        public MovieDatabaseService()
        {
            //_httpClient = httpClient;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.themoviedb.org/3/")
            };
        }

        public async Task<IEnumerable<MovieDatabaseResult>> MovieSearchAsync(string name, string year = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value is null or whitespace.", nameof(name));

            var queryParams = new Dictionary<string, string>
            {
                { "api_key", ApiKey },
                { "query", WebUtility.UrlEncode(name) }
            };

            if (!string.IsNullOrWhiteSpace(year))
                queryParams.Add("year", year);

            var uri = QueryHelpers.AddQueryString("search/movie", queryParams);
            
            var response = await _httpClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var movieDatabaseResponse = JsonSerializer.Deserialize<MovieDatabaseResponse>(responseBody);
            var movieDatabaseResults = movieDatabaseResponse.Results;
            
            return movieDatabaseResults;
        }
    }
}
