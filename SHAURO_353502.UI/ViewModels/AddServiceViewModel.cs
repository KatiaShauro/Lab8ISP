using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHAURO_353502.Application.ServiceUseCases.Records.Commands;


namespace SHAURO_353502.UI.ViewModels
{
    [QueryProperty(nameof(RoomId), "roomId")]
    public partial class AddServiceViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AddServiceViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string price;

        [ObservableProperty]
        private string dur;

        [ObservableProperty]
        private string begining;

        [ObservableProperty]
        private string ending;

        [ObservableProperty]
        int roomId;


        [RelayCommand]
        public async void CreateService()
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                !double.TryParse(Price, out var cost) ||
                !int.TryParse(Dur, out var duration) ||
                !int.TryParse(Begining, out var begin) ||
                !int.TryParse(Ending, out var end) ||
                Price == null || Dur == null || Begining == null || Ending == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Error", "Incorrect input!", "Оk");
                return;
            }

            var command = new AddServiceCommand(Name, cost, duration, begin, end, RoomId);
            await _mediator.Send(command);

            // Вернуться назад 
            await Shell.Current.GoToAsync("..");
        }

    }
}
