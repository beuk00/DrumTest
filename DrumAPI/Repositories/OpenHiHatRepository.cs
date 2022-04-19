using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class OpenHiHatRepository : Repository<OpenHiHat>
    {
        public OpenHiHatRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
