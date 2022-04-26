using DrumLib.Models;
using DrumMVC.Models;
using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrumMVC.Controllers
{
    public class DrumKitController : Controller
    {
        private readonly DrumKitRepository _drumKitRepository = null;
        private readonly ClosedHiHatRepository _closedHiHatRepository = null;
        private readonly OpenHiHatRepository _openHiHatRepository = null;
        private readonly CrashCymbalRepository _crashCymbalRepository = null;
        private readonly FloorTomRepository _floorTomRepository = null;
        private readonly HighTomRepository _highTomRepository = null;
        private readonly HiHatControllerRepository _hiHatControllerRepository = null;
        private readonly KickRepository _kickRepository = null;
        private readonly MidTomRepository _midTomRepository = null;
        private readonly RideCymbalRepository _rideCymbalRepository = null;
        private readonly SnareDrumRepository _SnareDrumRepository = null;

        public DrumKitController(DrumKitRepository drumKitRepository, ClosedHiHatRepository closedHiHatRepository, OpenHiHatRepository openHiHatRepository, CrashCymbalRepository crashCymbalRepository, FloorTomRepository floorTomRepository, HighTomRepository highTomRepository, HiHatControllerRepository hiHatControllerRepository, KickRepository kickRepository, MidTomRepository midTomRepository, RideCymbalRepository rideCymbalRepository, SnareDrumRepository snareDrumRepository)
        {
            _drumKitRepository = drumKitRepository;
            _closedHiHatRepository = closedHiHatRepository;
            _openHiHatRepository = openHiHatRepository;
            _crashCymbalRepository= crashCymbalRepository;
            _floorTomRepository = floorTomRepository;
            _highTomRepository = highTomRepository;
            _hiHatControllerRepository = hiHatControllerRepository;
            _kickRepository = kickRepository;
            _midTomRepository = midTomRepository;
            _rideCymbalRepository = rideCymbalRepository;
            _SnareDrumRepository = snareDrumRepository;
        }


        [HttpGet]
        public async Task<IActionResult> AllDrumKits()
        {
            DrumKitOverviewViewModel vm = new DrumKitOverviewViewModel();

            List<DrumKit> items = new List<DrumKit>();
            foreach (var dk in await _drumKitRepository.ListAll())
            {
                items.Add(dk);
            };

            vm.DrumKits = items;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _drumKitRepository.DeleteById(id);

            return RedirectToAction("AllDrumKits");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDrumKit(int id)
        {
            DrumKit drumKit = await _drumKitRepository.GetById(id);
            await _drumKitRepository.DeleteById(id);

            return RedirectToAction("AllDrumKits");
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateEditDrumKitViewModel vm = new CreateEditDrumKitViewModel(_drumKitRepository, _closedHiHatRepository, _openHiHatRepository, _crashCymbalRepository,_floorTomRepository,_highTomRepository,_hiHatControllerRepository,_kickRepository,_midTomRepository,_rideCymbalRepository,_SnareDrumRepository);
            return View("CreateEditDrumKit", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CreateEditDrumKitViewModel vm = new CreateEditDrumKitViewModel(_drumKitRepository, _closedHiHatRepository, _openHiHatRepository, _crashCymbalRepository, _floorTomRepository, _highTomRepository, _hiHatControllerRepository, _kickRepository, _midTomRepository, _rideCymbalRepository, _SnareDrumRepository);
            DrumKit drumKit = await _drumKitRepository.GetById(id);

            vm.Id = id;
            vm.DrumKitName = drumKit.Name;
            vm.ClosedHiHatId = drumKit.ClosedHiHatId;
            vm.OpenHiHatId = drumKit.OpenHiHatId;
            vm.CrashCymbalId = drumKit.CrashCymbalId;
            vm.FloorTomId = drumKit.FloorTomId;
            vm.HighTomId = drumKit.HighTomId;
            vm.HiHatControllerId = drumKit.HiHatControllerId;
            vm.KickId = drumKit.KickId;
            vm.MidTomId = drumKit.MidTomId;
            vm.RideCymbalId = drumKit.RideCymbalId;
            vm.SnareDrumId = drumKit.SnareDrumId;
            

            return View("CreateEditDrumKit", vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEditDrumKit(CreateEditDrumKitViewModel model)
        {

            if (ModelState.IsValid)
            {
                DrumKit drumKit = new DrumKit
                (
                    name: model.DrumKitName,
                    id : model.Id,
                    snareDrumId: model.SnareDrumId,
                    kickId: model.KickId,
                    openHiHatId: model.OpenHiHatId,
                    closedHiHatId : model.ClosedHiHatId,
                    hiHatControllerId: model.HiHatControllerId,
                    highTomId: model.HighTomId,
                    midTomId: model.MidTomId,
                    floorTomId: model.FloorTomId,
                    crashCymbalId : model.CrashCymbalId,
                    rideCymbalId: model.RideCymbalId

                );

                if (model.Id == 0)
                {
                    // create
                    await _drumKitRepository.Create(drumKit);
                }
                else
                {
                    // update
                    await _drumKitRepository.Update(drumKit);
                }

                return RedirectToAction("AllDrumKits", "DrumKit");
            }

            return View("CreateEditDrumKit", model);
        }
    }
}
