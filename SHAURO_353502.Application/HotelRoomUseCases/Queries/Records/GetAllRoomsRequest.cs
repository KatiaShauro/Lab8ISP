
namespace SHAURO_353502.Application.HotelRoomUseCases.Queries.Records
{
    public sealed record GetAllRoomsRequest
     : IRequest<IReadOnlyList<HotelRoom>>;
}
