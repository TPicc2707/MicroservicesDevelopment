using System.Collections.Generic;
using System.Linq;

namespace Microservices.WebAssemblyBlazor.Services
{
    public class PageHistoryState
    {
        private List<string> previousPages;
        public PageHistoryState()
        {
            previousPages = new List<string>();
        }

        public void AddPageToHistory(string pageName)
        {
            previousPages.Add(pageName);
        }

        public string GetGoBackPage()
        {
            if(previousPages.Count > 1)
            {
                return previousPages.ElementAt(previousPages.Count - 1);
            }
            return previousPages.FirstOrDefault();
        }

        public bool CanGoBack()
        {
            return previousPages.Count >= 1;
        }
    }
}
