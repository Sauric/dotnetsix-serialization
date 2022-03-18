using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonSerialization;


[JsonSerializable(typeof(IReadOnlyCollection<TargetObject>))]
internal partial class TargetObjectSpeedUp : JsonSerializerContext
{

}
