using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ImageFolderizer.Core.Navigation;
using ImageFolderizer.App.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ImageFolderizer.App.Models;
using System.Collections.ObjectModel;

namespace ImageFolderizer.App.Views
{
    public sealed partial class MainView : NavigationPage, IView<MainViewModel>
    {
        public MainViewModel ViewModel { get; set; } = ((App)Application.Current).MvvmLocator.ResolveViewModel<MainViewModel>();

        public MainView()
        {
            this.InitializeComponent();
        }

        private void PickMediaFilesGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.PickedMediaFiles = new ObservableCollection<IMediaFile>(PickMediaFilesGridView.SelectedItems.Cast<IMediaFile>());
        }

        private void MoveMediaFilesGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.MediaFilesToMove = new ObservableCollection<IMediaFile>(MoveMediaFilesGridView.SelectedItems.Cast<IMediaFile>());
        }

        private async void PlayMediaButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.IsBusy = true;
            var file = (sender as Button).DataContext as IMediaFile;
            await MediaPlayer.OpenAsync(file);
            ViewModel.IsBusy = false;
        }
    }
}
