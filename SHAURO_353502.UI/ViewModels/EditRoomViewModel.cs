using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHAURO_353502.Application.HotelRoomUseCases.Records.Commands;


namespace SHAURO_353502.UI.ViewModels
{
    [QueryProperty(nameof(RoomId), "roomId")]
    public partial class EditRoomViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public EditRoomViewModel(IMediator mediator)
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

        [ObservableProperty]
        int roomId;


        [RelayCommand]
        public async void Edit()
        {
            if ((!double.TryParse(Price, out var cost) && Price != null) ||
                !double.TryParse(Rate, out var roomRate) && Rate != null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Error", "Incorrect input!", "Оk");
                return;
            }

            var command = new RefactorRoomCommand(Name, cost, roomRate, IsAvailable, RoomId);
            await _mediator.Send(command);

            // Вернуться назад 
            await Shell.Current.GoToAsync("..");

        }
    }
}
