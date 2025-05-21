using SHAURO_353502.UI.ViewModels;

namespace SHAURO_353502.UI.Pages;

public partial class AddServicePage : ContentPage
{
	public AddServicePage(AddServiceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}