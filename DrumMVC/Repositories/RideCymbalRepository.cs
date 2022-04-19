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
    public class RideCymbalRepository : IRepository<RideCymbal>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<RideCymbal> Create(RideCymbal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);
               

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}ridecymbal", content);
                if (response.IsSuccessStatusCode)
                {
                    RideCymbal rc = JsonConvert.DeserializeObject<RideCymbal>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(rc);
                }
            }

            return null;
        }

        public Task<RideCymbal> Delete(RideCymbal entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RideCymbal> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}ridecymbal/{id}");
                if (response.IsSuccessStatusCode)
                {
                    RideCymbal rc = JsonConvert.DeserializeObject<RideCymbal>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(rc);
                }
            }

            return null;
        }

        public IQueryable<RideCymbal> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<RideCymbal> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{baseUrl}ridecymbal/{id}");

                RideCymbal result = JsonConvert.DeserializeObject<RideCymbal>(response);

                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<RideCymbal>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{baseUrl}ridecymbal");
                JArray json = JArray.Parse(response);

                List<RideCymbal> result = JsonConvert.DeserializeObject<List<RideCymbal>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<RideCymbal> Update(RideCymbal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);
                

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}ridecymbal/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    RideCymbal res = JsonConvert.DeserializeObject<RideCymbal>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(res);
                }
            }
            return null;
        }
    }
}
