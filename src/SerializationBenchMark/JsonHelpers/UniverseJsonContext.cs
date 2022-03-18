using System.Text.Json.Serialization;

namespace SerializationBenchmark;

[JsonSerializable(typeof(Universe))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
public partial class UniverseJsonContext : JsonSerializerContext {}
