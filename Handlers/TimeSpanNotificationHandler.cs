using MediatorCommandLineStuff.Models.Requests;
using MediatR;
using Newtonsoft.Json;

namespace MediatorCommandLineStuff.Handlers;
public class TimeSpanNotificationHandler : INotificationHandler<TimeSpanNotification>
{
    public Task Handle(TimeSpanNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(JsonConvert.SerializeObject(notification));

        return
            Task.CompletedTask;
    }
}
