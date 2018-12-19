using ImageFolderizer.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageFolderizer.App.Services
{
    public interface IMediaFilesProvider
    {
        Task<ICollection<IMediaFile>> GetSourceMediaFilesAsync();
    }
}