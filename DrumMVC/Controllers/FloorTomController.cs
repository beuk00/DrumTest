using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class FloorTomController : Controller
    {
        private readonly FloorTomRepository _floorTomRepository;

        public FloorTomController(FloorTomRepository floorTomRepository)
        {
            _floorTomRepository = floorTomRepository;
        }
    }
}
