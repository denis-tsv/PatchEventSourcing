using System.Text.Json.Serialization;
using System.Text.Json;

namespace Api.Validators;

public class PatchPropertyConverter<T> : JsonConverter<PatchProperty<T>>
{
    public override bool HandleNull => true;

    public override void Write(Utf8JsonWriter writer, PatchProperty<T> value, JsonSerializerOptions options)
        => throw new NotImplementedException();

    public override PatchProperty<T> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = JsonSerializer.Deserialize<T>(ref reader, options);
        return new PatchProperty<T>(value);
    }
}

public class PatchPropertyConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(PatchProperty<>);

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        => (JsonConverter?)Activator.CreateInstance(
            typeof(PatchPropertyConverter<>).MakeGenericType(typeToConvert.GenericTypeArguments[0])
        );
}