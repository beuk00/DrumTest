using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class OpenHiHatController : Controller
    {
        private readonly OpenHiHatRepository _openHiHatRepository;

        public OpenHiHatController(OpenHiHatRepository openHiHatRepository)
        {
            _openHiHatRepository = openHiHatRepository;
        }
    }
}
