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
  public class UserHttpHandler
  {

    // TODO get user by id
    public async Task<List<User>> GetUsersAsync()
    {
      var http = new HttpClient();
      var response = await http.GetAsync("http://localhost:5002/api/user");
      var json = await response.Content.ReadAsStringAsync();
      var deserialized = JsonConvert.DeserializeObject<List<User>>(json);
      return deserialized;
    }
    public async Task<bool> PostUserAsync(User user)
    {
      var json = JsonConvert.SerializeObject(user);
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
      var httpClient = new HttpClient();
      var response = await httpClient.PostAsync("http://localhost:5002/api/user", stringContent);

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
    public async Task<bool> DeleteUserAsync(int id)
    {
      using (var client = new HttpClient())
      {
        var response = await client.DeleteAsync("http://localhost:5002/api/user/" + id.ToString());

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