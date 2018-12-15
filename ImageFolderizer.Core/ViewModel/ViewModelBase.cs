using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ImageFolderizer.Core.IoC;
using ImageFolderizer.Core.Navigation;
using Windows.UI.Xaml.Navigation;

namespace ImageFolderizer.Core.ViewModel
{
    public abstract class ViewModelBase : PropertyChangedBase
    {
        public INavigationService Navigation { get; set; }

        public virtual void OnNavigatedTo(NavigationEventArgs e)
        {
            Navigation.Parameters = e.Parameter as object[];
        }

        public virtual void OnNavigatedFrom(NavigationEventArgs e)
        {

        }
    }
}
