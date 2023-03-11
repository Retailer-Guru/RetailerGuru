using NJsonSchema.Generation;

namespace RetailerGuru.Api.Infrastructure
{
    public class FullSchemaNameGenerator : ISchemaNameGenerator
    {
        public string Generate(Type type)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return type.FullName.Replace(type.Namespace + ".", string.Empty);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
