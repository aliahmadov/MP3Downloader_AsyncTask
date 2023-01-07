using DownloadMP3_Task.Commands;
using DownloadMP3_Task.ViewModels.UCViewModels;
using DownloadMP3_Task.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DownloadMP3_Task.ViewModels
{
    public class MainViewModel:BaseViewModel
    {

        public WrapPanel WrapPanel { get; set; }

        public RelayCommand AddDownloaderCommand { get; set; }



        public MainViewModel()
        {
            AddDownloaderCommand = new RelayCommand(c =>
            {
                var view = new DownloadPanelUC();
                var viewModel = new DownloadPanelViewModel();
                view.DataContext = viewModel;

                view.Margin = new Thickness(10, 40, 10, 10);

                WrapPanel.Children.Add(view);
            });
        }
    }
}
