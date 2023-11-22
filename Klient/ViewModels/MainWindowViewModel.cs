using Klient.Views;
namespace Klient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _ClientsUserControl = new ClientsUserControl();
            _ClientsUserControl.DataContext = new ClientsUserControlViewModel();
        }
        public ClientsUserControl _ClientsUserControl { get; set; }
    }
}