using DownloadMP3_Task.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
