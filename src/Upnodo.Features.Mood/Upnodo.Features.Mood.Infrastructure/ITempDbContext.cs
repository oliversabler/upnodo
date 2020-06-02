namespace Upnodo.Features.Mood.Infrastructure
{
    public interface ITempDbContext
    {
        void SaveMood(string value);

        string ListAllMoods();

        string ListMoodsByUserId(string userId);
    }
}