
using ImageFolderizer.App.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ImageFolderizer.App.Services
{
    public interface IMediaFilesProvider
    {
        Task LoadSourceMediaFilesToAsync(ObservableCollection<IMediaFile> destination);
    }
}