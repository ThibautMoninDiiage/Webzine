using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Webzine.WebApplication.Filter
{
    public class LoggerActionFilter : IActionFilter, IExceptionFilter
    {
        private readonly ILogger<LoggerActionFilter> _logger;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logguer les informations en sortie de l'action
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Logguer les informations à l'entrée de l'action
        }

        public void OnException(ExceptionContext context)
        {
            // Logguer les exceptions et rediriger vers une page d'erreur
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Erreur",
                action = "Erreur"
            }));
        }
    }
}
