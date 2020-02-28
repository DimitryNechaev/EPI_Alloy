using System;
using System.Linq;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Mvc;

namespace AlloyTraining.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ViewEnginesInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            #region Remove the Web Forms view engine

            var webforms = ViewEngines.Engines.SingleOrDefault(engine =>
                engine.GetType() == typeof(WebFormViewEngine));

            ViewEngines.Engines.Remove(webforms);

            #endregion

            #region Modify search paths for views

            var razor = ViewEngines.Engines.SingleOrDefault(engine =>
                engine.GetType() == typeof(RazorViewEngine)) as RazorViewEngine;

            // Remove support for Visual Basic Razor files

            razor.FileExtensions = new[] { "cshtml" };

            var paths = razor.MasterLocationFormats
                .Where(path => path.EndsWith("cshtml"))
                .ToList();

            // add extra search paths for pages, media, and blocks

            paths.Add("~/Views/Pages/{0}.cshtml");
            paths.Add("~/Views/Media/{0}.cshtml");
            paths.Add("~/Views/Blocks/{0}.cshtml");

            razor.MasterLocationFormats = paths.ToArray();
            razor.ViewLocationFormats = paths.ToArray();
            razor.PartialViewLocationFormats = paths.ToArray();

            #endregion
        }

        public void Uninitialize(InitializationEngine context) { }
    }
}