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
    public class CrashCymbalRepository : IRepository<CrashCymbal>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<CrashCymbal> Create(CrashCymbal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}crashcymbal", content);
                if (response.IsSuccessStatusCode)
                {
                    CrashCymbal cc = JsonConvert.DeserializeObject<CrashCymbal>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(cc);
                }
            }

            return null;
        }

        public Task<CrashCymbal> Delete(CrashCymbal entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CrashCymbal> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}crashcymbal/{id}");
                if (response.IsSuccessStatusCode)
                {
                    CrashCymbal cc = JsonConvert.DeserializeObject<CrashCymbal>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(cc);
                }
            }
            return null;
        }
    

        public IQueryable<CrashCymbal> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<CrashCymbal> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}crashcymbal/{id}");

                CrashCymbal result = JsonConvert.DeserializeObject<CrashCymbal>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<CrashCymbal>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}crashcymbal");

                List<CrashCymbal> result = JsonConvert.DeserializeObject<List<CrashCymbal>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<CrashCymbal> Update(CrashCymbal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}crashcymbal/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    CrashCymbal cc = JsonConvert.DeserializeObject<CrashCymbal>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(cc);
                }
            }
            return null;
        }
    }
}
