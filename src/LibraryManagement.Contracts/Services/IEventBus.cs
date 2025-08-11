using LibraryManagement.SharedKernel;

namespace LibraryManagement.Contracts.Services
{
    public interface IEventBus
    {
        Task PublishAsync(IIntegrationEvent integrationEvent, CancellationToken cancellationToken);
    }
}
