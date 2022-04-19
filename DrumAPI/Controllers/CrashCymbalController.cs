using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrashCymbalController : ControllerCrudBase<CrashCymbal, CrashCymbalRepository>
    {
        public CrashCymbalController(CrashCymbalRepository crashCymbalRepository) : base(crashCymbalRepository)
        {

        }
    }
}
