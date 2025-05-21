namespace SHAURO_353502.Application.HotelRoomUseCases.Records.Commands
{
    public sealed record AddRoomCommand(string name, double cost, double rate, bool available)
        : IRequest<HotelRoom>
    { }
}
