namespace MediatorCommandLineStuff.Models.Requests;

public abstract class DemoBase
{
    public bool DryRun { get; }
    public bool Force { get; }

    protected DemoBase(bool dryRun, bool force)
    {
        DryRun = dryRun;
        Force = force;
    }
}