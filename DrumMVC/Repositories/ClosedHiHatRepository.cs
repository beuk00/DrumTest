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
    public class ClosedHiHatRepository : IRepository<ClosedHiHat>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<ClosedHiHat> Create(ClosedHiHat entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}closedhihat", content);
                if (response.IsSuccessStatusCode)
                {
                    ClosedHiHat chh = JsonConvert.DeserializeObject<ClosedHiHat>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(chh);
                }
            }

            return null;
        }

        public Task<ClosedHiHat> Delete(ClosedHiHat entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ClosedHiHat> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}closedhihat/{id}");
                if (response.IsSuccessStatusCode)
                {
                    ClosedHiHat chh = JsonConvert.DeserializeObject<ClosedHiHat>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(chh);
                }
            }
            return null;
        }

        public IQueryable<ClosedHiHat> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ClosedHiHat> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}closedhihat/{id}");

                ClosedHiHat result = JsonConvert.DeserializeObject<ClosedHiHat>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<ClosedHiHat>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}closedhihat");

                List<ClosedHiHat> result = JsonConvert.DeserializeObject<List<ClosedHiHat>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<ClosedHiHat> Update(ClosedHiHat entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}closedhihat/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    ClosedHiHat chh = JsonConvert.DeserializeObject<ClosedHiHat>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(chh);
                }
            }
            return null;
        }
    }
}
