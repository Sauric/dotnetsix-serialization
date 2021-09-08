using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialization;

[Serializable()]
sealed record TargetObject
{
    public string Field1 { get; init; }

    public string Field2 { get; init; }

    public string Field3 { get; init; }

    public string Field4 { get; init; }

    public IReadOnlyCollection<string> Fields { get; init; }

    public TargetObject(
        string field1 = "field1", string field2 = "field2", string field3 = "field3", 
        string field4 = "field4")
    {
        Field1 = field1;
        Field2 = field2;
        Field3 = field3;
        Field4 = field4;
        Fields = BuildArray();
    }

    private static IReadOnlyCollection<string> BuildArray()
    {
        var rnd = new Random(DateTime.Now.Millisecond);
        var list = new List<string>();
        var len = rnd.Next(TesterNames.MinArrLen, TesterNames.MaxArrLen);
        for (int i = 0; i < len; i++)
        {
            list.Add(new string('a', rnd.Next(25, 75)));
        }
        return list;
    }
}

