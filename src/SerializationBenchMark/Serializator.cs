using System;
using System.IO;
using System.Text.Json;

namespace SerializationBenchmark;

public sealed class Serializator
{
    public string Serialize(Universe targetObjects)
        => JsonSerializer.Serialize(targetObjects);

    public string SerializeFaster(Universe targetObjects)
        => JsonSerializer.Serialize(targetObjects, UniverseJsonContext.Default.Universe);

    public string SerializeNS(Universe targetObjects)
        => Newtonsoft.Json.JsonConvert.SerializeObject(targetObjects);

    public string SerializeM(Universe targetObject)
        => targetObject.ToString();

    public string Utf8Serialize(Universe targetObjects)
    {
        using MemoryStream ms = new();
        using Utf8JsonWriter jw = new(ms);

        JsonSerializer.Serialize(jw, targetObjects);

        ms.Position = 0;
        using var reader = new StreamReader(ms);

        return reader.ReadToEnd();
    }

    public string Utf8SerializeFaster(Universe targetObjects)
    {
        using MemoryStream ms = new();
        using Utf8JsonWriter jw = new(ms);

        var serializator = 
            UniverseJsonContext.Default?.Universe?.SerializeHandler 
            ?? throw new ArgumentNullException();

        serializator.Invoke(jw, targetObjects);

        ms.Position = 0;
        using var reader = new StreamReader(ms);

        return reader.ReadToEnd();
    }
}
