using System.Threading.Tasks;

namespace Upnodo.Domain.Contracts
{
    public interface IRecord<TResult> : IResponse where TResult : IResponse
    {
        Task<TResult> RunAsync<T>(T request);
    }
}