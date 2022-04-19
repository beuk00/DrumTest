using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class ClosedHiHatRepository : Repository<ClosedHiHat>
    {
        public ClosedHiHatRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
