using System.Threading;
using System.Threading.Tasks;

namespace Upnodo.BuildingBlocks.Application.Abstractions
{
    public interface IService<TResult> : IResponse where TResult : IResponse
    {
        Task<TResult> RunAsync<T>(T request, CancellationToken token);
    }
}