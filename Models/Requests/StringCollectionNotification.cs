using MediatR;

namespace MediatorCommandLineStuff.Models.Requests;
public class StringCollectionNotification : DemoBase, INotification
{
    public IEnumerable<string> Names { get; }

    public StringCollectionNotification(IEnumerable<string> names, bool dryRun, bool force) 
    : base(dryRun, force)
    {
        Names = names;
    }
}
