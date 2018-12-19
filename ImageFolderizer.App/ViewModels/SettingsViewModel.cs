using ImageFolderizer.App.Models;
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

        public async Task SelectDestinationFolderAsync()
        {
            var picker = CreateFolderPicker();
            var folder = await picker.PickSingleFolderAsync();

            Settings.DestinationFolder = folder.Path;
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
    }
}
