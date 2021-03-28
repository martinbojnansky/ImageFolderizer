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

        public async Task LoadSourceMediaFilesToAsync(ObservableCollection<IMediaFile> destination)
        {
            var folder = await StorageFolder.GetFolderFromPathAsync(_settings.SourceFolder);

            if (folder != null)
            {
                var files = await GetFilesAsync(folder);
                destination.Clear();

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
                        case ".png":
                            var imageFile = new ImageFile(file);
                            await imageFile.UpdateThumbnailAsync(500);
                            destination.Add(imageFile);
                            break;
                        case ".mp4":
                        case ".mkv":
                            var videoFile = new VideoFile(file);
                            await videoFile.UpdateThumbnailAsync(500);
                            destination.Add(videoFile);
                            break;
                    }
                }
            }
        }

        private async Task<IEnumerable<StorageFile>> GetFilesAsync(StorageFolder folder)
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
