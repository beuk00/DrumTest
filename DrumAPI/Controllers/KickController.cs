using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KickController : ControllerCrudBase<Kick, KickRepository>
    {
        public KickController(KickRepository kickRepository) : base(kickRepository)
        {

        }
    }
}
