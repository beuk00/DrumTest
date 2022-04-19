using DrumAPI.Repositories;
using DrumLib.Models;
using DrumMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrumMVC.Controllers
{
    public class ClosedHiHatController : Controller
    {
        private readonly ClosedHiHatRepository _closedHiHatRepository;

        public ClosedHiHatController(ClosedHiHatRepository closedHiHatRepository)
        {
            _closedHiHatRepository = closedHiHatRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            ClosedHiHatOverviewViewModel vm = new ClosedHiHatOverviewViewModel();
            
            List<ClosedHiHat> items = new List<ClosedHiHat>();
            foreach (var cch in await _closedHiHatRepository.ListAll())
            {
                    items.Add(cch);
            };

            vm.ClosedHiHats = items;

            return View(vm);
        }
    }
}
