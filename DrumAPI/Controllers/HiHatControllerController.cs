using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiHatControllerController : ControllerCrudBase<HiHatController, HiHatControllerRepository>
    {
        public HiHatControllerController(HiHatControllerRepository hiHatControllerRepository) : base(hiHatControllerRepository)
        {

        }
    }
}
