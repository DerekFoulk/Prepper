using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Prepper.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // Settings
                var isRenameEnabled = true;
                var isRelocateEnabled = true;

                // Scan libraries for media items
                var libraries = new List<string> {
                    @"F:\Movies"
                };

                foreach (var library in libraries)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(library);
                    DriveInfo driveInfo = new DriveInfo(directoryInfo.Root.FullName);

                    if (isRenameEnabled)
                    {

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

                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }
        }
    }
}
