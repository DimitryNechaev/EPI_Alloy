using AlloyTraining.Business.ExtensionMethods;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Security;
using System.Linq;
using System.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        public SearchPageController(IContentLoader loader) : base(loader)
        {
        }

        public ActionResult Index(SearchPage currentPage, string q)
        {
            var viewmodel = new SearchPageViewModel(currentPage);

            viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            viewmodel.MenuPages = FilterForVisitor.Filter(
                loader.GetChildren<SitePageData>(ContentReference.StartPage))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            viewmodel.Section = currentPage.ContentLink.GetSection();

            if (!string.IsNullOrWhiteSpace(q))
            {
                var query = SearchClient.Instance
                    .Search<SitePageData>() // 1. only pages
                    .For(q)                 // 2. free-text query
                    // 3. only what the current user can read
                    .FilterForVisitor()
                    // 4. only under the Start page (to exclude Wastebasket)
                    .FilterOnCurrentSite();

                var results = query.GetContentResult();

                viewmodel.SearchText = q;

                viewmodel.SearchResults = results
                    .Select(x => new Result
                    {
                        Title = x.MetaTitle ?? x.Name,
                        Description = x.MetaDescription?.TruncateAtWord(20),
                        Url = x.PageLink.ExternalURLFromReference()
                    }).ToList();
            }
            return View(viewmodel);
        }
    }
}