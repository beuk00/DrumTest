using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideCymbalController : ControllerCrudBase<RideCymbal, RideCymbalRepository>
    {
        public RideCymbalController(RideCymbalRepository rideCymbalRepository) : base(rideCymbalRepository)
        {

        }
    }
}
