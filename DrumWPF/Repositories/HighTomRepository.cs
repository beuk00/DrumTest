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
    internal class HighTomRepository : BaseRepository<HighTom>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<HighTom> Create(HighTom entity)
        {
            throw new NotImplementedException();
        }

        public override Task<HighTom> Delete(HighTom entity)
        {
            throw new NotImplementedException();
        }

        public override Task<HighTom> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<HighTom> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<HighTom> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<HighTom>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}HighTom");

                List<HighTom> res = JsonConvert.DeserializeObject<List<HighTom>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<HighTom> Update(HighTom entity)
        {
            throw new NotImplementedException();
        }
    }
}
