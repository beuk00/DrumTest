namespace DrumMVC.Models.Components
{
    public class NavBarLinkViewModel
    {
        public string Text { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; }
    }
}
