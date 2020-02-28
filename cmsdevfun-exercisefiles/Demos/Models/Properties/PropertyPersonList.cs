using AlloyTraining.Models.POCOs; // Person
using EPiServer.Core; // PropertyList
using EPiServer.Framework.Serialization; // IObjectSerializer
using EPiServer.Framework.Serialization.Internal; // ObjectSerializerFactory
using EPiServer.PlugIn; // PropertyDefinitionTypePlugIn
using EPiServer.ServiceLocation; // Injected

namespace AlloyTraining.Models.Properties
{
    [PropertyDefinitionTypePlugIn(DisplayName = "List of people i.e. IList<Person>",
        Description = "An editable list of Person instances.")]
    public class PropertyPersonList : PropertyList<Person>
    {
        public Injected<ObjectSerializerFactory> injectedSerializer;

        private IObjectSerializer serializer;

        public PropertyPersonList()
        {
            serializer = injectedSerializer.Service.GetSerializer("application/json");
        }

        public override PropertyData ParseToObject(string value)
        {
            ParseToSelf(value);
            return this;
        }

        protected override Person ParseItem(string value)
        {
            return serializer.Deserialize<Person>(value);
        }
    }
}