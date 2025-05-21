
namespace SHAURO_353502.Application.ServiceUseCases.Commands.Records
{    public sealed record DeleteServiceCommand(int serviceId)
            : IRequest<Service>
    { }
}
