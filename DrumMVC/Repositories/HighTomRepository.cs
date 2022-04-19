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
    public class HighTomRepository : IRepository<HighTom>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<HighTom> Create(HighTom entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}hightom", content);
                if (response.IsSuccessStatusCode)
                {
                    HighTom ht = JsonConvert.DeserializeObject<HighTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(ht);
                }
            }

            return null;
        }

        public Task<HighTom> Delete(HighTom entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<HighTom> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}hightom/{id}");
                if (response.IsSuccessStatusCode)
                {
                    HighTom ht = JsonConvert.DeserializeObject<HighTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(ht);
                }
            }
            return null;
        }

        public IQueryable<HighTom> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<HighTom> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}hightom/{id}");

                HighTom result = JsonConvert.DeserializeObject<HighTom>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<HighTom>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}hightom");

                List<HighTom> result = JsonConvert.DeserializeObject<List<HighTom>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<HighTom> Update(HighTom entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}hightom/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    HighTom ht = JsonConvert.DeserializeObject<HighTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(ht);
                }
            }
            return null;
        }
    }
}
