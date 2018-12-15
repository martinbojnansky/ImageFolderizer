using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFolderizer.App.Views;

namespace ImageFolderizer.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public void NavigateToSettingsPage()
        {
            Navigation.GoTo(typeof(SettingsView), "This is navigation parameter");
        }
    }
}
