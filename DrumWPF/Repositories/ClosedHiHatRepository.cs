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
    internal class ClosedHiHatRepository : BaseRepository<ClosedHiHat>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<ClosedHiHat> Create(ClosedHiHat entity)
        {
            throw new NotImplementedException();
        }

        public override Task<ClosedHiHat> Delete(ClosedHiHat entity)
        {
            throw new NotImplementedException();
        }

        public override Task<ClosedHiHat> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<ClosedHiHat> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<ClosedHiHat> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ClosedHiHat>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}ClosedHiHat");

                List<ClosedHiHat> res = JsonConvert.DeserializeObject<List<ClosedHiHat>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<ClosedHiHat> Update(ClosedHiHat entity)
        {
            throw new NotImplementedException();
        }
    }
}
