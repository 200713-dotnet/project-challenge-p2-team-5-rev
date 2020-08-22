using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Service.Models;
using Microsoft.AspNetCore.Mvc;
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
  }
}