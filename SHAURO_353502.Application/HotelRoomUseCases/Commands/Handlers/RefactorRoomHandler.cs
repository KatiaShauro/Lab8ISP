using SHAURO_353502.Application.HotelRoomUseCases.Records.Commands;

namespace SHAURO_353502.Application.HotelRoomUseCases.Records.Handlers
{
    internal class RefactorRoomHandler : 
        IRequestHandler<RefactorRoomCommand, HotelRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RefactorRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HotelRoom> Handle(RefactorRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.HotelRoomRepository.GetByIdAsync(request.RoomId, cancellationToken);
            if (room is null)
                throw new KeyNotFoundException($"Room with ID {request.RoomId} not found.");

            // Изменения
                room.SetName(request.name);
            if(request.cost.HasValue)
                room.SetCost(request.cost.Value);
            if (request.rate.HasValue)
                room.SetRate(request.rate.Value);

            room.SetAvailability(request.available);

            await _unitOfWork.SaveAllAsync();

            return room;
        }
    }
}
