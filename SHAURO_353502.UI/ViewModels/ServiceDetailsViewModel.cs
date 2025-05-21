
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHAURO_353502.Application.HotelRoomUseCases.Records.Commands;
using SHAURO_353502.Application.ServiceUseCases.Commands.Records;
using SHAURO_353502.UI.Pages;

namespace SHAURO_353502.UI.ViewModels
{
    [QueryProperty(nameof(SelectedService), "selectedService")]
    public partial class ServiceDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public ServiceDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(StringSelectedService))]
        Service selectedService;

        public string StringSelectedService => SelectedService == null ? "s" : SelectedService.ToString();

        [RelayCommand]
        public async void MoveToAnotherRoom()
        {
            var result = await Shell.Current.DisplayPromptAsync("Move service", "Enter room number:");
            int id = 0;
            if (int.TryParse(result, out id))
            {
                try
                {
                    await _mediator.Send(new AddServiceToRoomCommand(SelectedService.Id.Value, id));
                }
                catch (Exception ex)
                {
                    await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Оk");
                }
            }
            else await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Error", "Please, enter a number", "Оk");

        }
        [RelayCommand]
        public async void Edit()
        {
            Dictionary<string, object> parameters =
              new Dictionary<string, object>()
              {
                { "currentService", SelectedService }
              };
            await Shell.Current.GoToAsync(nameof(EditServicePage), parameters);
        }

        [RelayCommand]
        public async void Delete()
        {
            await _mediator.Send(new DeleteServiceCommand(SelectedService.Id.Value));
            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Deleting", "Service has been deleted", "Оk");

        }

        [RelayCommand]
        public async void AddPhoto()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select an image",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                string destFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\", "Images\\Services"));
                Directory.CreateDirectory(destFolder);

                var destPath = Path.Combine(destFolder, $"{SelectedService.Id}.png");
                using var stream = await result.OpenReadAsync();
                using var fileStream = File.Create(destPath);
                await stream.CopyToAsync(fileStream);
            }
        }

    }
}
