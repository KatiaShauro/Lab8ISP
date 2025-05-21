using SHAURO_353502.UI.Pages;

namespace SHAURO_353502.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ServiceDetails),
                                  typeof(ServiceDetails));
            Routing.RegisterRoute(nameof(AddRoomPage),
                                  typeof(AddRoomPage));
            Routing.RegisterRoute(nameof(AddServicePage),
                                  typeof(AddServicePage));
            Routing.RegisterRoute(nameof(EditServicePage),
                                  typeof(EditServicePage));
            Routing.RegisterRoute(nameof(EditHotelRoomPage),
                                  typeof(EditHotelRoomPage));
        }
    }
}
