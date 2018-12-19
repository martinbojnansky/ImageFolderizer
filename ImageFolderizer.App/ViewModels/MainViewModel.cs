using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFolderizer.App.Models;
using ImageFolderizer.App.Services;
using ImageFolderizer.App.Views;
using Windows.UI.Xaml.Navigation;

namespace ImageFolderizer.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IMediaFilesProvider _mediaFilesProvider;

        private ObservableCollection<IMediaFile> _mediaFiles = new ObservableCollection<IMediaFile>();

        public ObservableCollection<IMediaFile> MediaFiles
        {
            get => _mediaFiles;
            set
            {
                _mediaFiles = value;
                RaisePropertyChanged();
            }
        }

        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        private int _thumbnailWidth = 300;

        public int ThumbnailWidth
        {
            get => _thumbnailWidth;
            set
            {
                _thumbnailWidth = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel(IMediaFilesProvider mediaFilesProvider)
        {
            _mediaFilesProvider = mediaFilesProvider;
        }

        public async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await LoadSourceMediaFilesAsync();       
            base.OnNavigatedTo(e);
        }

        public async Task LoadSourceMediaFilesAsync()
        {
            IsBusy = true;
            MediaFiles = new ObservableCollection<IMediaFile>(await _mediaFilesProvider.GetSourceMediaFilesAsync());
            IsBusy = false;
        }

        public void NavigateToSettingsPage()
        {
            Navigation.GoTo(typeof(SettingsView), "This is navigation parameter");
        }
    }
}
