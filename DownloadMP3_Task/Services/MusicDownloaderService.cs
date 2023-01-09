using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VideoLibrary;

namespace DownloadMP3_Task.Services
{
    public class MusicDownloaderService
    {

        public static DispatcherTimer DispatcherTimer { get; set; }

        public static async void DownloadMusic(YouTubeVideo video)
        {
            var youtube = YouTube.Default;

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var source = $@"{desktopPath}\";


            File.WriteAllBytes(source + video.FullName, await video.GetBytesAsync());
            var inputFile = new MediaFile { Filename = source + video.FullName };
            var outputFile = new MediaFile { Filename = $"{source + video.FullName}.mp3" };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);

                DispatcherTimer.Stop();
                MessageBox.Show("Downloaded Successfully");

            }
        }

    }
}
