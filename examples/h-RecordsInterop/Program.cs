/*
  _____                        _       _____       _
 |  __ \                      | |     |_   _|     | |
 | |__) |___  ___ ___  _ __ __| |___    | |  _ __ | |_ ___ _ __ ___  _ __
 |  _  // _ \/ __/ _ \| '__/ _` / __|   | | | '_ \| __/ _ \ '__/ _ \| '_ \
 | | \ \  __/ (_| (_) | | | (_| \__ \  _| |_| | | | ||  __/ | | (_) | |_) |
 |_|  \_\___|\___\___/|_|  \__,_|___/ |_____|_| |_|\__\___|_|  \___/| .__/
                                                                    | |
                                                                    |_|

Let's explore how Records interoperate with existing libraries

*/

using System;
using System.IO;
using System.Text.Json;
using ProtoBuf;
using AutoFixture;
using Moq;

var container = new Container
{
    Teu = 2,
    Tons = 40,
    Reefer = false
};

// Do they serialize?

var serializedContainer = JsonSerializer.Serialize(container);
Console.WriteLine(serializedContainer);

// Can a record be protobuf'ed?
// -> yes we can, with the latest protobuf-net version 3.0.62

var protobufContainer = new ProtobufContainer(2, 30, true);
Console.WriteLine($"Before protobuf serialization: {protobufContainer}");

using var ms = new MemoryStream();
Serializer.Serialize(ms, protobufContainer);

ms.Seek(0, SeekOrigin.Begin);

var deserializedProtobufContainer = Serializer.Deserialize<ProtobufContainer>(ms);
Console.WriteLine($"After protobuf deserialization: {deserializedProtobufContainer}");

// Can AutoFixture populate my records?

Fixture fixture = new();
var autoContainer = fixture.Create<Container>();
Console.WriteLine(autoContainer);

//var autoContainer1 = fixture.Build<Container>().With(c => c.Teu = 42).Create(); // breaks!

var customizedAutoContainer = autoContainer with { Teu = 42 };
Console.WriteLine(customizedAutoContainer);

// Can we moq 'em?

var containerMock = new Mock<Container>();
//containerMock.Setup(c => c.Tons).Returns(100); // breaks!

public record Container
{
    public int Tons { get; init; }
    public int Teu { get; init; }
    public bool Reefer { get; init; }
}

public record ProtobufContainer(
    [property: ProtoMember(1)] int Tons,
    [property: ProtoMember(2)] int Teu,
    [property: ProtoMember(3)] bool Reefer
);