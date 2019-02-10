using ImageFolderizer.App.Models;
using Microsoft.Toolkit.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ImageFolderizer.App.Services
{
    public interface IMediaFilesProvider : IIncrementalSource<IMediaFile>
    {
    }
}