namespace BugTracker.Storing.Repositories
{
    public class ProjectRepo
    {
        private readonly BugTrackerDbContext _db;

        public ProjectRepo(BugTrackerDbContext dbContext)
        {
            _db = dbContext;
        }
    }
}