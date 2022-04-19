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
    internal class SnareDrumRepository : BaseRepository<SnareDrum>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<SnareDrum> Create(SnareDrum entity)
        {
            throw new NotImplementedException();
        }

        public override Task<SnareDrum> Delete(SnareDrum entity)
        {
            throw new NotImplementedException();
        }

        public override Task<SnareDrum> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<SnareDrum> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<SnareDrum> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<SnareDrum>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}SnareDrum");

                List<SnareDrum> res = JsonConvert.DeserializeObject<List<SnareDrum>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<SnareDrum> Update(SnareDrum entity)
        {
            throw new NotImplementedException();
        }
    }
}
