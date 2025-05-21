using SHAURO_353502.Application.HotelRoomUseCases.Records.Commands;

namespace SHAURO_353502.Application.HotelRoomUseCases.Records.Handlers
{
    internal class AddRoomCommandHandler :
                        IRequestHandler<AddRoomCommand, HotelRoom>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddRoomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HotelRoom> Handle(AddRoomCommand request,
                                          CancellationToken cancellationToken)
        {
            HotelRoom newRoom = new HotelRoom(request.name, request.cost, request.rate, request.available);

            await _unitOfWork.HotelRoomRepository.AddAsync(newRoom, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return newRoom;
        }
    }
}
