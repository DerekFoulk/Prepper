using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prepper.Service.Services
{
    public interface IMovieDatabaseService
    {
        Task<IEnumerable<MovieDatabaseResult>> MovieSearchAsync(string name, string year = null);
    }
}