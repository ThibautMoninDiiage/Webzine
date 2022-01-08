using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            {
                return View();
            }
        }

    }
}
