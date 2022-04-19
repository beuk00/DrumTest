using DrumMVC.Models.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrumMVC.Components
{
    [ViewComponent(Name = "MainNavigation")]
    public class MainNavComponent : ViewComponent
    {
        private List<NavBarLinkViewModel> NavBarItems { get; set; }

        public MainNavComponent()
        {
            NavBarItems = new List<NavBarLinkViewModel>()
            {
                new NavBarLinkViewModel {Text = "DrumKits", Area = "", Controller = "DrumKit", Action = "AllDrumKits", IsActive = false},
               
            };

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            foreach (var navlink in NavBarItems)
            {
                if (this.RouteData.Values["controller"]?.ToString().ToLower() == navlink.Controller.ToLower()
                    && this.RouteData.Values["action"]?.ToString().ToLower() == navlink.Action.ToLower())
                {
                    navlink.IsActive = true;
                }
            }

            return await Task.FromResult(View(NavBarItems));
        }
    }
}
