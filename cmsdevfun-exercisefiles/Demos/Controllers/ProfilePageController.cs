using AlloyDemo.Models.Pages;
using AlloyDemo.Models.ViewModels;
using EPiServer.Personalization;
using EPiServer.Web.Mvc;
using System.Web.Mvc;

namespace AlloyDemo.Controllers
{
    public class ProfilePageController : PageControllerBase<ProfilePage>
    {
        public ActionResult Index(ProfilePage currentPage)
        {
            var viewmodel = PageViewModel.Create(currentPage);
            if (EPiServerProfile.Enabled)
            {
                viewmodel.CurrentPage.Profile = EPiServerProfile.Current;
            }
            return View(viewmodel);
        }

        public ActionResult UpdateProfile(ProfilePage currentPage,
            string firstName, string lastName, string title, string company)
        {
            var current = EPiServerProfile.Current;

            current.FirstName = firstName;
            current.LastName = lastName;
            current.Company = company;
            current.Title = title;

            current.Save();

            return RedirectToAction("Index");
        }
    }
}