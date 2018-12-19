using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Media.Imaging;

namespace ImageFolderizer.App.Models
{
    public abstract class MediaFile<T> where T : IStorageItemExtraProperties
    {
        public StorageFile File { get; }

        public T Properties { get; }

        public virtual async Task<BitmapImage> GetThumbnailAsync()
        {
            var thumbnail = await File.GetThumbnailAsync(ThumbnailMode.PicturesView);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.SetSource(thumbnail);
            thumbnail.Dispose();

            return bitmapImage;
        }

        public string Name { get; }

        public string FileType { get; }
    }
}
