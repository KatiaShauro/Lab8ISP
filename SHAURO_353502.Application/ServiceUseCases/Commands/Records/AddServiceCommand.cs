namespace SHAURO_353502.Application.ServiceUseCases.Records.Commands
{
    public sealed record AddServiceCommand(string name, double cost, int minutesDuration, int from, int to, int? roomId)
        : IRequest<Service>
    { }
}
