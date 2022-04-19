using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class MidTomRepository : Repository<MidTom>
    {
        public MidTomRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
