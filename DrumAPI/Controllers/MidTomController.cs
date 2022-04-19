using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidTomController : ControllerCrudBase<MidTom, MidTomRepository>
    {
        public MidTomController(MidTomRepository midTomRepository) : base(midTomRepository)
        {

        }
    }
}
