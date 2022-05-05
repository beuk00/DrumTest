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
    internal class HiHatControllerRepository : BaseRepository<HiHatController>
    {
        private readonly string baseUrl = "https://localhost:44322/api/";

        public override Task<HiHatController> Create(HiHatController entity)
        {
            throw new NotImplementedException();
        }

        public override Task<HiHatController> Delete(HiHatController entity)
        {
            throw new NotImplementedException();
        }

        public override Task<HiHatController> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<HiHatController> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<HiHatController> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<HiHatController>> ListAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync($"{baseUrl}HiHatController");

                List<HiHatController> res = JsonConvert.DeserializeObject<List<HiHatController>>(response);

                return await Task.FromResult(res);
            }
        }

        public override Task<HiHatController> Update(HiHatController entity)
        {
            throw new NotImplementedException();
        }
    }
}
