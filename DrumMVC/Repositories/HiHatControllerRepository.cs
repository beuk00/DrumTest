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
    public class HiHatControllerRepository : IRepository<HiHatController>
    {
        private string baseUrl = "https://localhost:44322/api/";

        public async Task<HiHatController> Create(HiHatController entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}hihatcontroller", content);
                if (response.IsSuccessStatusCode)
                {
                    HiHatController hhc = JsonConvert.DeserializeObject<HiHatController>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(hhc);
                }
            }

            return null;
        }

        public Task<HiHatController> Delete(HiHatController entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<HiHatController> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}hihatcontroller/{id}");
                if (response.IsSuccessStatusCode)
                {
                    HiHatController hhc = JsonConvert.DeserializeObject<HiHatController>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(hhc);
                }
            }
            return null;
        }

        public IQueryable<HiHatController> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<HiHatController> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}hihatcontroller/{id}");

                HiHatController result = JsonConvert.DeserializeObject<HiHatController>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<IEnumerable<HiHatController>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}hihatcontroller");

                List<HiHatController> result = JsonConvert.DeserializeObject<List<HiHatController>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<HiHatController> Update(HiHatController entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}hihatcontroller/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    HiHatController hhc = JsonConvert.DeserializeObject<HiHatController>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(hhc);
                }
            }
            return null;
        }
    }
}
