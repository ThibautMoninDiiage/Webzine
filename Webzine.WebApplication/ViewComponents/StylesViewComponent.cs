using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.WebApplication.ViewComponents
{
    public class StylesViewComponent : ViewComponent
    {
        public StylesViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(StyleFactory.CreateStyles());
        }

    }
}
