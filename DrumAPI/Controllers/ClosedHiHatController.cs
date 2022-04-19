using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClosedHiHatController : ControllerCrudBase<ClosedHiHat, ClosedHiHatRepository>
    {
        public ClosedHiHatController(ClosedHiHatRepository closedHiHatRepository) : base(closedHiHatRepository)
        {

        }
    }
}
