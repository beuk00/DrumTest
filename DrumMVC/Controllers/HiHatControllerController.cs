using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class HiHatControllerController : Controller
    {
        private readonly HiHatControllerRepository _hiHatControllerRepository;

        public HiHatControllerController(HiHatControllerRepository hiHatControllerRepository)
        {
            _hiHatControllerRepository = hiHatControllerRepository;
        }
    }
}
