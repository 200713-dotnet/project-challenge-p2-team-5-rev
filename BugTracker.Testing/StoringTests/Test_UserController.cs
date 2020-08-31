using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using BugTracker.Storing;
using BugTracker.Storing.Controllers;
using BugTracker.Storing.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Testing.StoringTests
{
    public class Test_UserController2 // Are you f******* kidding me? Why do the test depend on the name of the class?
    {
        private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
        private static readonly DbContextOptions<BugTrackerDbContext> _options = new DbContextOptionsBuilder<BugTrackerDbContext>().UseSqlite(_connection).Options;
        private readonly BugTrackerDbContext _db = new BugTrackerDbContext(_options);

        public Test_UserController2()
        {
            _connection.Open();
            _db.Database.EnsureCreated();
        }

        [Fact]
        public async void Test_LoginAsync()
        {
            var sut = new UserController(_db);

            var res = await sut.LoginAsync("email");

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetAsync()
        {
            var sut = new UserController(_db);

            var res = await sut.GetAsync(-1);

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetAllAsync()
        {
            var sut = new UserController(_db);

            var res = await sut.GetAllAsync();

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetByRoleAsync()
        {
            var sut = new UserController(_db);

            var res = await sut.GetByRoleAsync("Admin");

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetRolesAsync()
        {
            var sut = new UserController(_db);

            var res = await sut.GetRolesAsync();

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_PostAsync()
        {
            var sut = new UserController(_db);

            var res = await sut.PostAsync(new UserDTO()
            {
                FirstName = "first",
                LastName = "last",
                Email = "newemail",
                Role = "Admin"
            });

            Assert.True(res.Result.GetType() == typeof(CreatedAtActionResult));
        }

        [Fact]
        public async void Test_PutAsync()
        {
            var sut = new UserController(_db);

            var res = await sut.PutAsync(new UserDTO()
            {
                UserId = -1,
                FirstName = "first",
                LastName = "last",
                Email = "email",
                Role = "Admin"
            });

            Assert.True(res.GetType() == typeof(NoContentResult));
        }

        [Fact]
        public async void Test_DeleteAsync()
        {
            var sut = new UserController(_db);

            var res = await sut.DeleteAsync(-1);

            Assert.True(res.GetType() == typeof(NoContentResult));
        }
    }
}