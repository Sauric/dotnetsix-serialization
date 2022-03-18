using System.Collections.Generic;
using System.Text.Json;

namespace SerializationBenchmark;

public static class Objects
{
    public static readonly Universe tinyObject;

    public static readonly string tinyObjectString;

    public static readonly Universe smallObject;

    public static readonly string smallObjectString;

    public static readonly Universe bigObject;

    public static readonly string bigObjectString;

    public static readonly Universe hugeObject;

    public static readonly string hugeObjectString;

    static Objects()
    {
        tinyObject = new()
        {
            Stars = new Star[]
            {
                new()
                {
                    Name = "Saturn",
                    LongName = "Saturn is bad",
                    Mass = 95.16M,
                    SatelliteNumber = 82,
                    OtherProperties = new string[] {"a", "asda", "Asdasdasd"}
                }
            }
        };
        tinyObjectString = JsonSerializer.Serialize(tinyObject);
        
        smallObject = new Universe()  
        {
            Stars = new Star[]
            {
                new()
                {
                    Name = "Saturn",
                    LongName = "Saturn",
                    Mass = 95.16M,
                    SatelliteNumber = 82,
                    OtherProperties = new string[] {"a", "asda", "Asdasdasd"}
                },
                new()
                {
                    Name = "Jupiter",
                    LongName = "Jupiter is big",
                    Mass = 317.8M,
                    SatelliteNumber = 79,
                    OtherProperties = new string[] {"ss", "s", "Asdasdasd", "strings"}
                }
            }
        };
        smallObjectString = JsonSerializer.Serialize(smallObject);

        bigObject = GenerateHugeTargetObject(GenerateStringArray(25), 25);
        bigObjectString = JsonSerializer.Serialize(bigObject);

        hugeObject = GenerateHugeTargetObject(GenerateStringArray(100), 50);
        hugeObjectString = JsonSerializer.Serialize(hugeObject);
    }

    public static string[] GenerateStringArray(int size)
    {
        var arr = new string[size];
        for (int i = 0; i < size; ++i)
            arr[i] = new string('#', 100);
        return arr;
    }

    public static Universe GenerateHugeTargetObject(string[] fields, int size)
    {
        var arr = new Star[size];
        for (int i = 0; i < size; ++i)
            arr[i] = new()
            {
                Name = "Jupiter",
                LongName = "Jupiter is good)",
                Mass = 317.8M,
                SatelliteNumber = 79,
                OtherProperties = fields
            };

        return new() 
        { 
            Stars = arr 
        };
}
}