using System;
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
    public async Task<List<Project>> GetProjectsAsync()
    {
      var http = new HttpClient();
      var response = await http.GetAsync("http://localhost:5002/api/project");
      var json = await response.Content.ReadAsStringAsync();
      var deserialized = JsonConvert.DeserializeObject<List<Project>>(json);
      return deserialized;
    }
    public async Task<Project> GetProjectByIdAsync(int id)
    {
      var http = new HttpClient();
      var response = await http.GetAsync("http://localhost:5002/api/project/" + id.ToString());
      var json = await response.Content.ReadAsStringAsync();
      var deserialized = JsonConvert.DeserializeObject<Project>(json);
      return deserialized;
    }
    public async Task<List<Project>> GetProjectsByUserId(int id)
    {
      var http = new HttpClient();
      var response = await http.GetAsync("http://localhost:5002/api/project/getprojectsbyuserid/" + id.ToString());
      var json = await response.Content.ReadAsStringAsync();
      var deserialized = JsonConvert.DeserializeObject<List<Project>>(json);
      return deserialized;
    }
    public async Task<bool> PutProjectAsync(int id, Project project)
    {
      var json = JsonConvert.SerializeObject(project);
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
      using(var client = new HttpClient())
      {
        var response = await client.PutAsync("http://localhost:5002/api/project/" + id.ToString(), stringContent);
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
    public async Task<bool> PostProjectAsync(Project project)
    {
      var json = JsonConvert.SerializeObject(project);
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
      var httpClient = new HttpClient();
      var response = await httpClient.PostAsync("http://localhost:5002/api/project", stringContent);

      if (response.IsSuccessStatusCode)
      {
        System.Console.WriteLine("Is Succesful - Handler");
        return true;
      }
      else
      {
        System.Console.WriteLine("is not succesful - Handler");
        return false;
      }
    }
    public async Task<bool> DeleteProjectAsync(int id)
    {
      using (var client = new HttpClient())
      {
        var response = await client.DeleteAsync("http://localhost:5002/api/project/" + id.ToString());
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