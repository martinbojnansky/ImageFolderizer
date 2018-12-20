﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ImageFolderizer.App.Models;
using ImageFolderizer.App.Services;
using ImageFolderizer.App.Views;
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
            }
        } 

        public MainViewModel(IMediaFilesProvider mediaFilesProvider)
        {
            _mediaFilesProvider = mediaFilesProvider;
        }

        public async override void OnNavigatedTo(NavigationEventArgs e)
        { 
            base.OnNavigatedTo(e);
            await LoadSourceMediaFilesAsync();
        }

        public async Task LoadSourceMediaFilesAsync()
        {
            IsBusy = true;
            MediaFiles = new ObservableCollection<IMediaFile>(await _mediaFilesProvider.GetSourceMediaFilesAsync());
            IsBusy = false;

            foreach (var file in MediaFiles)
            {
                await file.UpdateThumbnailAsync((uint)ThumbnailWidth);
            }
        }

        public void NavigateToSettingsPage()
        {
            Navigation.GoTo(typeof(SettingsView));
        }
    }
}
