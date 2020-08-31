using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using BugTracker.Storing;
using BugTracker.Storing.Controllers;
using BugTracker.Storing.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Testing.StoringTests
{
    public class Test_ProjectController
    {
        private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
        private static readonly DbContextOptions<BugTrackerDbContext> _options = new DbContextOptionsBuilder<BugTrackerDbContext>().UseSqlite(_connection).Options;
        private readonly BugTrackerDbContext _db = new BugTrackerDbContext(_options);

        public Test_ProjectController()
        {
            _connection.Open();
            _db.Database.EnsureCreated();
        }

        [Fact]
        public async void Test_GetByUserAsync()
        {
            var sut = new ProjectController(_db);

            var res = await sut.GetByUserAsync(-1);

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetAsync()
        {
            var sut = new ProjectController(_db);

            var res = await sut.GetAsync(-1);

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetAllAsync()
        {
            var sut = new ProjectController(_db);

            var res = await sut.GetAllAsync();

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_PostAsync()
        {
            var sut = new ProjectController(_db);

            var res = await sut.PostAsync(new ProjectDTO()
            {
                Title = "title",
                Description = "description",
                Manager = new UserDTO() { UserId = -1 }
            });

            Assert.True(res.Result.GetType() == typeof(CreatedAtActionResult));
        }

        [Fact]
        public async void Test_PutAsync()
        {
            var sut = new ProjectController(_db);

            var res = await sut.PutAsync(new ProjectDTO()
            {
                ProjectId = -1,
                Title = "title",
                Description = "description",
                Manager = new UserDTO() { UserId = -1 }
            });

            Assert.True(res.GetType() == typeof(NoContentResult));
        }

        [Fact]
        public async void Test_DeleteAsync()
        {
            var sut = new ProjectController(_db);

            var res = await sut.DeleteAsync(-1);

            Assert.True(res.GetType() == typeof(NoContentResult));
        }
    }
}