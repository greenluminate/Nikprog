using Microsoft.Extensions.Configuration.Json;

namespace NikprogBackend.Models.Configuration
{
    public class ExpandJsonConfigurationSource : JsonConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new ExpandJsonConfigurationProvider(this);
        }
    }
}
