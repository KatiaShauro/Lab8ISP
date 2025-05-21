using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHAURO_353502.Application.ServiceUseCases.Records.Commands;


namespace SHAURO_353502.UI.ViewModels
{
    [QueryProperty(nameof(CurrentService), "currentService")]
    public partial class EditServiceViewModel : ObservableObject
    {
        [ObservableProperty]
        Service currentService;

        private readonly IMediator _mediator;
        public EditServiceViewModel(IMediator mediator)
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

        [ObservableProperty]
        private string schedule;

        [RelayCommand]
        public async void EditService()
        {
            if ((!double.TryParse(Price, out var cost) && Price != null) ||
                (!int.TryParse(Dur, out var duration) && Dur != null ) ||
                (!int.TryParse(Begining, out var begin) && Begining != null) ||
                (!int.TryParse(Ending, out var end) && Ending != null))
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Error", "Incorrect input!", "Оk");
                return;
            }

            var command = new RefactorServiceCommand(Name, cost, duration, begin, end, Schedule, CurrentService.Id.Value);
            await _mediator.Send(command);

            // Вернуться назад 
            await Shell.Current.GoToAsync("..");
        }

    }
}
