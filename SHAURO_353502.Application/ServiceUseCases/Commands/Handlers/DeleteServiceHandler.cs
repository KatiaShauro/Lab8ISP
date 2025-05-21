using SHAURO_353502.Application.ServiceUseCases.Commands.Records;


namespace SHAURO_353502.Application.ServiceUseCases.Commands.Handlers
{
    internal class DeleteServiceHandler :
        IRequestHandler<DeleteServiceCommand, Service>
    {

        private readonly IUnitOfWork _unitOfWork;
        public DeleteServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Service> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {

            var serv = await _unitOfWork.ServiceRepository.GetByIdAsync(request.serviceId);
            await _unitOfWork.ServiceRepository.DeleteAsync(serv);
            await _unitOfWork.SaveAllAsync();
            return serv;
        }
    }
}
