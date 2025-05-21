
using SHAURO_353502.UI.ViewModels;

namespace SHAURO_353502.UI.Pages;

public partial class EditServicePage : ContentPage
{
	public EditServicePage(EditServiceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}