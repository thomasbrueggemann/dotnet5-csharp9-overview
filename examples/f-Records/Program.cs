/*
  _____                        _
 |  __ \                      | |
 | |__) |___  ___ ___  _ __ __| |___
 |  _  // _ \/ __/ _ \| '__/ _` / __|
 | | \ \  __/ (_| (_) | | | (_| \__ \
 |_|  \_\___|\___\___/|_|  \__,_|___/

"Besides all, do we know if records are supported by AutoFixture,
Serializers or any other nuget libraries we use. yet?
Does that require to update those packages?"

- Core of OOP is: object has identity and encapsulates mutable state
- Sometimes (more often than not) you want the exact opposite: immutability, object should behave like a value
- Records are immutable reference types (they can be mutable, but that's not what they were primarily built for)
- Records are still classes, but they add value-like behaviour at- and before compile-time

*/

using System;
using System.Collections.Generic;

var containerA = new Container
{
    Tons = 100,
    Teu = 200,
    Reefer = false
};

var containerB = containerA with { Tons = 0 };

// Records Equality Check

Console.WriteLine(containerA == containerB); // = False

var containerC = containerB with { Tons = 100 };

Console.WriteLine(containerA == containerC); // = True

// Inheritance

var terminal = new Terminal(
    "Gdansk Deepwater Container Terminal",
    "PLGDNDCT",
    54.3m,
    18.7m);

Console.WriteLine(terminal);

// Immutable Classes

public class OldContainer
{
    public int Tons { get; }
    public int Teu { get; }
    public bool Reefer { get; }

    public OldContainer(int tons, int teu, bool reefer)
    {
        Tons = tons;
        Teu = teu;
        Reefer = reefer;
    }

    public OldContainer With(
        int? tons = null,
        int? teu = null,
        bool? reefer = null)
    {
        return new OldContainer(
            tons ?? this.Tons,
            teu ?? this.Teu,
            reefer ?? this.Reefer);
    }

    // ... But what about equality checks?
}

// Basic Records

public record Container
{
    public int Tons { get; init; }
    public int Teu { get; init; }
    public bool Reefer { get; init; }
}

public record Vessel
{
    public IReadOnlyCollection<Container> Containers { get; init; }
}

// Positional Records and Inheritance

public record Geolocation(decimal Latitude, decimal Longitude);

public record Terminal(string Name, string Code, decimal Latitude, decimal Longitude) : Geolocation(Latitude, Longitude);