using ImageFolderizer.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ImageFolderizer.App.Models
{
    public abstract class MediaFile : PropertyChangedBase ,IMediaFile
    {
        public StorageFile File { get; }

        public string Name { get; }

        public string FileType { get; }

        public BitmapImage Thumbnail { get; private set; }

        public abstract Symbol Icon { get; }

        public MediaFile(StorageFile file)
        {
            File = file;
            Name = file.DisplayName;
            FileType = file.FileType;
        }

        public virtual async Task UpdateThumbnailAsync(uint requestedSize)
        {
            var thumbnail = await File.GetScaledImageAsThumbnailAsync(ThumbnailMode.SingleItem, requestedSize);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.SetSource(thumbnail);
            thumbnail.Dispose();

            Thumbnail = bitmapImage;
            RaisePropertyChanged(nameof(Thumbnail));
        }
    }
}
