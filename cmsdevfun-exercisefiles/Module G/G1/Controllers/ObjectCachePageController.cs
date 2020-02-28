using AlloyDemo.Models.Pages;
using AlloyDemo.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace AlloyDemo.Controllers
{
    public class ObjectCachePageController : PageControllerBase<ObjectCachePage>
    {
        public ActionResult Index(ObjectCachePage currentPage, string filterBy)
        {
            var viewmodel = new ObjectCachePageViewModel(currentPage);

            var cachedEntries = HttpContext.Cache.Cast<DictionaryEntry>();

            switch (filterBy)
            {
                case "pages":
                    viewmodel.CachedItems = cachedEntries
                        .Where(item => item.Value is PageData);
                    break;
                case "content":
                    viewmodel.CachedItems = cachedEntries
                        .Where(item => item.Value is IContent);
                    break;
                default:
                    viewmodel.CachedItems = cachedEntries;
                    break;
            }

            viewmodel.FilteredBy = filterBy;

            return View(viewmodel);
        }
    }
}