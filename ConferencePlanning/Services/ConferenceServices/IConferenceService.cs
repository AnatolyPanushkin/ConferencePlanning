using ConferencePlanning.Data.Entities;

namespace ConferencePlanning.Services.ConferenceServices;

public interface IConferenceService
{
    IEnumerable<Conference> GetAllConferences();
}