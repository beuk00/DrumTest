using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class HiHatControllerRepository : Repository<HiHatController>
    {
        public HiHatControllerRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
