using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class RideCymbalRepository : Repository<RideCymbal>
    {
        public RideCymbalRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
