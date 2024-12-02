
using Grpc.Core;
using StringService;

namespace StringService.Services
{
    public class StringServiceImpl : ServiceString.ServiceStringBase
    { 
        public override Task<ConcatenateResponse> Concatenate(ConcatenateRequest request, ServerCallContext context)
        {
            var result = request.Str1 + request.Str2;
            return Task.FromResult(new ConcatenateResponse { Result = result });
        }
    }
}
