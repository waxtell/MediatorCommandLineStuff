using MediatorCommandLineStuff.Models.Requests;
using MediatR;
using Newtonsoft.Json;

namespace MediatorCommandLineStuff.Handlers;
public class StringCollectionNotificationHandler : INotificationHandler<StringCollectionNotification>
{
    public Task Handle(StringCollectionNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(JsonConvert.SerializeObject(notification));

        return 
            Task.CompletedTask;
    }
}
