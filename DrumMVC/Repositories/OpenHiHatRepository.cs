using DrumLib.Interfaces;
using DrumLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DrumMVC.Repositories
{
    public class OpenHiHatRepository : IRepository<OpenHiHat>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<OpenHiHat> Create(OpenHiHat entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}openhihat", content);
                if (response.IsSuccessStatusCode)
                {
                    OpenHiHat ohh = JsonConvert.DeserializeObject<OpenHiHat>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(ohh);
                }
            }

            return null;
        }

        public Task<OpenHiHat> Delete(OpenHiHat entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<OpenHiHat> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}openhihat/{id}");
                if (response.IsSuccessStatusCode)
                {
                    OpenHiHat ohh = JsonConvert.DeserializeObject<OpenHiHat>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(ohh);
                }
            }

            return null;
        }

        public IQueryable<OpenHiHat> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<OpenHiHat> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{baseUrl}openhihat/{id}");

                OpenHiHat result = JsonConvert.DeserializeObject<OpenHiHat>(response);

                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<OpenHiHat>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{baseUrl}openhihat");
                JArray json = JArray.Parse(response);

                List<OpenHiHat> result = JsonConvert.DeserializeObject<List<OpenHiHat>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<OpenHiHat> Update(OpenHiHat entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);
                

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}openhihat/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    OpenHiHat res = JsonConvert.DeserializeObject<OpenHiHat>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(res);
                }
            }
            return null;
        }
    }
}
