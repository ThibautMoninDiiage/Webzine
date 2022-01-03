using System;
using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.WebApplication.ViewModels
{
    public class BaseViewModel
    {
        public IEnumerable<Style> Styles => StyleFactory.CreateStyles();
    }
}
