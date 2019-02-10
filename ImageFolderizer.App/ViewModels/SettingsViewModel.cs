using ImageFolderizer.App.Models;
using ImageFolderizer.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ImageFolderizer.App.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ISettings Settings { get; set; }

        public SettingsViewModel()
        {
        }

        public async Task SelectSourceFolderAsync()
        {
            var picker = CreateFolderPicker();
            var folder = await picker.PickSingleFolderAsync();

            Settings.SourceFolder = folder.Path;
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

        public void NavigateToMainView()
        {
            Navigation.GoTo(typeof(MainView));
        }
    }
}
