/*
  _____                           _         _____      _   _
 |  __ \                         | |       |  __ \    | | | |
 | |__) | __ ___  _ __   ___ _ __| |_ _   _| |__) |_ _| |_| |_ ___ _ __ _ __
 |  ___/ '__/ _ \| '_ \ / _ \ '__| __| | | |  ___/ _` | __| __/ _ \ '__| '_ \
 | |   | | | (_) | |_) |  __/ |  | |_| |_| | |  | (_| | |_| ||  __/ |  | | | |
 |_|   |_|  \___/| .__/ \___|_|   \__|\__, |_|   \__,_|\__|\__\___|_|  |_| |_|
                 | |                   __/ |
                 |_|                  |___/
 */

/* WHAT



*/

/* WHY



*/

using System;

string? hello = "Hello World";

// old approach
if (!string.IsNullOrEmpty(hello))
{
    Console.WriteLine($"{hello} has {hello.Length} letters.");
}

// new approach, with a property pattern
if (hello is { Length: > 0 })
{
    Console.WriteLine($"{hello} has {hello.Length} letters.");
}




// for arrays:
string[]? greetings = new string[2];
greetings[0] = "Hello world";

// old approach
if (greetings != null && !string.IsNullOrEmpty(greetings[0]))
{
    Console.WriteLine($"{greetings[0]} has {greetings[0].Length} letters.");
}

// new approach
if (greetings?[0] is {Length: > 0} hi)
{
    Console.WriteLine($"{hi} has {hi.Length} letters.");
}