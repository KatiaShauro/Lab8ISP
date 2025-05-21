using SHAURO_353502.Application.HotelRoomUseCases.Records.Commands;
using SHAURO_353502.Application.ServiceUseCases.Records.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAURO_353502.Application.ServiceUseCases.Records.Handlers
{
    internal class RefactorServiceHandler :
        IRequestHandler<RefactorServiceCommand, Service>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RefactorServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Service> Handle(RefactorServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(request.serviceId, cancellationToken);
            if (service is null)
                throw new KeyNotFoundException($"Room with ID {request.serviceId} not found.");

            if(request.name != null)
                service.SetName(request.name);
            if (request.cost != null)
                service.ChangeCost(request.cost.Value);
            if (request.minutesDur != null)
                service.ChangeDuration(request.minutesDur.Value);
            if (request.from != null && request.to != null)
                service.ChangeSchedule(request.scName, request.from.Value, request.to.Value);

            await _unitOfWork.SaveAllAsync();

            return service;
        }
    }
}
