using ImageFolderizer.App.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ImageFolderizer.App.Services
{
    public class MediaFilesProvider : IMediaFilesProvider
    {
        private ISettings _settings;

        public MediaFilesProvider(ISettings settings)
        {
            _settings = settings;
        }

        public async Task<ICollection<IMediaFile>> GetSourceMediaFilesAsync()
        {
            var mediaFiles = new List<IMediaFile>();
            var folder = await StorageFolder.GetFolderFromPathAsync(_settings.SourceFolder);

            if (folder != null)
            {
                var files = await GetFilesAsync(folder);
                mediaFiles.Clear();

                foreach (var file in files)
                {
                    if(file.Provider.Id != "computer")
                    {
                        continue;
                    }

                    switch (file.FileType.ToLower())
                    {
                        case ".jpg":
                        case ".jpeg":
                            mediaFiles.Add(new ImageFile(file));
                            break;
                        case ".mp4":
                            mediaFiles.Add(new VideoFile(file));
                            break;
                    }
                }
            }

            return mediaFiles;
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
