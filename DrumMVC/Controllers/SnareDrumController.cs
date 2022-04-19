using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class SnareDrumController : Controller
    {
        private readonly SnareDrumRepository _snareDrumRepository;

        public SnareDrumController(SnareDrumRepository snareDrumRepository)
        {
            _snareDrumRepository = snareDrumRepository;
        }
    }
}
