using ConferencePlanning.Data;
using ConferencePlanning.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanning.Services.ConferenceServices;

public class ConferenceService : IConferenceService
{
    private readonly ConferencePlanningContext _context;

    public ConferenceService(ConferencePlanningContext context)
    {
        _context = context;
    }
    public IEnumerable<Conference> GetAllConferences()
    {
        return _context.Conferences.ToList();
    }
}