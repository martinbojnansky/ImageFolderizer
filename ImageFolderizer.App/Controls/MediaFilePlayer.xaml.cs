using ImageFolderizer.App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ImageFolderizer.App.Controls
{
    public sealed partial class MediaFilePlayer : UserControl
    {
        private IRandomAccessStream _stream;

        public MediaFilePlayer()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        public async Task OpenAsync(IMediaFile mediaFile)
        {

            _stream = await mediaFile.File.OpenAsync(FileAccessMode.Read);

            var type = mediaFile.GetType();
            if(type == typeof(ImageFile))
            {
                OpenImageFile();
            }
            else if(type == typeof(VideoFile))
            {
                OpenVideoFile();
            }

            Visibility = Visibility.Visible;
        }

        private void OpenImageFile()
        {
            VideoPlayer.Visibility = Visibility.Collapsed;
            ImagePlayer.Visibility = Visibility.Visible;
            var image = new BitmapImage();
            image.SetSource(_stream);
            ImagePlayer.Source = image;
        }

        private void OpenVideoFile()
        {
            VideoPlayer.Visibility = Visibility.Visible;
            ImagePlayer.Visibility = Visibility.Collapsed;
            VideoPlayer.SetSource(_stream, "");
            VideoPlayer.Play();
        }

        public void Close()
        {
            VideoPlayer.Stop();
            ImagePlayer.Source = null;
            _stream.Dispose();
            Visibility = Visibility.Collapsed;             
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (Visibility == Visibility.Visible && args.VirtualKey == VirtualKey.Escape)
            {
                Close();
            }
        }

    }
}
