using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class MidTomController : Controller
    {
        private readonly MidTomRepository _midTomRepository;

        public MidTomController(MidTomRepository midTomRepository)
        {
            _midTomRepository = midTomRepository;
        }
    }
}
