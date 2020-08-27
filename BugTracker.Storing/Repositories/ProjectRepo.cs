using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Storing.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storing.Repositories
{
    public class ProjectRepo
    {
        private readonly BugTrackerDbContext _db;

        public ProjectRepo(BugTrackerDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Project> ReadProjectAsync(int id)
        {
            return await _db.Project
                .Include(x => x.Manager)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Submitter)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Dev)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Priority)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Status)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Type)
                .Include(x => x.UserProjects)
                    .ThenInclude(x => x.User)
                .SingleOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task<List<Project>> ReadProjectsByUserAsync(int userId)
        {
            return await _db.Project
                .Where(x => x.ManagerId == userId || x.UserProjects.Any(u => u.UserId == userId))
                .Include(x => x.Manager)
                .ToListAsync();
        }

        public async Task<int> CreateProjectAsync(Project project)
        {
            _db.Project.Add(project);
            await _db.SaveChangesAsync();

            return project.ProjectId;
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _db.Project.Update(project);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            _db.Remove(
                await _db.Project.SingleOrDefaultAsync(x => x.ProjectId == id)
            );
            await _db.SaveChangesAsync();
        }

        public async Task AssignUserToProjectAsync(int projectId, int userId)
        {
            var userProject = new UserProject();

            userProject.Project = await _db.Project.SingleAsync(x => x.ProjectId == projectId);
            userProject.User = await _db.Users.SingleAsync(x => x.UserId == userId);

            _db.UserProject.Add(userProject);
            await _db.SaveChangesAsync();
        }
    }
}