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
    internal class MidTomRepository : BaseRepository<MidTom>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<MidTom> Create(MidTom entity)
        {
            throw new NotImplementedException();
        }

        public override Task<MidTom> Delete(MidTom entity)
        {
            throw new NotImplementedException();
        }

        public override Task<MidTom> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<MidTom> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<MidTom> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<MidTom>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}MidTom");

                List<MidTom> res = JsonConvert.DeserializeObject<List<MidTom>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<MidTom> Update(MidTom entity)
        {
            throw new NotImplementedException();
        }
    }
}
