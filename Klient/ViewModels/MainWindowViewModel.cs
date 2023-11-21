using Klient.Views;
namespace Klient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _ClientsUserControl = new ClientsUserControlViewModel();
            _ClientsUserControl.DataContext = new ClientsUserControlViewModel();
        }
        public ClientsUserControlViewModel _ClientsUserControl { get; set; }
    }
}