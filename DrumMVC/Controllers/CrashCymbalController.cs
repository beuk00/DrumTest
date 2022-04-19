using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class CrashCymbalController : Controller
    {
        private readonly CrashCymbalRepository _crashCymbalRepository;

        public CrashCymbalController(CrashCymbalRepository crashCymbalRepository)
        {
            _crashCymbalRepository = crashCymbalRepository;
        }
    }
}
