using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrumKitController : ControllerCrudBase<DrumKit, DrumKitRepository>
    {
        public DrumKitController(DrumKitRepository drumKitRepository) : base(drumKitRepository)
        {

        }
    }
}
