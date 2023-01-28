using Microsoft.Extensions.Configuration.Json;

namespace NikprogServerClient.Models.Configuration
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
