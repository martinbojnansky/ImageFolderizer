using ImageFolderizer.Core.Storage;
using ImageFolderizer.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ImageFolderizer.App.Models
{
    public class Settings : PropertyChangedBase, ISettings
    {
        private ILocalObjectStorage _localObjectStorage;

        public string SourceFolder
        {
            get
            {
                try
                {
                    return _localObjectStorage.GetValue<string>(Constants.SourceFolderKey, Constants.SettingsContainerKey);
                }
                catch (KeyNotFoundException)
                {
                    return null;
                }
            }
            set
            {
                _localObjectStorage.SetValue(Constants.SourceFolderKey, value, Constants.SettingsContainerKey);
                RaisePropertyChanged();
            }
        }

        public Settings(ILocalObjectStorage localObjectStorage)
        {
            _localObjectStorage = localObjectStorage;
        }
    }
}
