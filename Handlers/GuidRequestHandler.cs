using MediatorCommandLineStuff.Models.Requests;
using MediatR;
using Newtonsoft.Json;

namespace MediatorCommandLineStuff.Handlers;
public class GuidRequestHandler : IRequestHandler<GuidRequest,int>
{
    public Task<int> Handle(GuidRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine(JsonConvert.SerializeObject(request));

        return 
            Task.FromResult(1);
    }
}
