using System.Threading.Tasks;
using Upnodo.Domain.Commands;
using Upnodo.Domain.Responses;

namespace Upnodo.Infrastructure.Services.SaveDate
{
    public interface ISaveDateService
    {
        Task<SaveDateResponse> SaveAsync(SaveDateCommand request);
    }
}