using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorTomController : ControllerCrudBase<FloorTom, FloorTomRepository>
    {
        public FloorTomController(FloorTomRepository floorTomRepository) : base(floorTomRepository)
        {

        }
    }
}
