using Avalonia.Styling;
using Klient.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Klient.ViewModels
{
    public class SportEquipmentsUserControlViewModel : ViewModelBase
    {
        private SportEquipment _selectedSportEquipment;
        public SportEquipment SelectedSportEquipments
        {
            get => _selectedSportEquipment;
            set => this.RaiseAndSetIfChanged(ref _selectedSportEquipment, value);
        }

        private HttpSportEquipment klient = new HttpSportEquipment();
        private ObservableCollection<SportEquipment> _SportEquipment;
        public ObservableCollection<SportEquipment> SportEquipments
        {
            get => _SportEquipment;
            set => this.RaiseAndSetIfChanged(ref _SportEquipment, value);
        }

        private string _message;
        internal SportEquipmentsUserControlViewModel DataContext;

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public SportEquipmentsUserControlViewModel()
        {
            klient.BaseAddress = new Uri("http://localhost:5068");
            Update();
        }

        public async Task Update()
        {
            var response = await klient.GetAsync("/SportEquipments");
            if (!response.IsSuccessStatusCode)
            {
                Message = $"Ошибка сервера {response.StatusCode}";
                return;
            }
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                Message = "Пустой ответ от сервера";
                return;
            }
            SportEquipments = JsonSerializer.Deserialize<ObservableCollection<SportEquipment>>(content);
            Message = "";
        }

        public async Task Delete()
        {
            if (SelectedSportEquipments == null) return;
            var response = await klient.DeleteAsync($"/SportEquipments/{SelectedSportEquipment.Id}");
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка удаления со стороны сервера";
                return;
            }
            SportEquipments.Remove(SelectedSportEquipment);
            SelectedSportEquipment = null;
            Message = "";
        }

        public async Task Add()
        {
            var  SE = new SportEquipment();
            var response = await klient.PostAsJsonAsync($"/SportEquipments", SportEquipment);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка добавления со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<SportEquipment> ();
            if (content == null)
            {
                Message = "При добавлении сервер отправил пустой ответ";
                return;
            }
            SportEquipment = content;
            SportEquipments.Add(SportEquipment);
            SelectedSportEquipment = SportEquipment;
        }

        public async Task Edit()
        {
            var response = await klient.PutAsJsonAsync($"/SportEquipments", SelectedSportEquipment);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка изменения со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<SportEquipment> ();
            if (content == null)
            {
                Message = "При изменении сервер отправил пустой ответ";
                return;
            }
            SelectedSportEquipment = content;
        }
    }
}

