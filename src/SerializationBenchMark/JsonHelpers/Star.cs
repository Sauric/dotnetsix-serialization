using System;
using System.Text;
using System.Collections.Generic;

namespace SerializationBenchmark;

public sealed record Star
{
    public string Name { get; set; } = string.Empty;

    public string LongName { get; set; } = string.Empty;

    public decimal Mass { get; set; } = default;

    public int SatelliteNumber { get; set; } = default;

    public string[] OtherProperties { get; set; } = Array.Empty<string>();

    public override string ToString()
    {
        var sbld = new StringBuilder();
        sbld.Append(@"{""Name"":")
            .Append('"')
            .Append(Name)
            .Append("\",")
            .Append(@"""LongName"":")
            .Append('"')
            .Append(LongName)
            .Append("\",")
            .Append(@"""Mass"":")
            .Append(Mass)
            .Append(',')
            .Append(@"""SatelliteNumber"":")
            .Append(SatelliteNumber)
            .Append(',')
            .Append(@"""OtherProperties"":[");
        for(int i = 0; i < OtherProperties.Length; ++i)
        {
            sbld.Append('\"')
                .Append(OtherProperties[i])
                .Append('"');
            if(i != OtherProperties.Length - 1)
                sbld.Append(',');
        }
        return sbld.Append("]}").ToString();
    }
}
