using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFolderizer.Core.ViewModel;

namespace ImageFolderizer.Core.Navigation
{
    public interface INavigationPage<T> where T : ViewModelBase
    {
        T ViewModel { get; set; }
    }
}
