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
    internal class FloorTomRepository : BaseRepository<FloorTom>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<FloorTom> Create(FloorTom entity)
        {
            throw new NotImplementedException();
        }

        public override Task<FloorTom> Delete(FloorTom entity)
        {
            throw new NotImplementedException();
        }

        public override Task<FloorTom> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<FloorTom> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<FloorTom> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<FloorTom>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}FloorTom");

                List<FloorTom> res = JsonConvert.DeserializeObject<List<FloorTom>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<FloorTom> Update(FloorTom entity)
        {
            throw new NotImplementedException();
        }
    }
}
