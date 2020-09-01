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
        private const string BASE_URI = "https://bugtrackerstoring.azurewebsites.net/storing/ticket/";
        public async Task<Ticket> GetTicketsByIdAsync(int id)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BASE_URI + id.ToString());
            var json = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<Ticket>(json);
            return deserialized;
        }
        public async Task<List<Ticket>> GetTicketsByProjectId(int id)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BASE_URI + "getticketsbyprojectid/" + id.ToString());
            var json = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<List<Ticket>>(json);
            return deserialized;
        }
        public async Task<Ticket> PostTicketAsync(int projectId, Ticket ticket)
        {
            var json = JsonConvert.SerializeObject(ticket);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(BASE_URI + projectId.ToString(), stringContent);
            // content returned by Storing after Post
            json = await response.Content.ReadAsStringAsync();
            ticket = JsonConvert.DeserializeObject<Ticket>(json);

            if (response.IsSuccessStatusCode)
            {
                return ticket;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> PutTicketAsync(Ticket ticket)
        {
            var json = JsonConvert.SerializeObject(ticket);
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

        public async Task<bool> DeleteTicketAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(BASE_URI + "/" + id.ToString());
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