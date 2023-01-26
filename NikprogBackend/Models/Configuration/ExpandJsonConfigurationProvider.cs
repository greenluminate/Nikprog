using Microsoft.Extensions.Configuration.Json;

namespace NikprogBackend.Models.Configuration
{
    public class ExpandJsonConfigurationProvider : JsonConfigurationProvider
    {
        public ExpandJsonConfigurationProvider(ExpandJsonConfigurationSource source)
            : base(source) { }

        public override void Load()
        {
            base.Load();
            Data = Data.ToDictionary(
                x => x.Key,
                x => Environment.ExpandEnvironmentVariables(x.Value),
                StringComparer.OrdinalIgnoreCase);
        }
    }
}
