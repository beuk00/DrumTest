using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class KickRepository : Repository<Kick>
    {
        public KickRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
