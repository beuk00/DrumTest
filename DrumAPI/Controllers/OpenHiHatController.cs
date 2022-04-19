using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenHiHatController : ControllerCrudBase<OpenHiHat, OpenHiHatRepository>
    {
        public OpenHiHatController(OpenHiHatRepository openHiHatRepository) : base(openHiHatRepository)
        {

        }
    }
}
