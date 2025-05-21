using SHAURO_353502.UI.ViewModels;

namespace SHAURO_353502.UI.Pages;

public partial class ServiceDetails : ContentPage
{
	public ServiceDetails(ServiceDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}