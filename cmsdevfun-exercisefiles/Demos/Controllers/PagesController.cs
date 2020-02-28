using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AlloyDemo.Controllers
{
    public class PagesController : ApiController
    {
        private readonly IContentLoader loader;

        public PagesController()
        {
            this.loader = ServiceLocator.Current.GetInstance<IContentLoader>();
        }

        public class Page
        {
            public string Name { get; set; }
            public string Reference { get; set; }
        }

        // GET api/pages
        public IEnumerable<Page> Get()
        {
            var childrenOfStart = loader.GetChildren<PageData>(ContentReference.StartPage);
            var filtered = FilterForVisitor.Filter(childrenOfStart).Cast<PageData>();
            var pages = filtered.Select(page => new Page { Name = page.Name, Reference = page.ContentLink.ToString() });
            return pages;
        }

        // GET api/pages/5
        public IEnumerable<Page> Get(string id)
        {
            if (ContentReference.TryParse(id, out ContentReference reference))
            {
                var children = loader.GetChildren<PageData>(reference);
                var filtered = FilterForVisitor.Filter(children).Cast<PageData>();
                var pages = filtered.Select(page => new Page { Name = page.Name, Reference = page.ContentLink.ToString() });
                return pages;
            }
            return null;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}