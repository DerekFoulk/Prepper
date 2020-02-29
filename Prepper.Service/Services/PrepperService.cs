using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Prepper.Service.Services
{
    public class PrepperService : IPrepperService
    {
        private readonly IMovieDatabaseService _movieDatabaseService;

        public PrepperService(IMovieDatabaseService movieDatabaseService)
        {
            _movieDatabaseService = movieDatabaseService;
        }

        public async Task Execute()
        {
            // Settings
            const bool isRenameEnabled = true;
            //const bool isRelocateEnabled = true;

            // Scan libraries for media items
            var libraries = new List<string>
            {
                @"F:\Movies"
            };

            foreach (var library in libraries)
            {
                var directoryInfo = new DirectoryInfo(library);
                var driveInfo = new DriveInfo(directoryInfo.Root.FullName);

                if (isRenameEnabled)
                {
                    var results = await _movieDatabaseService.MovieSearchAsync("Avengers");
                }
            }

            // Outline:
            // 1) Scan libraries for media items
            // 2) Process each media item
            //   A) If renaming is enabled, then use TMDb or IMDb to determine the correct name for the media item
            //     i) Get search results from the database
            //     ii) Compare the database item's metadata to our media item's metadata
            //     iii) Rectify any incorrect metadata in the media item
            //   B) If relocation is enabled and the media item is stored on a drive that is almost full, then determine a better location for the media item
            //     i) Get all drives' information (total size, free space, etc.)
            //     ii) Check if the media item has been moved before to determine a list of relocation candidates
            //       a) If so, when was the media item moved and how many times has it been moved
            //       b) If the media item has been moved a lot (or recently), then it should not be considered for relocation
            //       c) If the media item has not been moved a lot (or recently), then it should be considered for relocation
            //     iii) Move the best relocation candidates to the optimal location
            //     ii) Use the drive information to determine the best place to store the media item
            //     iii)
        }
    }
}