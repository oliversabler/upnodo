using System.Threading.Tasks;
using Upnodo.Domain.Commands;
using Upnodo.Domain.Responses;

namespace Upnodo.Infrastructure.Services.SaveDate
{
    public class SaveDateService : ISaveDateService
    {
        public Task<SaveDateResponse> SaveAsync(SaveDateCommand request)
        {
            throw new System.NotImplementedException();
        }
    }
}