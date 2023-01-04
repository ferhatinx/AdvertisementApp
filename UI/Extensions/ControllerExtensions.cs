using Common;
using Microsoft.AspNetCore.Mvc;

namespace UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponseT<T> response,string actionName, string controllName)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            if(response.ResponseType == ResponseType.ValidationError)
            {     
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            if (string.IsNullOrWhiteSpace(controllName))
            {
                return controller.RedirectToAction(actionName);
            }
            else 
            { 
                return controller.RedirectToAction(actionName, controllName);
            }
           
        }
        public static IActionResult ResponseView<T>(this Controller controller,IResponseT<T> response)
        {
            if(response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            return controller.View(response.Data);
        }
        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName)
        {
            if(response.ResponseType == ResponseType.NotFound)
                return  controller.NotFound();
            return controller.RedirectToAction(actionName);
        }


    }
}
