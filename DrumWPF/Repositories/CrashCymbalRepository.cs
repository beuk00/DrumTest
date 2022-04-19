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
    internal class CrashCymbalRepository : BaseRepository<CrashCymbal>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<CrashCymbal> Create(CrashCymbal entity)
        {
            throw new NotImplementedException();
        }

        public override Task<CrashCymbal> Delete(CrashCymbal entity)
        {
            throw new NotImplementedException();
        }

        public override Task<CrashCymbal> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<CrashCymbal> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<CrashCymbal> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<CrashCymbal>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}CrashCymbal");

                List<CrashCymbal> res = JsonConvert.DeserializeObject<List<CrashCymbal>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<CrashCymbal> Update(CrashCymbal entity)
        {
            throw new NotImplementedException();
        }
    }
}
