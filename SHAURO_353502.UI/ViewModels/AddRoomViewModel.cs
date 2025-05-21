
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHAURO_353502.Application.HotelRoomUseCases.Records.Commands;


namespace SHAURO_353502.UI.ViewModels
{
    public partial class AddRoomViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AddRoomViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string price;

        [ObservableProperty]
        private string rate;

        [ObservableProperty]
        private bool isAvailable;


        [RelayCommand]
        public async void CreateRoom()
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                !double.TryParse(Price, out var cost) ||
                !double.TryParse(Rate, out var roomRate)||
                Rate == null || Price == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Error", "Incorrect input!", "Оk");
                return;
            }

            var command = new AddRoomCommand(Name, cost, roomRate, IsAvailable);
            await _mediator.Send(command);

            // Вернуться назад 
            await Shell.Current.GoToAsync("..");

        }
    }
}
