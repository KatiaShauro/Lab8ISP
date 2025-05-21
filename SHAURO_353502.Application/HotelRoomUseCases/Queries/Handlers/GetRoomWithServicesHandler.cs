
using SHAURO_353502.Application.HotelRoomUseCases.Queries.Records;

namespace SHAURO_353502.Application.HotelRoomUseCases.Queries.Handlers
{
    public class GetRoomWithServicesHandler : IRequestHandler<GetRoomWithServicesRequest, HotelRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoomWithServicesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HotelRoom> Handle(GetRoomWithServicesRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.HotelRoomRepository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
