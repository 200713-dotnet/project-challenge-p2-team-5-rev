using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Service.Models;
using Newtonsoft.Json;


namespace BugTracker.Service.HttpHandler
{
  public class TicketHttpHandler
  {
    public async Task<List<Ticket>> GetTicketsAsync()
    {
      var http = new HttpClient();
      var response = await http.GetAsync("http://localhost:5002/api/ticket");
      var json = await response.Content.ReadAsStringAsync();
      var deserialized = JsonConvert.DeserializeObject<List<Ticket>>(json);
      return deserialized;
    }
    public async Task<Ticket> GetTicketsByIdAsync(int id)
    {
      var http = new HttpClient();
      var response = await http.GetAsync("http://localhost:5002/api/ticket/" + id.ToString());
      var json = await response.Content.ReadAsStringAsync();
      var deserialized = JsonConvert.DeserializeObject<Ticket>(json);
      return deserialized;
    }
    public async Task<List<Ticket>> GetTicketsByProjectId(int id)
    {
      var http = new HttpClient();
      var response = await http.GetAsync("http://localhost:5002/api/ticket/getticketsbyprojectid/" + id.ToString());
      var json = await response.Content.ReadAsStringAsync();
      var deserialized = JsonConvert.DeserializeObject<List<Ticket>>(json);
      return deserialized;
    }
    public async Task<bool> PutTicketAsync(int id, Ticket ticket)
    {
      var json = JsonConvert.SerializeObject(ticket);
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
      using(var client = new HttpClient())
      {
        var response = await client.PutAsync("http://localhost:5002/api/ticket/" + id.ToString(), stringContent);
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

    public async Task<bool> PostTicketAsync(Ticket ticket)
    {
      var json = JsonConvert.SerializeObject(ticket);
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
      var httpClient = new HttpClient();
      var response = await httpClient.PostAsync("http://localhost:5002/api/ticket", stringContent);

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
    public async Task<bool> DeleteTicketsAsync(int id)
    {
      using (var client = new HttpClient())
      {
        var response = await client.DeleteAsync("http://localhost:5002/api/ticket/" + id.ToString());
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