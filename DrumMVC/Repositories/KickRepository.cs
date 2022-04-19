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
    public class KickRepository : IRepository<Kick>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<Kick> Create(Kick entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}kick", content);
                if (response.IsSuccessStatusCode)
                {
                    Kick k = JsonConvert.DeserializeObject<Kick>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(k);
                }
            }

            return null;
        }

        public Task<Kick> Delete(Kick entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Kick> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}kick/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Kick k = JsonConvert.DeserializeObject<Kick>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(k);
                }
            }
            return null;
        }

        public IQueryable<Kick> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Kick> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}kick/{id}");

                Kick result = JsonConvert.DeserializeObject<Kick>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<Kick>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}kick");

                List<Kick> result = JsonConvert.DeserializeObject<List<Kick>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<Kick> Update(Kick entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}kick/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    Kick k = JsonConvert.DeserializeObject<Kick>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(k);
                }
            }
            return null;
        }
    }
}
