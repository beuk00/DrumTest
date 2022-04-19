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
    public class DrumKitRepository : IRepository<DrumKit>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";


        public async Task<DrumKit> Create(DrumKit entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Name", entity.Name);
                values.Add("ClosedHiHatId", entity.ClosedHiHatId);
                values.Add("OpenHiHatId", entity.OpenHiHatId);
                values.Add("CrashCymbalId", entity.CrashCymbalId);
                values.Add("FloorTomId", entity.FloorTomId);
                values.Add("HighTomId", entity.HighTomId);
                values.Add("HiHatControllerId", entity.HiHatControllerId);
                values.Add("KickId", entity.KickId);
                values.Add("MidTomId", entity.MidTomId);
                values.Add("RideCymbalId", entity.RideCymbalId);
                values.Add("SnareDrumId", entity.SnareDrumId);

                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}drumkit", content);
                if (response.IsSuccessStatusCode)
                {
                    DrumKit drumKit = JsonConvert.DeserializeObject<DrumKit>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(drumKit);
                }
            }

            return null;
        }

        public Task<DrumKit> Delete(DrumKit entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DrumKit> DeleteById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}drumkit/{id}");
                if (response.IsSuccessStatusCode)
                {
                    DrumKit drumKit = JsonConvert.DeserializeObject<DrumKit>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(drumKit);
                }
            }

            return null;
        }

        public IQueryable<DrumKit> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<DrumKit> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{baseUrl}drumkit/{id}");

                DrumKit drumKit = JsonConvert.DeserializeObject<DrumKit>(response);

                return await Task.FromResult(drumKit);
            }
        }

        public async Task<IEnumerable<DrumKit>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{baseUrl}drumkit");
                JArray json = JArray.Parse(response);

                List<DrumKit> result = JsonConvert.DeserializeObject<List<DrumKit>>(response);
                return await Task.FromResult(result);
            }
        }

        public async Task<DrumKit> Update(DrumKit entity)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new JObject();
                values.Add("Id", entity.Id);
                values.Add("Name", entity.Name);
                values.Add("ClosedHiHatId", entity.ClosedHiHatId);
                values.Add("OpenHiHatId", entity.OpenHiHatId);
                values.Add("CrashCymbalId", entity.CrashCymbalId);
                values.Add("FloorTomId", entity.FloorTomId);
                values.Add("HighTomId", entity.HighTomId);
                values.Add("HiHatControllerId", entity.HiHatControllerId);
                values.Add("KickId", entity.KickId);
                values.Add("MidTomId", entity.MidTomId);
                values.Add("RideCymbalId", entity.RideCymbalId);
                values.Add("SnareDrumId", entity.SnareDrumId);


                StringContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{baseUrl}drumkit/{entity.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    DrumKit res = JsonConvert.DeserializeObject<DrumKit>(response.Content.ReadAsStringAsync().Result);
                    return await Task.FromResult(res);
                }
            }
            return null;
        }
    }
}
