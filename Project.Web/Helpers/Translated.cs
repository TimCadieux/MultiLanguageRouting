using System.Collections.Generic;

namespace Project.Web.Helpers
{
    public class Translated
    {
        public string Name { get; set; }
        public List<TranslatedRoute> TranslatedRoutes { get; set; } = new List<TranslatedRoute>();
    }
}
