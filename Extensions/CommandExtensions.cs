using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using MediatorCommandLineStuff.Commands;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace MediatorCommandLineStuff.Extensions;

internal static class CommandExtensions
{
    public static System.CommandLine.Command WithHandler(this System.CommandLine.Command command,
        ICommandHandler handler)
    {
        command.Handler = handler;

        return command;
    }

    public static System.CommandLine.Command Publish<TNotification>(this System.CommandLine.Command command) 
        where TNotification : INotification
    {
        return
            command
                .WithHandler(CommandHandler.Create<TNotification, IHost>(MediatorPublisherProxy.RunAsync));
    }

    public static System.CommandLine.Command Send<TRequest>(this System.CommandLine.Command command)
        where TRequest : IRequest<int>
    {
        return
            command
                .WithHandler(CommandHandler.Create<TRequest, IHost>(MediatorPublisherProxy.RunAsyncWithReturn));
    }

}