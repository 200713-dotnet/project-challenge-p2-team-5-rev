namespace BugTracker.Storing.Repositories
{
    public class UserRepo
    {
        private readonly BugTrackerDbContext _db;

        public UserRepo(BugTrackerDbContext dbContext)
        {
            _db = dbContext;
        }
    }
}