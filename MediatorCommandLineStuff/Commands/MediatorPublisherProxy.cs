using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MediatorCommandLineStuff.Commands;

public static class MediatorPublisherProxy
{
    public static async Task RunAsync<T>(T notification, IHost host) where T : INotification
    {
        try
        {
            await
                host
                    .Services
                    .GetService<IMediator>()!
                    .Publish(notification);
        }
        catch (Exception)
        {
            // Handle exceptions in your own particular idiom
        }
    }

    public static async Task<int> RunAsyncWithReturn<T>(T request, IHost host) where T : IRequest<int>
    {
        try
        {
            return
                await
                    host
                        .Services
                        .GetService<IMediator>()!
                        .Send(request);
        }
        catch (Exception)
        {
            // Handle exceptions in your own particular idiom
            return -1;
        }
    }
}