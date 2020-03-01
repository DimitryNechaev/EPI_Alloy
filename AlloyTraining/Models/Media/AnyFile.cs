using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Any File",
        // your code will have a GUID 
        Description = "Use this to upload any type of file.")]
    public class AnyFile : MediaData
    {
    }
}