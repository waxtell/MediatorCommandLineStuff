# MediatorCommandLineStuff
MediatR extensions for System.CommandLine.Hosting

Associate a command with either a notification or a request (only supports an integer return value).  Please note that option and argument names must match constructor parameter names on your requests/notifications.

```csharp
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
```
