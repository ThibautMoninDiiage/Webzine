using Microsoft.AspNetCore.Mvc.Filters;

namespace Webzine.WebApplication.Filtres
{
    public class LoggerActionFilter : IActionFilter, IExceptionFilter
    {
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
        }
    }
}
