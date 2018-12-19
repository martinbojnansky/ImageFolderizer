using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFolderizer.Core.IoC;
using ImageFolderizer.Core.Localization;
using ImageFolderizer.Core.Navigation;
using ImageFolderizer.Core.Storage;
using ImageFolderizer.App.ViewModels;
using ImageFolderizer.Core.ViewManagement;
using ImageFolderizer.App.Models;
using ImageFolderizer.App.Services;

namespace ImageFolderizer.App.IoC
{
    public class IoCContainer : IoCContainerBase
    {
        public override void OnBuildContainer()
        {
            Register<INavigationService, NavigationService>();
            Register<ILocalizedResources, LocalizedResources>();
            Register<ILocalObjectStorage, LocalObjectStorage>();
            Register<IRoamingObjectStorage, RoamingObjectStorage>();
            Register<IJsonSerializer, JsonSerializer>();
            Register<IXmlSerializer, XmlSerializer>();
            Register<IAppBar, AppBar>();

            AutoRegister<ViewModelBase>();

            RegisterSingle<ISettings, Settings>();
            RegisterSingle<IMediaFilesProvider, MediaFilesProvider>();
        }
    }
}
