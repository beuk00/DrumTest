using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class CrashCymbalRepository : Repository<CrashCymbal>
    {
        public CrashCymbalRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
