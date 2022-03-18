using System.Text.Json;

namespace SerializationBenchmark;

public sealed class Deserializator
{
    public Universe? DeserializeNS(string json)
        => Newtonsoft.Json.JsonConvert.DeserializeObject<Universe>(json);

    public Universe? Deserialize(string json)
        => JsonSerializer.Deserialize<Universe>(json);

    public Universe? DeserializeCG(string json)
        => JsonSerializer.Deserialize<Universe>(json, UniverseJsonContext.Default.Universe);
}