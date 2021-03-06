using System;

namespace Project.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class TranslatedRouteAttribute : Attribute
    {
        public TranslatedRouteAttribute(string culture, string translatedRoute)
        {
            Culture = culture;
            TranslatedRoute = translatedRoute;
        }

        public string Culture { get; }
        public string TranslatedRoute { get; }
    }
}
