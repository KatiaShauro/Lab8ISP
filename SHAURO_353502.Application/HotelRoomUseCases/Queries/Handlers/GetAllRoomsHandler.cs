
using SHAURO_353502.Application.HotelRoomUseCases.Queries.Records;

namespace SHAURO_353502.Application.HotelRoomUseCases.Queries.Handlers
{
    public class GetAllRoomsHandler : IRequestHandler<GetAllRoomsRequest, IReadOnlyList<HotelRoom>> 
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRoomsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<HotelRoom>> Handle(GetAllRoomsRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.HotelRoomRepository.ListAllAsync(cancellationToken);
        }
    }
}
