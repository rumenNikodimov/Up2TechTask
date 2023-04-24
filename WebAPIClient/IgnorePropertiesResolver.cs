using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebAPIClient;

public class IgnorePropertiesResolver : DefaultContractResolver
{
    private readonly HashSet<string> _ignoreProps;
    public IgnorePropertiesResolver(params string[] propNamesToIgnore)
    {
        _ignoreProps = new HashSet<string>(propNamesToIgnore);
    }
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);
        if (_ignoreProps.Contains(property.PropertyName))
        {
            property.ShouldSerialize = _ => false;
        }
        return property;
    }
}