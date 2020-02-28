namespace AlloyDemo.Models.Pages
{
    [SiteContentType(DisplayName = "Object Cache", 
        GroupName = Global.GroupNames.Specialized,
        Description = "View the contents of the object cache.")]
    [SiteImageUrl]
    [AvailableContentTypes(IncludeOn = new[] { typeof(StartPage) })]
    public class ObjectCachePage : SitePageData
    {
    }
}