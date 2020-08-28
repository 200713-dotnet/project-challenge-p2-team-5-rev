using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Storing.DTO;
using BugTracker.Storing.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storing.Repositories
{
    public class ProjectRepo : AbstractRepo
    {
        public ProjectRepo(BugTrackerDbContext dbContext) : base(dbContext) { }

        public async Task<ProjectDTO> ReadProjectAsync(int id)
        {
            var project = await _db.Project
                .Include(x => x.Manager)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Submitter)
                        .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Dev)
                        .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Priority)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Status)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Type)
                .Include(x => x.UserProjects)
                    .ThenInclude(x => x.User)
                .SingleOrDefaultAsync(p => p.ProjectId == id);

            return new ProjectDTO(project);
        }

        public async Task<List<ProjectDTO>> ReadProjectsByUserAsync(int userId)
        {
            var projects = await _db.Project
                .Where(x => x.ManagerId == userId || x.UserProjects.Any(u => u.UserId == userId))
                .Include(x => x.Manager)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Submitter)
                        .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Dev)
                        .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Priority)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Status)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Type)
                .Include(x => x.UserProjects)
                    .ThenInclude(x => x.User)
                .ToListAsync();

            var projectDTOList = new List<ProjectDTO>();

            foreach (var project in projects)
            {
                projectDTOList.Add(new ProjectDTO(project));
            }

            return projectDTOList;
        }

        public async Task<List<ProjectDTO>> ReadAllProjectsAsync()
        {
            var projects = await _db.Project
                .Include(x => x.Manager)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Submitter)
                        .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Dev)
                        .ThenInclude(x => x.Role)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Priority)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Status)
                .Include(x => x.Tickets)
                    .ThenInclude(x => x.Type)
                .Include(x => x.UserProjects)
                    .ThenInclude(x => x.User)
                .ToListAsync();

            var projectDTOList = new List<ProjectDTO>();

            foreach (var project in projects)
            {
                projectDTOList.Add(new ProjectDTO(project));
            }

            return projectDTOList;
        }

        public async Task<int> CreateProjectAsync(ProjectDTO projectDTO)
        {
            var project = new Project()
            {
                Title = projectDTO.Title,
                Description = projectDTO.Description,
                Manager = await _db.Users.SingleOrDefaultAsync(x => x.UserId == projectDTO.Manager.UserId)
            };

            _db.Project.Add(project);
            await _db.SaveChangesAsync();

            return project.ProjectId;
        }

        public async Task UpdateProjectAsync(ProjectDTO projectDTO)
        {
            var project = await _db.Project.SingleAsync(x => x.ProjectId == projectDTO.ProjectId);

            project.Title = projectDTO.Title;
            project.Description = projectDTO.Description;
            project.Manager = await _db.Users.SingleOrDefaultAsync(x => x.UserId == projectDTO.Manager.UserId);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _db.Project
                .Include(x => x.UserProjects)
                .SingleOrDefaultAsync(x => x.ProjectId == id);

            foreach (var userProject in project.UserProjects)
            {
                _db.Remove(userProject);
            }

            _db.Remove(project);
            await _db.SaveChangesAsync();
        }

        // public async Task AssignUserToProjectAsync(int projectId, int userId)
        // {
        //     var userProject = new UserProject();

        //     userProject.Project = await _db.Project.SingleAsync(x => x.ProjectId == projectId);
        //     userProject.User = await _db.Users.SingleAsync(x => x.UserId == userId);

        //     _db.UserProject.Add(userProject);
        //     await _db.SaveChangesAsync();
        // }
    }
}