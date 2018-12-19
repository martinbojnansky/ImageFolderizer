using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.Storage;

namespace ImageFolderizer.App.Models
{
    public interface ISettings : INotifyPropertyChanged
    {
        string DestinationFolder { get; set; }
        string SourceFolder { get; set; }
    }
}