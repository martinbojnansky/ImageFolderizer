using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Controls;

namespace ImageFolderizer.App.Models
{
    public class VideoFile : MediaFile
    {
        public override Symbol Icon => Symbol.Video;

        public VideoFile(StorageFile file) : base(file)
        {
        }
    }
}
