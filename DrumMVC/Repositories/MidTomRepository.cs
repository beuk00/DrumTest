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
    public class MidTomRepository : IRepository<MidTom>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<MidTom> Create(MidTom entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}midtom", content);
                if (response.IsSuccessStatusCode)
                {
                    MidTom mt = JsonConvert.DeserializeObject<MidTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(mt);
                }
            }

            return null;
        }

        public Task<MidTom> Delete(MidTom entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MidTom> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}midtom/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MidTom mt = JsonConvert.DeserializeObject<MidTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(mt);
                }
            }
            return null;
        }

        public IQueryable<MidTom> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<MidTom> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}midtom/{id}");

                MidTom result = JsonConvert.DeserializeObject<MidTom>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<MidTom>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}midtom");

                List<MidTom> result = JsonConvert.DeserializeObject<List<MidTom>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<MidTom> Update(MidTom entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}midtom/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    MidTom mt = JsonConvert.DeserializeObject<MidTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(mt);
                }
            }
            return null;
        }
    }
}
