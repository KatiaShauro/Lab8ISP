using SHAURO_353502.UI.Pages;
using SHAURO_353502.UI.ViewModels;

namespace SHAURO_353502.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<HotelRoomsPage>();
            services.AddTransient<ServiceDetails>();
            services.AddTransient<AddRoomPage>();
            services.AddTransient<AddServicePage>();
            services.AddTransient<EditServicePage>();
            services.AddTransient <EditHotelRoomPage>();
            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HotelRoomsViewModel>();
            services.AddTransient<ServiceDetailsViewModel>();
            services.AddTransient<AddServiceViewModel>();
            services.AddTransient<AddRoomViewModel>();
            services.AddTransient<EditServiceViewModel>();
            services.AddTransient<EditRoomViewModel>();
            return services;
        }

    }
}
