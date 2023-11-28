using Klient.Views;
namespace Klient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _ClientsUserControl = new ClientsUserControl();
            _ClientsUserControl.DataContext = new ClientsUserControlViewModel();
            _SportEquipmentsUserControl = new SportEquipmentsUserControl();
            _SportEquipmentsUserControl.DataContext = new SportEquipmentsUserControlViewModel();
        }
        public ClientsUserControl _ClientsUserControl { get; set; }
        public SportEquipmentsUserControl _SportEquipmentsUserControl { get; set; }
    }
}   
