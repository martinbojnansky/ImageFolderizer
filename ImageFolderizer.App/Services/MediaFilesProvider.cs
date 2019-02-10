using ImageFolderizer.App.Models;
using Microsoft.Toolkit.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace ImageFolderizer.App.Services
{
    public class MediaFilesProvider : IMediaFilesProvider
    {
        private ISettings _settings;
        private IList<StorageFile> _files;

        public MediaFilesProvider(ISettings settings)
        {
            _settings = settings;
        }

        public async Task FindFilesAsync()
        {
            var folder = await StorageFolder.GetFolderFromPathAsync(_settings.SourceFolder);

            if (folder != null)
            {
                _files = new List<StorageFile>(await GetFilesAsync(folder));
            }
        }

        public async Task<IEnumerable<IMediaFile>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            if(_files == null)
            {
                await FindFilesAsync();
            }

            var pageMediaFiles = new List<IMediaFile>();            
            var pageFiles = _files.Skip(pageIndex * pageSize).Take(pageSize);
           
            foreach (var file in pageFiles)
            {
                if (file.Provider.Id != "computer")
                {
                    continue;
                }

                switch (file.FileType.ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        var imageFile = new ImageFile(file);
                        await imageFile.UpdateThumbnailAsync(500);
                        pageMediaFiles.Add(imageFile);
                        break;
                    case ".mp4":
                        var videoFile = new VideoFile(file);
                        await videoFile.UpdateThumbnailAsync(500);
                        pageMediaFiles.Add(videoFile);
                        break;
                }
            }

            return pageMediaFiles;
        }

        private async Task<IEnumerable<StorageFile>> GetFilesAsync(IStorageFolder folder)
        {
            var items = await folder.GetItemsAsync();
            var files = new List<StorageFile>();

            foreach (var item in items)
            {
                var type = item.GetType();
                if (type == typeof(StorageFile))
                {
                    files.Add(item as StorageFile);
                }
                else if (type == typeof(StorageFolder))
                {
                    files.AddRange(await GetFilesAsync(item as StorageFolder));
                }
            }

            return files;
        }
    }
}
