using MediatR;

namespace Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords
{
    public class GetLatestCreatedMoodRecordsQuery : IRequest<GetLatestCreatedMoodRecordsResponse>
    {
        public int TotalNumberOfMoodRecords { get; }

        public GetLatestCreatedMoodRecordsQuery(int totalNumberOfMoodRecords)
        {
            TotalNumberOfMoodRecords = totalNumberOfMoodRecords > 10 ? 10 : totalNumberOfMoodRecords;
        }
    }
}