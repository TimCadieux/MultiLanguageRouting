using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace Project.Web.Helpers
{
    public class TranslationTransformer : DynamicRouteValueTransformer
    {
        private readonly TranslationRoute translationRoute;

        public TranslationTransformer(TranslationRoute _translationRoute)
        {
            this.translationRoute = _translationRoute;
        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            if (!values.ContainsKey("culture") || !values.ContainsKey("controller") || !values.ContainsKey("action"))
                return values;

            var culture = (string)values["culture"];
            var controller = translationRoute.Resolve(culture, (string)values["controller"]);
            if (controller == null)
                return values;
            values["controller"] = controller;

            var action = translationRoute.Resolve(culture, (string)values["action"]);
            if (action == null)
                return values;
            values["action"] = action;

            return values;
        }

    }
}
