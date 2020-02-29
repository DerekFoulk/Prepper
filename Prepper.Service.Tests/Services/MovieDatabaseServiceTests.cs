using System.Threading.Tasks;
using FluentAssertions;
using Prepper.Service.Services;
using Xunit;

namespace Prepper.Service.Tests.Services
{
    public class MovieDatabaseServiceTests
    {
        [Fact]
        public async Task SearchAsync()
        {
            // Arrange
            var movieDatabaseService = new MovieDatabaseService();

            // Act
            var results = await movieDatabaseService.MovieSearchAsync("Avengers").ConfigureAwait(true);

            // Assert
            results.Should().NotBeEmpty();
        }
    }
}
