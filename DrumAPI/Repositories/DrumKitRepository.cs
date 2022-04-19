using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class DrumKitRepository : Repository<DrumKit>
    {
        public DrumKitRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
