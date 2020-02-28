using AlloyDemo.Models.Pages;
using System.Collections;
using System.Collections.Generic;

namespace AlloyDemo.Models.ViewModels
{
    public class ObjectCachePageViewModel : PageViewModel<ObjectCachePage>
    {
        public IEnumerable<DictionaryEntry> CachedItems { get; set; }

        public string FilteredBy { get; set; }

        public ObjectCachePageViewModel(ObjectCachePage currentPage) : base(currentPage)
        {
        }
    }
}