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
    internal class RideCymbalRepository : BaseRepository<RideCymbal>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<RideCymbal> Create(RideCymbal entity)
        {
            throw new NotImplementedException();
        }

        public override Task<RideCymbal> Delete(RideCymbal entity)
        {
            throw new NotImplementedException();
        }

        public override Task<RideCymbal> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<RideCymbal> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<RideCymbal> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<RideCymbal>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}RideCymbal");

                List<RideCymbal> res = JsonConvert.DeserializeObject<List<RideCymbal>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<RideCymbal> Update(RideCymbal entity)
        {
            throw new NotImplementedException();
        }
    }
}
