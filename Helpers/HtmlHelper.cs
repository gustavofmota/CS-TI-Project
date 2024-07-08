using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TI_Project.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            var currentAction = htmlHelper.ViewContext.RouteData.Values["action"].ToString();
            var currentController = htmlHelper.ViewContext.RouteData.Values["controller"].ToString();

            var cssClass = (controllerName == currentController && actionName == currentAction) ? "nav-link active font-weight-bold" : "nav-link";

            return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new { @class = cssClass });
        }
    }
}
