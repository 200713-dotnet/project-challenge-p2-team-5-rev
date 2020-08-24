using System.Linq;
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

        public Project ReadProject(int id)
        {
            return _db.Project
                .Include(x => x.Manager)
                .Include(x => x.Tickets)
                .Include(x => x.UserProjects)
                    .ThenInclude(x => x.User)
                .SingleOrDefault(p => p.ProjectId == id);
        }

        public void CreateProject(string title, string description, int managerId)
        {
            var project = new Project();

            project.Title = title;
            project.Description = description;
            project.Manager = _db.Users.Single(x => x.UserId == managerId);

            _db.Project.Add(project);
            _db.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            _db.Project.Update(project);
            _db.SaveChanges();
        }

        // public void UpdateTitle(int id, string title)
        // {
        //     var project = _db.Project.SingleOrDefault(x => x.ProjectId == id);

        //     project.Title = title;

        //     _db.Project.Update(project);
        //     _db.SaveChanges();
        // }

        // public void UpdateDescription(int id, string description)
        // {
        //     var project = _db.Project.SingleOrDefault(x => x.ProjectId == id);

        //     project.Description = description;

        //     _db.Project.Update(project);
        //     _db.SaveChanges();
        // }

        // public void UpdateManger(int id, int managerId)
        // {
        //     var project = _db.Project
        //         .Include(x => x.Manager)
        //         .SingleOrDefault(x => x.ProjectId == id);

        //     project.Manager = _db.Users.Single(x => x.UserId == managerId);

        //     _db.Project.Update(project);
        //     _db.SaveChanges();
        // }

        public void DeleteProject(int id)
        {
            _db.Remove(
                _db.Project.SingleOrDefault(x => x.ProjectId == id)
            );
            _db.SaveChanges();
        }

        public void AssignUserToProject(int projectId, int userId)
        {
            var userProject = new UserProject();

            userProject.Project = _db.Project.Single(x => x.ProjectId == projectId);
            userProject.User = _db.Users.Single(x => x.UserId == userId);

            _db.UserProject.Add(userProject);
            _db.SaveChanges();
        }
    }
}