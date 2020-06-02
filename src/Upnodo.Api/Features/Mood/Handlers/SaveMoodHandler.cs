using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.ListMoodsByUserId;
using Upnodo.Features.Mood.Application.SaveMood;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class SaveMoodHandler : IRequestHandler<SaveMoodCommand, SaveMoodResponse>
    {
        private readonly IService<SaveMoodResponse> _saveService;

        public SaveMoodHandler(IService<SaveMoodResponse> saveService)
        {
            _saveService = saveService;
        }

        public async Task<SaveMoodResponse> Handle(SaveMoodCommand request, CancellationToken cancellationToken)
        {
            return await _saveService.RunAsync(request);
        }
    }
}