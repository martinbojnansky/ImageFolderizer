using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageFolderizer.Core.Navigation;
using ImageFolderizer.App.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ImageFolderizer.App.Views
{
    public sealed partial class SettingsView : NavigationPage, IView<SettingsViewModel>
    {
        public SettingsViewModel ViewModel { get; set; } = ((App)Application.Current).MvvmLocator.ResolveViewModel<SettingsViewModel>();

        public SettingsView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
