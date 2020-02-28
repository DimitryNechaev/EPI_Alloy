using EmptyDemo.Controllers;
using EmptyDemo.Models.Pages;
using EPiServer.DataAbstraction;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace EmptyDemo.Business.ViewRegistration
{
    public class TemplateRegistrator : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            // register two templates for StartPage

            var defaultTemplate = new TemplateModel
            {
                TemplateType = typeof(MuppetController),
                Default = true,
                Name = "MuppetController",
                DisplayName = "Start Page Template (Default)",
                Description = "Default template for StartPage",
            };

            var alternativeTemplate = new TemplateModel
            {
                TemplateType = typeof(StartPageController),
                Name = "StartPageController",
                Description = "Alternative template for StartPage",
            };

            viewTemplateModelRegistrator.Add(typeof(StartPage),
                defaultTemplate, alternativeTemplate);

            var tr = ServiceLocator.Current.GetInstance<TemplateResolver>();
        }
    }
}