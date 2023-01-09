using DownloadMP3_Task.Commands;
using DownloadMP3_Task.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VideoLibrary;

namespace DownloadMP3_Task.ViewModels.UCViewModels
{
    public class DownloadPanelViewModel:BaseViewModel
    {

        public RelayCommand WaitCommand { get; set; }


        public RelayCommand StartDownloaderCommand { get; set; }

        private string linkText;

        public string URLToDownload
        {
            get { return linkText; }
            set { linkText = value; OnPropertyChanged(); }
        }


        private YouTubeVideo video;

        public YouTubeVideo Video
        {
            get { return video; }
            set { video = value;OnPropertyChanged(); }
        }


        private int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value;OnPropertyChanged(); }
        }

        private DispatcherTimer dispatcherTimer;

        public DownloadPanelViewModel()
        {
            dispatcherTimer = new DispatcherTimer();
            StartDownloaderCommand = new RelayCommand(async (c) =>
            {
                var youtube = YouTube.Default;
                Video = await youtube.GetVideoAsync(linkText);
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer.Tick += DispatcherTimer_Tick;
                dispatcherTimer.Start();
                MusicDownloaderService.DispatcherTimer=dispatcherTimer;
                MusicDownloaderService.DownloadMusic(Video);
                

            }, (a) =>
            {
                if(linkText != null)
                {
                    return true;
                }
                return false;
            });
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Duration += 1;
        }
    }
}
