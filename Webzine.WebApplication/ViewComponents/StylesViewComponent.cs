using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.WebApplication.ViewComponents
{
    public class StylesViewComponent : ViewComponent
    {
        private IStyleRepository _styleRepository;

        public StylesViewComponent(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_styleRepository.FindAll());
        }

    }
}
