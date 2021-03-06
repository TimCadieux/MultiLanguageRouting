using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;

namespace Project.Web.Helpers
{
    public class TranslationRoute
    {
        private static IEnumerable<Translated> Translations = new List<Translated>();
        private readonly IActionDescriptorCollectionProvider actionDescriptorCollectionProvider;

        public TranslationRoute(IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider)
        {
            actionDescriptorCollectionProvider = _actionDescriptorCollectionProvider;

            if (!Translations.Any())
                Translations = GetTranslations();
        }

        private IEnumerable<Translated> GetTranslations()
        {
            var actions = actionDescriptorCollectionProvider.ActionDescriptors.Items
                .Where(s => (s as ControllerActionDescriptor).MethodInfo.GetCustomAttributes<TranslatedRouteAttribute>().Any())
                .Select(s => new Translated
                {
                    Name = (s as ControllerActionDescriptor).ActionName, // + "." + (s as ControllerActionDescriptor).ControllerName
                    TranslatedRoutes = (s as ControllerActionDescriptor).MethodInfo.GetCustomAttributes<TranslatedRouteAttribute>().Select(c => new TranslatedRoute
                    {
                        Culture = c.Culture.ToLower(),
                        Translated = c.TranslatedRoute.ToLower()
                    }).ToList()
                });

            var controllers = actionDescriptorCollectionProvider.ActionDescriptors.Items
              .Where(s => (s as ControllerActionDescriptor).ControllerTypeInfo.GetCustomAttributes<TranslatedRouteAttribute>().Any())
              .Select(s => new Translated
              {
                  Name = (s as ControllerActionDescriptor).ControllerName,
                  TranslatedRoutes = (s as ControllerActionDescriptor).ControllerTypeInfo.GetCustomAttributes<TranslatedRouteAttribute>().Select(c => new TranslatedRoute
                  {
                      Culture = c.Culture.ToLower(),
                      Translated = c.TranslatedRoute.ToLower()
                  }).ToList()
              }).GroupBy(s => s.Name).Select(s => s.FirstOrDefault());

            return controllers.Concat(actions);
        }

        public string Resolve(string culture, string value)
        {
            var normalizedCulture = culture.ToLowerInvariant();
            var normalizedValue = value.ToLowerInvariant();
            //normalizedValue = normalizedValue.Split(".")[0];
            var translation = Translations.FirstOrDefault(s => s.TranslatedRoutes
                .Any(s => s.Translated.ToLowerInvariant() == normalizedValue && s.Culture.ToLowerInvariant() == normalizedCulture));
            if (translation != null)
            {
                return translation.Name;
            }

            return null;
        }

        public string ResolveLinks(string culture, string value)
        {
            var normalizedCulture = culture.ToLowerInvariant();
            var normalizedValue = value.ToLowerInvariant();

            var translation = Translations.FirstOrDefault(s => s.Name.ToLowerInvariant() == normalizedValue);
            var translated = translation?.TranslatedRoutes.FirstOrDefault(s => s.Culture.ToLowerInvariant() == normalizedCulture);
            if (translated != null)
            {
                return translated.Translated;
            }

            return null;
        }

    }
}
