using DrumLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DrumWPF.Repositories
{
    internal class OpenHiHatRepository : BaseRepository<OpenHiHat>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<OpenHiHat> Create(OpenHiHat entity)
        {
            throw new NotImplementedException();
        }

        public override Task<OpenHiHat> Delete(OpenHiHat entity)
        {
            throw new NotImplementedException();
        }

        public override Task<OpenHiHat> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<OpenHiHat> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<OpenHiHat> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<OpenHiHat>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}OpenHiHat");

                List<OpenHiHat> res = JsonConvert.DeserializeObject<List<OpenHiHat>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<OpenHiHat> Update(OpenHiHat entity)
        {
            throw new NotImplementedException();
        }
    }
}
