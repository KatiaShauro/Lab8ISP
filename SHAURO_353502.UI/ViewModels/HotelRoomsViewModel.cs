using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHAURO_353502.Application.HotelRoomUseCases.Queries.Records;
using SHAURO_353502.UI.Pages;
using System.Collections.ObjectModel;

namespace SHAURO_353502.UI.ViewModels
{
    public partial class HotelRoomsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public HotelRoomsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ObservableCollection<HotelRoom> HotelRooms { get; set; } = new();
        public ObservableCollection<Service> Services { get; set; } = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(StringSelectedRoom))]
        HotelRoom selectedRoom;

        public string StringSelectedRoom => SelectedRoom != null? SelectedRoom.ToString() : "";

        public async Task GetHotelRooms()
        {
            var rooms = await _mediator.Send(new GetAllRoomsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                HotelRooms.Clear();
                foreach (var room in rooms)
                    HotelRooms.Add(room);
            });

        }
        partial void OnSelectedRoomChanged(HotelRoom? value)
        {
            if (value != null)
                _ = GetOfferedServices();
        }
        public async Task GetOfferedServices()
        {
            var room = await _mediator.Send(new GetRoomWithServicesRequest(SelectedRoom.Id.Value));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Services.Clear();
                foreach (var serv in room.Services)
                    Services.Add(serv);
            });

        }

        [RelayCommand]
        async Task UpdateGroupList() => await GetHotelRooms();

        [RelayCommand]
        async Task UpdateMembersList() => await GetOfferedServices();

        [RelayCommand]
        async void ShowDetails(Service serv) => await GotoDetailsPage(serv);

        private async Task GotoDetailsPage(Service serv)
        {
            Dictionary<string, object> parameters =
              new Dictionary<string, object>()
              {
                { "selectedService", serv }
              };
            await Shell.Current.GoToAsync(nameof(ServiceDetails), parameters);
        }

        [RelayCommand]
        private async void CreateRoom()
        {
           await Shell.Current.GoToAsync(nameof(AddRoomPage));
        }

        [RelayCommand]
        private async void CreateService()
        {
            if(SelectedRoom == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage
                    .DisplayAlert("Error", "Select room before adding new service!", "Оk");
                return;
            }
            Dictionary<string, object> parameters =
              new Dictionary<string, object>()
              {
                { "roomId", SelectedRoom.Id }
              };
            await Shell.Current.GoToAsync(nameof(AddServicePage), parameters);
        }

        [RelayCommand]
        private async void Edit()
        {
            if (SelectedRoom == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage
                    .DisplayAlert("Error", "Select room before edit it!", "Оk");
                return;
            }
            Dictionary<string, object> parameters =
               new Dictionary<string, object>()
               {
                            { "roomId", SelectedRoom.Id }
               };
            await Shell.Current.GoToAsync(nameof(EditHotelRoomPage), parameters);
        }
    }
}
