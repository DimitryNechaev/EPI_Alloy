using EPiServer.DataAnnotations;
using EPiServer.Personalization;

namespace AlloyDemo.Models.Pages
{
    [SiteContentType(DisplayName = "Profile", 
        GUID = "a06d1d8a-4783-4ec7-be1b-994a9d5d5746", 
        Description = "Allow visitor to manage their own profile.")]
    [SiteImageUrl]
    [AvailableContentTypes(IncludeOn = new[] { typeof(StartPage) })]
    public class ProfilePage : SitePageData
    {
        [Ignore]
        public EPiServerProfile Profile { get; set; }
    }
}