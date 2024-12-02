using Grpc.Core;

namespace AdderService.Services
{
    public class AddServiceImpl : ServiceAdder.ServiceAdderBase
    {
        public override Task<AddResponse> Add(AddRequest request, ServerCallContext context)
        {
            var result = request.A + request.B;
            return Task.FromResult(new AddResponse { Result = result });
        }
    }
}
