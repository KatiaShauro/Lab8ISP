using SHAURO_353502.Application.ServiceUseCases.Records.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAURO_353502.Application.ServiceUseCases.Records.Handlers
{
    internal class AddServiceCommandHandler :
                        IRequestHandler<AddServiceCommand, Service>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Service> Handle(AddServiceCommand request,
                                          CancellationToken cancellationToken)
        {
            Service newServ = new Service(request.name, request.cost, TimeSpan.FromMinutes(request.minutesDuration),
                new ServiceSchedule(request.from, request.to)
            );
            if (request.roomId.HasValue)
            {
                newServ.ChangeRoomType(request.roomId.Value);
            }
            var room = await _unitOfWork.HotelRoomRepository.GetByIdAsync(request.roomId.Value, cancellationToken);

            room.AddService(newServ);
            await _unitOfWork.ServiceRepository.AddAsync(newServ, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return newServ;
        }
    }
}
