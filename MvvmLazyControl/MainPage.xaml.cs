using System.Diagnostics;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using MvvmLazyControl.ViewModel;

namespace MvvmLazyControl
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();            
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
            Debug.WriteLine("");
        }
    }
}
