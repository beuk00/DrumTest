using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class KickController : Controller
    {
        private readonly KickRepository _kickRepository;

        public KickController(KickRepository kickRepository)
        {
            _kickRepository = kickRepository;
        }
    }
}
