using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnareDrumController : ControllerCrudBase<SnareDrum, SnareDrumRepository>
    {
        public SnareDrumController(SnareDrumRepository snareDrumRepository) : base(snareDrumRepository)
        {

        }
    }
}
