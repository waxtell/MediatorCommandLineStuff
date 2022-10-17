using MediatorCommandLineStuff.Models.Requests;
using MediatR;
using Newtonsoft.Json;

namespace MediatorCommandLineStuff.Handlers;
public class IntegerCollectionNotificationHandler : INotificationHandler<IntegerCollectionNotification>
{
    public Task Handle(IntegerCollectionNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(JsonConvert.SerializeObject(notification));

        return 
            Task.CompletedTask;
    }
}
