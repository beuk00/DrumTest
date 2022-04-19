using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class RideCymbalController : Controller
    {
        private readonly RideCymbalRepository _rideCymbalRepository;

        public RideCymbalController(RideCymbalRepository rideCymbalRepository)
        {
            _rideCymbalRepository = rideCymbalRepository;
        }
    }
}
