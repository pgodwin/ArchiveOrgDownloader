using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using MoreLinq;


namespace ArchiveOrgDownloader
{
    class Program
    {
        static int Main(string[] args)
        {
            string outputDir = args[0];
            var urlString = args[1];
                            
            var url = new Uri(urlString);

            if (urlString.Contains("/details/"))
            {
                Console.WriteLine("Found /details/ link.");
                // grab the last segment
                var folder = url.Segments.Last();
                var newUrl = url.ToString().Replace("/details/", "/download/").TrimEnd('/') + "/" + folder.TrimEnd('/') + "_meta.xml";
                url = new Uri(newUrl);
                Console.WriteLine($"New Url: {newUrl}");
            }

            var baseUri = new Uri(url, ".");
            var baseUrl = baseUri.ToString();
            var meta = XmlMethods.DeserialiseXml<XmlModels.Metadata>(url.ToString());

            if (!baseUri.ToString().StartsWith("http"))
                baseUrl = baseUri.LocalPath;

            var filesUrl = baseUrl  + meta.Identifier + "_files.xml";


            
            var files = XmlMethods.DeserialiseXml<XmlModels.Files>(filesUrl);

            Console.WriteLine("Title: " + meta.Title);
            Console.WriteLine("Date: " + meta.Date);
            Console.WriteLine("Description: " + meta.Venue);

            var formats = new string[]
            {
                "Shorten", "Flac", "24bit Flac"
            };

            outputDir = Path.Combine(outputDir, meta.Title);

            foreach (char c in System.IO.Path.GetInvalidPathChars())
                outputDir = outputDir.Replace(c, '_');
            
            Directory.CreateDirectory(outputDir);

            var fileList = files.File.Where(f => formats.Contains(f.Format)).ToList();

            if (fileList.All(f => string.IsNullOrEmpty(f.Track)))
            {
                Console.WriteLine("No track numbers found. Making them based on filename");
                int counter = 1;
                foreach (var file in fileList.OrderBy(t => t.Name))
                {
                    Console.WriteLine($"{file.Name} => {counter.ToString("D2")}");
                    file.Track = counter.ToString("D2");
                    counter++;
                }

            }

            fileList = fileList.OrderBy(t => t.Track.PadLeft(2, '0')).ToList();


            fileList.AsParallel().WithDegreeOfParallelism(Math.Min(fileList.Count(), 5)).ForAll(file =>
            {
                
                    var fileUrl = baseUrl + file.Name;
                    var outfile = file.Track.PadLeft(2, '0') + " - " + (file.Creator ?? meta.Creator) + " - " + (file.Title ?? file.Name) + ".mp3";
                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                        outfile = outfile.Replace(c, '_');

                    var outPath = Path.Combine(outputDir, outfile);

                    Console.WriteLine($"Converting {file.Name} - {file.Track} - {file.Title}");

                    var ffmpeg = new Process(); //Process.Start($@".\helpers\ffmpeg.exe");
                    ffmpeg.StartInfo =
                        new ProcessStartInfo(".\\helpers\\ffmpeg.exe", $"-y -i \"{fileUrl}\" -aq 1  \"{outPath}\"");
                    ffmpeg.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    ffmpeg.Start();

                    ffmpeg.WaitForExit();

                    var mp3 = TagLib.File.Create(outPath);
                    mp3.Tag.Track = (uint) int.Parse(file.Track ?? "0");
                    mp3.Tag.Album = meta.Title ?? meta.Identifier;
                    mp3.Tag.Performers = new [] {file.Creator ?? "" };
                    mp3.Tag.AlbumArtists = files.File.Select(f => f.Creator ?? "").Distinct().ToArray();
                    mp3.Tag.Title = file.Title ?? "";
                    mp3.Tag.Year = (uint) int.Parse(meta.Year ?? "00");
                    mp3.Tag.Comment = meta.Source ?? meta.Description ?? "";
                    mp3.Tag.DiscCount = (uint) int.Parse(meta.Discs ?? "0");
                    mp3.Tag.Genres = new [] { meta.Subject ?? ""};
                    
                    mp3.Save();

                    //ffmpeg - i "$f" - aq 1 "${f%flac}mp3";
                
            });
            

            return 0;
        }
    }
}
