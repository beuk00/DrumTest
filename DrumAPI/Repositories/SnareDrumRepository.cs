using DrumAPI.Data;
using DrumLib.Models;

namespace DrumAPI.Repositories
{
    public class SnareDrumRepository : Repository<SnareDrum>
    {
        public SnareDrumRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
