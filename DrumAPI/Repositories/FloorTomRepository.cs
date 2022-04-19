using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class FloorTomRepository : Repository<FloorTom>
    {
        public FloorTomRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
