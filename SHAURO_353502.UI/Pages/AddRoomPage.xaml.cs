using SHAURO_353502.UI.ViewModels;

namespace SHAURO_353502.UI.Pages;

public partial class AddRoomPage : ContentPage
{
	public AddRoomPage(AddRoomViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}