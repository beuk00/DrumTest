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
    internal class DrumKitRepository : BaseRepository<DrumKit>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<DrumKit> Create(DrumKit entity)
        {
            throw new NotImplementedException();
        }

        public override Task<DrumKit> Delete(DrumKit entity)
        {
            throw new NotImplementedException();
        }

        public override Task<DrumKit> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<DrumKit> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<DrumKit> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<DrumKit>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}DrumKit");

                List<DrumKit> res = JsonConvert.DeserializeObject<List<DrumKit>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<DrumKit> Update(DrumKit entity)
        {
            throw new NotImplementedException();
        }
    }
}
