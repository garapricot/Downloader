using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            //uris for downlaod
            var uris = new string[]
            {
                "http://www.dataart.com/",
                "https://www.dataart.com/assets/css/main.css",
                "https://www.dataart.com/assets/js/bundle.js?",
                "https://a.quora.com/qevents.js",
                "https://www.dataart.com/js/vendors/modernizr.min.js",
                "https://bat.bing.com/bat.js",
                "https://cdn.polyfill.io/v2/polyfill.js",
                "https://en.wikipedia.org/wiki/Steadicam",
                "https://en.wikipedia.org/wiki/Spidercam",
                "https://en.wikipedia.org/wiki/United_States",
                "https://en.wikipedia.org/wiki/List_of_United_States_cities_by_population"
            };

            //parallel foreach with maximum numbers of concurrent threads 10
            var tasks = Parallel.ForEach(
                uris,
                new ParallelOptions { MaxDegreeOfParallelism = 10 },
                uri => { DownlaodContent(uri); });

            if (tasks.IsCompleted)
                Console.WriteLine("Finished");
        }

        /// <summary>
        /// Downlaod Content
        /// </summary>
        /// <param name="uri">input URL</param>
        public static void DownlaodContent(string uri)
        {
            using (var client = new WebClient())
            {
                Console.WriteLine($"starting to download {uri}");
                string result = client.DownloadString((string)uri);
                Console.WriteLine(result);
                Console.WriteLine($"finished downloading {uri}");
            }
        }
    }
}
