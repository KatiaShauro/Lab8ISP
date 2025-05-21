using SHAURO_353502.UI.ViewModels;

namespace SHAURO_353502.UI.Pages;

public partial class HotelRoomsPage : ContentPage
{
    public HotelRoomsPage(HotelRoomsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is HotelRoomsViewModel viewModel)
        {
            if (viewModel.UpdateGroupListCommand.CanExecute(null))
                await viewModel.UpdateGroupListCommand.ExecuteAsync(null);
        }
    }
}