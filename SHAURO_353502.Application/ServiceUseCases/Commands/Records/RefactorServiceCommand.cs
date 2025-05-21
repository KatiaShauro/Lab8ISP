
namespace SHAURO_353502.Application.ServiceUseCases.Records.Commands
{
    public sealed record RefactorServiceCommand(string? name, double? cost, int? minutesDur, 
                                                int? from, int? to, string? scName, int serviceId)
       : IRequest<Service>
    { }
}
