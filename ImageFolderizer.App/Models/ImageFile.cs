using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace ImageFolderizer.App.Models
{
    public class ImageFile : MediaFile
    {
        public ImageFile(StorageFile file) : base(file)
        {
        }
    }
}
