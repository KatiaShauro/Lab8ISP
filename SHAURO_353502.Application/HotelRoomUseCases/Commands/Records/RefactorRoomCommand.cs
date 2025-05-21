
namespace SHAURO_353502.Application.HotelRoomUseCases.Records.Commands
{
    public sealed record RefactorRoomCommand(string? name, double? cost, double? rate, bool available, int RoomId)
        : IRequest<HotelRoom>
    { }
}
