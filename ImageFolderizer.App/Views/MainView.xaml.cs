﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class MainView : NavigationPage, INavigationPage<MainViewModel>
    {
        public MainViewModel ViewModel { get; set; } = ((App)Application.Current).MvvmLocator.ResolveViewModel<MainViewModel>();

        public MainView()
        {
            this.InitializeComponent();
        }
    }
}
