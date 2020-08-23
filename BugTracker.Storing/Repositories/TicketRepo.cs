namespace BugTracker.Storing.Repositories
{
    public class TicketRepo
    {
        private readonly BugTrackerDbContext _db;

        public TicketRepo(BugTrackerDbContext dbContext)
        {
            _db = dbContext;
        }
    }
}