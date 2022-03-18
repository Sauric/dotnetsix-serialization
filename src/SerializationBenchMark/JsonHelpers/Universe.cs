using System;
using System.Text;
using System.Collections.Generic;

namespace SerializationBenchmark;

public sealed record Universe
{
    public Star[] Stars { get; set; } = Array.Empty<Star>();
    
    public override string ToString()
    {
        var sbld = new StringBuilder();
        sbld.Append(@"{""Stars"":[");
        for(int i = 0; i < Stars.Length; ++i)
        {
            sbld.Append(Stars[i].ToString());
            if(i != Stars.Length - 1)
            {
                sbld.Append(',');
            }
        }
        sbld.Append("]}");
        return sbld.ToString();
    }
}