
namespace SHAURO_353502.Application.HotelRoomUseCases.Records.Commands
{
    public sealed record AddServiceToRoomCommand(int serviceId, int roomId)
            : IRequest<Service>
    { }
}
