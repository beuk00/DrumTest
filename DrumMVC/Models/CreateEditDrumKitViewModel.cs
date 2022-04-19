using DrumLib.Models;
using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrumMVC.Models
{
    public class CreateEditDrumKitViewModel
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

        public CreateEditDrumKitViewModel(DrumKitRepository drumKitRepository, ClosedHiHatRepository closedHiHatRepository, OpenHiHatRepository openHiHatRepository, CrashCymbalRepository crashCymbalRepository, FloorTomRepository floorTomRepository, HighTomRepository highTomRepository, HiHatControllerRepository hiHatControllerRepository, KickRepository kickRepository, MidTomRepository midTomRepository, RideCymbalRepository rideCymbalRepository, SnareDrumRepository snareDrumRepository)
        {
            _drumKitRepository = drumKitRepository;
            _closedHiHatRepository = closedHiHatRepository;
            _openHiHatRepository = openHiHatRepository;
            _crashCymbalRepository = crashCymbalRepository;
            _floorTomRepository = floorTomRepository;
            _highTomRepository = highTomRepository;
            _hiHatControllerRepository = hiHatControllerRepository;
            _kickRepository = kickRepository;
            _midTomRepository = midTomRepository;
            _rideCymbalRepository = rideCymbalRepository;
            _SnareDrumRepository = snareDrumRepository;
        }

        public CreateEditDrumKitViewModel()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a DrumKit name!")]
        [Display(Name = "DrumKit name")]
        public string DrumKitName { get; set; }

        [Required(ErrorMessage = "Please select a ClosedHiHat!")]
        [Display(Name = "ClosedHiHat")]
        public int ClosedHiHatId { get; set; }
        public IEnumerable<SelectListItem> ClosedHiHats
        {
            get
            {
                if (_closedHiHatRepository != null)
                {
                    return ((List<ClosedHiHat>)_closedHiHatRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a OpenHiHat!")]
        [Display(Name = "OpenHiHat")]
        public int OpenHiHatId { get; set; }
        public IEnumerable<SelectListItem> OpenHiHats
        {
            get
            {
                if (_openHiHatRepository != null)
                {
                    return ((List<OpenHiHat>)_openHiHatRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a CrashCymbal!")]
        [Display(Name = "CrashCymbal")]
        public int CrashCymbalId { get; set; }
        public IEnumerable<SelectListItem> CrashCymbals
        {
            get
            {
                if (_crashCymbalRepository != null)
                {
                    return ((List<CrashCymbal>)_crashCymbalRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a FloorTom!")]
        [Display(Name = "FloorTom")]
        public int FloorTomId { get; set; }
        public IEnumerable<SelectListItem> FloorToms
        {
            get
            {
                if (_floorTomRepository != null)
                {
                    return ((List<FloorTom>)_floorTomRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a HighTom!")]
        [Display(Name = "HighTom")]
        public int HighTomId { get; set; }
        public IEnumerable<SelectListItem> HighToms
        {
            get
            {
                if (_highTomRepository != null)
                {
                    return ((List<HighTom>)_highTomRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a HiHatController!")]
        [Display(Name = "HiHatController")]
        public int HiHatControllerId { get; set; }
        public IEnumerable<SelectListItem> HiHatControllers
        {
            get
            {
                if (_hiHatControllerRepository != null)
                {
                    return ((List<HiHatController>)_hiHatControllerRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a Kick!")]
        [Display(Name = "Kick")]
        public int KickId { get; set; }
        public IEnumerable<SelectListItem> Kicks
        {
            get
            {
                if (_kickRepository != null)
                {
                    return ((List<Kick>)_kickRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a MidTom!")]
        [Display(Name = "MidTom")]
        public int MidTomId { get; set; }
        public IEnumerable<SelectListItem> MidToms
        {
            get
            {
                if (_midTomRepository != null)
                {
                    return ((List<MidTom>)_midTomRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a RideCymbal!")]
        [Display(Name = "RideCymbal")]
        public int RideCymbalId { get; set; }
        public IEnumerable<SelectListItem> RideCymbals
        {
            get
            {
                if (_rideCymbalRepository != null)
                {
                    return ((List<RideCymbal>)_rideCymbalRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }

        [Required(ErrorMessage = "Please select a SnareDrum!")]
        [Display(Name = "SnareDrum")]
        public int SnareDrumId { get; set; }
        public IEnumerable<SelectListItem> SnareDrums
        {
            get
            {
                if (_SnareDrumRepository != null)
                {
                    return ((List<SnareDrum>)_SnareDrumRepository.ListAll().Result).ConvertAll(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                return null;
            }
        }


    }
}
