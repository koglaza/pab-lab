using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Server
{
    public class ProgressorService
    {
        private readonly ILogger _logger;

        public ProgressorService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ProgressorService>();
        }

        public async Task RunHistory()
        {
            var monarches = await File.ReadAllLinesAsync("Monarchs-of-England.txt");

            var processedMonarches = new List<string>();
            for (int i = 0; i < monarches.Length; i++)
            {
                // Simulate complex work
                await Task.Delay(TimeSpan.FromSeconds(0.2));

                var monarch = monarches[i];

                // Add monarch to final results
                _logger.LogInformation("Adding {Monarch}", monarch);
                processedMonarches.Add(monarch);

                // Calculate and send progress
                var progress = (i + 1) / (double)monarches.Length;
                var progressPercentage = progress * 100;

                // TODO return the progress
            }

            _logger.LogInformation("History complete. Returning {Count} monarchs.", processedMonarches.Count);

            // TODO Send final result

        }
    }
}
