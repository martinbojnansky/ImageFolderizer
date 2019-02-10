using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.Storage;

namespace ImageFolderizer.App.Models
{
    public interface ISettings : INotifyPropertyChanged
    {
        string SourceFolder { get; set; }
    }
}