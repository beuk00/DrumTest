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
    internal class KickRepository : BaseRepository<Kick>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<Kick> Create(Kick entity)
        {
            throw new NotImplementedException();
        }

        public override Task<Kick> Delete(Kick entity)
        {
            throw new NotImplementedException();
        }

        public override Task<Kick> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Kick> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Kick> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Kick>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}Kick");

                List<Kick> res = JsonConvert.DeserializeObject<List<Kick>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<Kick> Update(Kick entity)
        {
            throw new NotImplementedException();
        }
    }
}
