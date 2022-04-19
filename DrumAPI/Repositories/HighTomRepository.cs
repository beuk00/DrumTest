using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class HighTomRepository : Repository<HighTom>
    {
        public HighTomRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
