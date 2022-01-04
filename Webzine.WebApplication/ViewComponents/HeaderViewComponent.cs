using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            {
                return View();
            }
        }
    }
}
