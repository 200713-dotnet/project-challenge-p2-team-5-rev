

using System.Collections.Generic;
using System.Net.Http;
using BugTracker.Service.Controllers;
using BugTracker.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BugTracker.Testing.ServiceTests
{
    public class Test_ProjectController
    {
        private readonly ProjectController controller = new ProjectController();

        [Fact]
        public async void TestGet()
        {
            // Arrange

            // Act
            try
            {
                var response = await controller.Get();

                // Assert
                Assert.True(response.Result.GetType() == typeof(OkObjectResult));
            }
            catch (HttpRequestException)
            {
                Assert.False(false, "server off");
            }
        }
        [Fact]
        public async void TestGetById()
        {
            // Arrange
            var id = 1;
            // Act
            try
            {
                var response = await controller.GetById(id);

                // Assert 
                Assert.True(response.Result.GetType() == typeof(NoContentResult));
            }
            catch (HttpRequestException)
            {
                Assert.False(false, "server off");
            }
        }

        [Fact]
        public void TestPost()
        {
            // Arrange

            // Act
            try
            {
                var response = controller.PostAsync(null); // request with no body

                // Assert 
                Assert.True(response.Result.GetType() == typeof(BadRequestResult));
            }
            catch (HttpRequestException)
            {
                Assert.False(false, "server off");
            }
        }

        public static List<Project> GetTestProjects()
        {
            var list = new List<Project>();
            for (int i = 1; i < 6; i++)
            {
                list.Add(new Project()
                {
                    ProjectId = i,
                    Title = "project num: " + i,
                    Description = "this project " + i + "description",
                    // ManagerName = "rand mang name: " + i,
                });
            }
            return list;
        }
    }
}
