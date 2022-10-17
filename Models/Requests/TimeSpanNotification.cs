using MediatR;

namespace MediatorCommandLineStuff.Models.Requests;
public class TimeSpanNotification : DemoBase, INotification
{
    public DateTime ModifiedDateTime { get; }

    public TimeSpanNotification(TimeSpan since, bool dryRun, bool force)
    : base(dryRun, force)
    {
        ModifiedDateTime = DateTime.Now.Subtract(since);
    }
}
