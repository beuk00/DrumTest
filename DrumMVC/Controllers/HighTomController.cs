using DrumMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumMVC.Controllers
{
    public class HighTomController : Controller
    {
        private readonly HighTomRepository _highTomRepository;

        public HighTomController(HighTomRepository highTomRepository)
        {
            _highTomRepository = highTomRepository;
        }
    }
}
