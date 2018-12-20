using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ImageFolderizer.App.Models;
using ImageFolderizer.App.Services;
using ImageFolderizer.App.Views;
using Windows.Storage.Pickers;
using Windows.UI.Core;
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

        private ObservableCollection<IMediaFile> _pickedMediaFiles = new ObservableCollection<IMediaFile>();

        public ObservableCollection<IMediaFile> PickedMediaFiles
        {
            get => _pickedMediaFiles;
            set
            {
                _pickedMediaFiles = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<IMediaFile> _mediaFilesToMove = new ObservableCollection<IMediaFile>();

        public ObservableCollection<IMediaFile> MediaFilesToMove
        {
            get => _mediaFilesToMove;
            set
            {
                _mediaFilesToMove = value;
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

        private double _thumbnailWidth = 500.00;

        public double ThumbnailWidth
        {
            get => _thumbnailWidth;
            set
            {
                _thumbnailWidth = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ThumbnailMaxHeight));
            }
        }

        public double ThumbnailMaxHeight => ThumbnailWidth * 1.18;

        public MainViewModel(IMediaFilesProvider mediaFilesProvider)
        {
            _mediaFilesProvider = mediaFilesProvider;
        }

        public async override void OnNavigatedTo(NavigationEventArgs e)
        { 
            base.OnNavigatedTo(e);

            try
            {
                await LoadSourceMediaFilesAsync();
            }
            catch
            {
                IsBusy = false;
            }
        }

        public async Task LoadSourceMediaFilesAsync()
        {
            //IsBusy = true;
            await _mediaFilesProvider.LoadSourceMediaFilesToAsync(MediaFiles);
            //IsBusy = false;
        }

        public async Task MoveFilesAsync()
        {
            var picker = CreateFolderPicker();
            var folder = await picker.PickSingleFolderAsync();

            if(folder == null)
            {
                return;
            }

            foreach (var file in MediaFilesToMove)
            {
                await file.File.MoveAsync(folder);
                MediaFiles.Remove(file);
                PickedMediaFiles.Remove(file);
                MediaFilesToMove.Remove(file);
            }
        }

        private FolderPicker CreateFolderPicker()
        {
            var picker = new FolderPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            return picker;
        }

        public void NavigateToSettingsPage()
        {
            Navigation.GoTo(typeof(SettingsView));
        }
    }
}
