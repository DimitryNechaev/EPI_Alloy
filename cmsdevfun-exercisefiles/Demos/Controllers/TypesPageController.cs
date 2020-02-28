using AlloyTraining.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class TypesPageController : PageController<TypesPage>
    {
        public ActionResult Index(TypesPage currentPage)
        {
            return View(currentPage);
        }
    }
}