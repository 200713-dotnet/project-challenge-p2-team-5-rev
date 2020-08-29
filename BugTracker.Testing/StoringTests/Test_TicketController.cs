using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using BugTracker.Storing;
using BugTracker.Storing.Controllers;
using BugTracker.Storing.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BugTracker.Testing.StoringTests
{
    public class Test_TicketController
    {
        private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
        private static readonly DbContextOptions<BugTrackerDbContext> _options = new DbContextOptionsBuilder<BugTrackerDbContext>().UseSqlite(_connection).Options;
        private readonly BugTrackerDbContext _db = new BugTrackerDbContext(_options);

        public Test_TicketController()
        {
            _connection.Open();
            _db.Database.EnsureCreated();
        }

        [Fact]
        public async void Test_GetAsync()
        {
            var sut = new TicketController(_db);

            var res = await sut.GetAsync(-1);

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetPriorities()
        {
            var sut = new TicketController(_db);

            var res = await sut.GetPriorities();

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetStatuses()
        {
            var sut = new TicketController(_db);

            var res = await sut.GetStatuses();

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        [Fact]
        public async void Test_GetTypes()
        {
            var sut = new TicketController(_db);

            var res = await sut.GetTypes();

            Assert.True(res.Result.GetType() == typeof(OkObjectResult));
        }

        // [Fact]
        // public async void Test_PostAsync()
        // {
        //     var sut = new TicketController(_db);

        //     var res = await sut.PostAsync(-1, new TicketDTO()
        //     {
        //         Title = "title",
        //         Description = "description",
        //         Submitter = new UserDTO() { UserId = -1 },
        //         Priority = "High",
        //         Status = "Open",
        //         Type = "Bug/Error"
        //     });

        //     Assert.True(res.Result.GetType() == typeof(CreatedAtActionResult));
        // }

        [Fact]
        public async void Test_PutAsync()
        {
            var sut = new TicketController(_db);

            var res = await sut.PutAsync(new TicketDTO()
            {
                TicketId = -1,
                Title = "title",
                Description = "description",
                Submitter = new UserDTO() { UserId = -1 },
                Updater = new UserDTO() { UserId = -1 },
                Priority = "High",
                Status = "Open",
                Type = "Bug/Error"
            });

            Assert.True(res.GetType() == typeof(NoContentResult));
        }

        [Fact]
        public async void Test_DeleteAsync()
        {
            var sut = new TicketController(_db);

            var res = await sut.DeleteAsync(-1);

            Assert.True(res.GetType() == typeof(NoContentResult));
        }
    }
}