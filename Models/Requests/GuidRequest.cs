using MediatR;

namespace MediatorCommandLineStuff.Models.Requests;

public class GuidRequest : DemoBase, IRequest<int>
{
    public Guid UserGuid { get; }

    public GuidRequest(Guid userGuid, bool dryRun, bool force)
    : base(dryRun, force)
    {
        UserGuid = userGuid;
    }
}
