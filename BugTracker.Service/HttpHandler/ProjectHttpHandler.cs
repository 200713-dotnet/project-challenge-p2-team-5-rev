using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Service.Models;
using Newtonsoft.Json;


namespace BugTracker.Service.HttpHandler
{
    public class ProjectHttpHandler
    {
        private const string BASE_URI = "https://bugtrackerstoring.azurewebsites.net/storing/project/";
        public async Task<List<Project>> GetProjectsAsync()
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BASE_URI);
            var json = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<List<Project>>(json);
            return deserialized;
        }
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BASE_URI + id.ToString());
            var json = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<Project>(json);
            return deserialized;
        }
        public async Task<List<Project>> GetProjectsByUserId(int id)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BASE_URI + "getprojectsbyuserid/" + id.ToString());
            var json = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<List<Project>>(json);
            return deserialized;
        }

        public async Task<Project> PostProjectAsync(Project project)
        {
            var json = JsonConvert.SerializeObject(project);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(BASE_URI, stringContent);

            json = await response.Content.ReadAsStringAsync();
            project = JsonConvert.DeserializeObject<Project>(json);

            if (response.IsSuccessStatusCode)
            {
                System.Console.WriteLine("Is Succesful - Handler");
                return project;
            }
            else
            {
                System.Console.WriteLine("is not succesful - Handler");
                return null;
            }
        }
        public async Task<bool> PutProjectAsync(Project project)
        {
            var json = JsonConvert.SerializeObject(project);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PutAsync(BASE_URI, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Put Succesfull - Handler");
                    return true;
                }
                else
                {
                    System.Console.WriteLine("Put Not Succesfull - Handler");
                    return false;
                }
            }
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(BASE_URI + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Delete Succesful - Handler");
                    return true;
                }
                else
                {
                    System.Console.WriteLine("Delete not succesful - Handler");
                    return false;
                }
            }
        }
    }
}