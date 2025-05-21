
using SHAURO_353502.Application.HotelRoomUseCases.Records.Commands;

namespace SHAURO_353502.Application.HotelRoomUseCases.Records.Handlers
{
    internal class AddServiceToRoomHandler :
                        IRequestHandler<AddServiceToRoomCommand, Service>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddServiceToRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Service> Handle(AddServiceToRoomCommand request,
                                          CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.HotelRoomRepository.GetByIdAsync(request.roomId, cancellationToken);
            if (room is null)
                throw new KeyNotFoundException($"Room with ID {request.roomId} not found.");

            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(request.serviceId, cancellationToken);
            if (room is null)
                throw new KeyNotFoundException($"Service with ID {request.serviceId} not found.");

            room.AddService(service);
            service.ChangeRoomType(request.roomId);
            await _unitOfWork.SaveAllAsync();
            return service;
        }
    }
}
