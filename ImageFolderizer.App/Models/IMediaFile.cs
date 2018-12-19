using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace ImageFolderizer.App.Models
{
    public interface IMediaFile
    {
        StorageFile File { get; }
        string FileType { get; }
        string Name { get; }
        BitmapImage Thumbnail { get; }
        Task UpdateThumbnailAsync(uint requestedSize);
    }
}