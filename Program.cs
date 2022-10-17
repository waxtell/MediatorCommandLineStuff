using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.CommandLine.Builder;
using System.CommandLine;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using System.Reflection;
using MediatorCommandLineStuff.Extensions;
using MediatorCommandLineStuff.Models.Requests;
using MediatR;

return
    await
        BuildCommandLine()
            .UseHost(_ => CreateHostBuilder(args))
            .UseDefaults()
            .Build()
            .InvokeAsync(args);

static CommandLineBuilder BuildCommandLine()
{
    var root = new RootCommand
    {
        new Command("demo")
        {
            new Command("since")
            {
                new Argument<TimeSpan>("since")
                {
                    Arity = ArgumentArity.ExactlyOne
                }
            }
            .Publish<TimeSpanNotification>(),
            new Command("guid")
            {
                new Option<Guid>("--userguid")
                {
                    IsRequired = true
                }
            }
            .Send<GuidRequest>(),
            new Command("names")
            {
                new Argument<IEnumerable<string>>("names")
                {
                    Arity = ArgumentArity.OneOrMore
                }
            }
            .Publish<StringCollectionNotification>(),
            new Command("ids")
            {
                new Argument<IEnumerable<int>>("ids")
                {
                    Arity = ArgumentArity.OneOrMore
                }
            }
            .Publish<IntegerCollectionNotification>(),
        }
    };

    root.AddGlobalOption(new Option<bool>("--force", "Force the job to run"));
    root.AddGlobalOption(new Option<bool>("--dry-run", "Dry run"));

    return new CommandLineBuilder(root);
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    new HostBuilder()
        .ConfigureAppConfiguration
        (
            (_, config) =>
            {
                config
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddEnvironmentVariables()
                    .AddCommandLine(args);
            }
        )
        .ConfigureServices
        (
            (_, collection) =>
            {
                var assemblies =
                (
                    from file in Directory.GetFiles(Directory.GetCurrentDirectory())
                    let f = new FileInfo(file)
                    where f.Name.Contains(typeof(Program).Assembly.GetName().Name!)
                    where f.Extension == ".dll"
                    select Assembly.Load(Path.GetFileNameWithoutExtension(f.Name))
                )
                .ToList();

                collection
                    .AddMediatR(assemblies, _ => { });
            }
        );
