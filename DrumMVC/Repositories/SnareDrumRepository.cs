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
    public class SnareDrumRepository : IRepository<SnareDrum>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<SnareDrum> Create(SnareDrum entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);
                

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}snaredrum", content);
                if (response.IsSuccessStatusCode)
                {
                    SnareDrum sd = JsonConvert.DeserializeObject<SnareDrum>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(sd);
                }
            }

            return null;
        }

        public Task<SnareDrum> Delete(SnareDrum entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SnareDrum> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}snaredrum/{id}");
                if (response.IsSuccessStatusCode)
                {
                    SnareDrum sd = JsonConvert.DeserializeObject<SnareDrum>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(sd);
                }
            }

            return null;
        }

        public IQueryable<SnareDrum> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SnareDrum> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{baseUrl}snaredrum/{id}");

                SnareDrum result = JsonConvert.DeserializeObject<SnareDrum>(response);

                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<SnareDrum>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{baseUrl}snaredrum");
                JArray json = JArray.Parse(response);

                List<SnareDrum> result = JsonConvert.DeserializeObject<List<SnareDrum>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<SnareDrum> Update(SnareDrum entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);
               

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}snaredrum/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    SnareDrum res = JsonConvert.DeserializeObject<SnareDrum>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(res);
                }
            }
            return null;
        }
    }
}
