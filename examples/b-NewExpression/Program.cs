/*
  _   _                 ______                              _
 | \ | |               |  ____|                            (_)
 |  \| | _____      __ | |__  __  ___ __  _ __ ___  ___ ___ _  ___  _ __
 | . ` |/ _ \ \ /\ / / |  __| \ \/ / '_ \| '__/ _ \/ __/ __| |/ _ \| '_ \
 | |\  |  __/\ V  V /  | |____ >  <| |_) | | |  __/\__ \__ \ | (_) | | | |
 |_| \_|\___| \_/\_/   |______/_/\_\ .__/|_|  \___||___/___/_|\___/|_| |_|
                                   | |
                                   |_|

- C# 9 introduces target typed new expressions. What does that mean?
- "Target typing" = an expression gets its type from the context of where it’s being used
- new expressions have always required a type to be specified
- In C# 9.0 you can leave out the type if there’s a clear type that the expression is being assigned to

Where this new syntax might come in handy is:
- when you have a lot of repetition, such as in an array or object initializer
- return statements

*/

using System;
// ReSharper disable ArrangeObjectCreationWhenTypeEvident

Container container = new(123);
Vessel vessel = new(container);

DateTime datetime = new(2020, 12, 4);
Console.WriteLine($"📆 {datetime}");

// init an array of containers "the old way"
var containers = new Container[] {
    new Container(123),
    new Container(456),
    new Container(789)
};

// init array of containers "the new way"
var containers2 = new Container[]
{
    new(123),
    new(456),
    new(789)
};

public class Container
{
    public Container(int tons)
    {
    }
}

public class Vessel
{
    public Vessel(Container c)
    {
    }

    public Container GetContainer()
    {
        return new(40);
    }
}