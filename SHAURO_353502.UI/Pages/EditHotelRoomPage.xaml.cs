using SHAURO_353502.UI.ViewModels;

namespace SHAURO_353502.UI.Pages;

public partial class EditHotelRoomPage : ContentPage
{
	public EditHotelRoomPage(EditRoomViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}