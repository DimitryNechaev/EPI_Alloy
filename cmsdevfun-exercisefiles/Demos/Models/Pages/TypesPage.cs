using AlloyTraining.Business.SelectionFactories; // WorkStatusSelectionFactory
using AlloyTraining.Models.POCOs; // Person
using EPiServer; // Url
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors; // CollectionEditorDescriptor
using EPiServer.Core; // PageData, XhtmlString
using EPiServer.DataAnnotations; // [ContentType]
using EPiServer.Shell.ObjectEditing; // [SelectOne]
using EPiServer.SpecializedProperties; // LinkItemCollection
using EPiServer.Web; // UIHint.Textarea
using EPiServer.XForms; // XForm
using System; // DateTime
using System.Collections.Generic; // IList<T>
using System.ComponentModel.DataAnnotations; // [UIHint], [StringLength], [Display], [RegularExpression]

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "Types", 
        GUID = "57fa8702-8a82-469b-8b79-9dac824d2636", 
        Description = "Use this to explore property types.")]
    public class TypesPage : PageData
    {
        #region Supported .NET types

        public virtual string ShortText { get; set; }

        [UIHint(UIHint.Textarea)]
        public virtual string LongText { get; set; }

        [StringLength(65, MinimumLength = 5)]
        public virtual string MetaTitle { get; set; }

        [RegularExpression(@"[a-z0-9\.]+@[a-z0-9\.]+", ErrorMessage = "Enter a valid email address.")]
        public virtual string ContactAddress { get; set; }

        [SelectOne(SelectionFactoryType = typeof(WorkStatusSelectionFactory))]
        public virtual string WorkStatus { get; set; }

        [SelectMany(SelectionFactoryType = typeof(WorkStatusSelectionFactory))]
        public virtual string WorkStatuses { get; set; }

        [Display(GroupName = ".NET Types")]
        public virtual bool OnOrOff { get; set; }

        [Display(GroupName = ".NET Types")]
        public virtual int WholeNumber { get; set; }

        [Display(GroupName = ".NET Types")]
        public virtual double RealNumber { get; set; }

        [Display(GroupName = ".NET Types")]
        public virtual DateTime When { get; set; }

        #endregion

        #region Episerver types

        [Display(GroupName = "Episerver Types")]
        public virtual XhtmlString RichText { get; set; }

        [Display(GroupName = "Episerver Types")]
        public virtual Url LinkToAnything { get; set; }

        [Display(GroupName = "Episerver Types")]
        [UIHint(UIHint.Image)]
        public virtual Url LinkToImage { get; set; }

        [Display(GroupName = "Episerver Types")]
        public virtual LinkItemCollection LinksToAnything { get; set; }

        [Display(GroupName = "Episerver Types")]
        public virtual XForm CustomForm { get; set; }

        [Display(GroupName = "Episerver Types")]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<Person>))]
        public virtual IList<Person> People { get; set; }

        #endregion

        #region Content reference types

        [Display(GroupName = "Content Reference Types")]
        public virtual ContentReference SingleContentItem { get; set; }

        [Display(GroupName = "Content Reference Types")]
        [UIHint(UIHint.Image)]
        public virtual ContentReference SingleImage { get; set; }

        [Display(GroupName = "Content Reference Types")]
        [UIHint(UIHint.MediaFile)]
        public virtual ContentReference SingleMediaFile { get; set; }

        [Display(GroupName = "Content Reference Types")]
        public virtual PageReference SinglePage { get; set; }

        [Display(GroupName = "Content Reference Types")]
        [AllowedTypes(typeof(StartPage), typeof(TypesPage))]
        public virtual PageReference SingleStartOrTypesPage { get; set; }

        [Display(GroupName = "Content Reference Types")]
        public virtual ContentArea MultipleContentItems { get; set; }

        [Display(GroupName = "Content Reference Types")]
        [AllowedTypes(typeof(PageData))]
        public virtual ContentArea MultiplePages { get; set; }

        [Display(GroupName = "Content Reference Types", Order = 1)]
        [AllowedTypes(typeof(PageData))]
        public virtual IList<ContentReference> MultiplePagesList { get; set; }

        #endregion
    }
}