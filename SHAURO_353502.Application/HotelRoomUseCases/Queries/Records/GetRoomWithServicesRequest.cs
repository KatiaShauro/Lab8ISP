
namespace SHAURO_353502.Application.HotelRoomUseCases.Queries.Records
{
    public sealed record GetRoomWithServicesRequest(int Id)
        : IRequest<HotelRoom>
    {
    }
}
