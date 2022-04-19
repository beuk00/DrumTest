using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighTomController : ControllerCrudBase<HighTom, HighTomRepository>
    {
        public HighTomController(HighTomRepository highTomRepository) : base(highTomRepository)
        {

        }
    }
}
