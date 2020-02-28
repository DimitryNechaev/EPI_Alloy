using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlloyDemo.Models.Pages
{
    [ContentType(DisplayName = "Property Types Demo",
        GUID = "45c1248f-37bf-42e1-ad2f-e67d76a4423d",
        Description = "Use this page to demonstrate various types used for properties.")]
    [AvailableContentTypes(IncludeOn = new[] { typeof(StartPage) })]
    public class PropertyTypesDemoPage : PageData
    {
        // Text

        [Display(Name = "Rich text", Order = 10, GroupName = PropertyTypesDemoPageTabs.Text)]
        public virtual XhtmlString RichText { get; set; }

        [CultureSpecific]
        [Display(Name = "Localizable rich text", Order = 20, GroupName = PropertyTypesDemoPageTabs.Text)]
        public virtual XhtmlString LocalizableRichText { get; set; }

        [Display(Name = "Single line text", Order = 30, GroupName = PropertyTypesDemoPageTabs.Text)]
        public virtual string SingleLineText { get; set; }

        [StringLength(15, MinimumLength = 5, ErrorMessage = "Must be between 5 and 15 characters.")]
        [Display(Name = "Single line text (5-15 chars)", Order = 40, GroupName = PropertyTypesDemoPageTabs.Text)]
        public virtual string SingleLineText5to15chars { get; set; }

        [UIHint(UIHint.Textarea)]
        [Display(Name = "Multi-line text", Order = 50, GroupName = PropertyTypesDemoPageTabs.Text)]
        public virtual string MultilineText { get; set; }

        // Numbers

        [Display(Name = "Integer", Order = 10, GroupName = PropertyTypesDemoPageTabs.Numbers)]
        public virtual int Integer { get; set; }

        [Range(18, 65, ErrorMessage = "Must be between 18 and 65.")]
        [Display(Name = "Integer (18-65)", Order = 20, GroupName = PropertyTypesDemoPageTabs.Numbers)]
        public virtual int Integer18to65 { get; set; }

        [Display(Name = "Float", Order = 30, GroupName = PropertyTypesDemoPageTabs.Numbers)]
        [CultureSpecific]
        public virtual double Float { get; set; }

        [Display(Name = "Day of week", Order = 40, GroupName = PropertyTypesDemoPageTabs.Numbers)]
        [Range(0, 6, ErrorMessage = "Must be between 0 (Sunday) and 6 (Saturday).")]
        public virtual DayOfWeek DayOfWeek { get; set; }

        [SelectOne(SelectionFactoryType = typeof(DayOfWeekSelectionFactory))]
        [Display(Name = "Day of week (drop-down)", Order = 50, GroupName = PropertyTypesDemoPageTabs.Numbers)]
        public virtual DayOfWeek DayOfWeekDropDown { get; set; }

        // References

        [Display(Name = "Reference a single content item", Order = 10, GroupName = PropertyTypesDemoPageTabs.References)]
        public virtual ContentReference ReferenceContentItem { get; set; }

        [Display(Name = "Reference a single page", Order = 20, GroupName = PropertyTypesDemoPageTabs.References)]
        public virtual PageReference ReferencePage { get; set; }

        [AllowedTypes(typeof(BlockData))]
        [Display(Name = "Reference a single block", Order = 30, GroupName = PropertyTypesDemoPageTabs.References)]
        public virtual ContentReference ReferenceBlock { get; set; }

        [UIHint(UIHint.Image)]
        [Display(Name = "Reference a single image", Order = 40, GroupName = PropertyTypesDemoPageTabs.References)]
        public virtual ContentReference ReferenceImage { get; set; }

        [Display(Name = "Reference multiple content items", Order = 50, GroupName = PropertyTypesDemoPageTabs.References)]
        public virtual ContentArea ReferenceContentItems { get; set; }

        [AllowedTypes(typeof(PageData))]
        [Display(Name = "Reference multiple pages (with a partial template)", Order = 60, GroupName = PropertyTypesDemoPageTabs.References)]
        public virtual ContentArea ReferencePages { get; set; }

        // Misc

        [Display(Name = "Single image URL", Order = 10, GroupName = PropertyTypesDemoPageTabs.Miscellaneous)]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual Url SingleImageUrl { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Video)]
        [Display(Name = "Multiple video URLs", Order = 20, GroupName = PropertyTypesDemoPageTabs.Miscellaneous)]
        public virtual LinkItemCollection MultipleVideoUrls { get; set; }

        [Display(Name = "Active check box", Order = 30, GroupName = PropertyTypesDemoPageTabs.Miscellaneous)]
        [CultureSpecific]
        public virtual bool Active { get; set; }
    }

    public static class PropertyTypesDemoPageTabs
    {
        public const string Text = "Text";
        public const string Numbers = "Numbers";
        public const string References = "References";
        public const string Miscellaneous = "Miscellaneous";
    }

    public class DayOfWeekSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var list = new List<SelectItem>();
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                list.Add(new SelectItem { Value = item, Text = Enum.GetName(typeof(DayOfWeek), item) });
            }
            return list;
        }
    }
}