using MediatR;

namespace MediatorCommandLineStuff.Models.Requests;
public class IntegerCollectionNotification : DemoBase, INotification
{
    public IEnumerable<int> Ids { get; }

    public IntegerCollectionNotification(IEnumerable<int> ids, bool dryRun, bool force)
    : base(dryRun, force)
    {
        Ids = ids;
    }
}
