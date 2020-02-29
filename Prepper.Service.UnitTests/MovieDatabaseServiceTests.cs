using FluentAssertions;
using Prepper.Service.Services;
using System.Threading.Tasks;
using Xunit;

namespace Prepper.Service.UnitTests
{
    public class MovieDatabaseServiceTests
    {
        [Fact]
        public async Task SearchAsync()
        {
            // Arrange
            var movieDatabaseService = new MovieDatabaseService();

            // Act
            var results = await movieDatabaseService.MovieSearchAsync("Avengers");

            // Assert
            results.Should().NotBeEmpty();
        }
    }
}
