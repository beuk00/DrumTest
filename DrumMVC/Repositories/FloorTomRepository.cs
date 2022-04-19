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
    public class FloorTomRepository : IRepository<FloorTom>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public async Task<FloorTom> Create(FloorTom entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}floortom", content);
                if (response.IsSuccessStatusCode)
                {
                    FloorTom ft = JsonConvert.DeserializeObject<FloorTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(ft);
                }
            }

            return null;
        }

        public Task<FloorTom> Delete(FloorTom entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<FloorTom> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}floortom/{id}");
                if (response.IsSuccessStatusCode)
                {
                    FloorTom ft = JsonConvert.DeserializeObject<FloorTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(ft);
                }
            }
            return null;
        }

        public IQueryable<FloorTom> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<FloorTom> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}floortom/{id}");

                FloorTom result = JsonConvert.DeserializeObject<FloorTom>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<FloorTom>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}floortom");

                List<FloorTom> result = JsonConvert.DeserializeObject<List<FloorTom>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<FloorTom> Update(FloorTom entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}todolist/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    FloorTom ft = JsonConvert.DeserializeObject<FloorTom>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(ft);
                }
            }
            return null;
        }
    }
}
