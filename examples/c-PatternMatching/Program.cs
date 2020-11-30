/*
  ______       _                              _   _____      _   _                  __  __       _       _     _             
 |  ____|     | |                            | | |  __ \    | | | |                |  \/  |     | |     | |   (_)            
 | |__   _ __ | |__   __ _ _ __   ___ ___  __| | | |__) |_ _| |_| |_ ___ _ __ _ __ | \  / | __ _| |_ ___| |__  _ _ __   __ _ 
 |  __| | '_ \| '_ \ / _` | '_ \ / __/ _ \/ _` | |  ___/ _` | __| __/ _ \ '__| '_ \| |\/| |/ _` | __/ __| '_ \| | '_ \ / _` |
 | |____| | | | | | | (_| | | | | (_|  __/ (_| | | |  | (_| | |_| ||  __/ |  | | | | |  | | (_| | || (__| | | | | | | | (_| |
 |______|_| |_|_| |_|\__,_|_| |_|\___\___|\__,_| |_|   \__,_|\__|\__\___|_|  |_| |_|_|  |_|\__,_|\__\___|_| |_|_|_| |_|\__, |
                                                                                                                        __/ |
                                                                                                                       |___/ 
C# 9 includes new pattern matching improvements:

- Type patterns match a variable is a type
- Parenthesized patterns enforce or emphasize the precedence of pattern combinations
- "and" patterns require both patterns to match
- "or" patterns require either pattern to match
- "not" patterns require that a pattern doesn't match
- Relational patterns require the input be less than, greater than, less than or equal, or greater than or equal to a given constant.
- Property patterns

(We'll do a recap what Pattern matching is all about down below!)

*/

using System;

void WithoutPatternMatching(object shape)
{
    if (shape is Circle)
    {
        var circle = (Circle) shape;
        Console.WriteLine(circle.Radius);
    }
    else if (shape is Rectangle)
    {
        var rectangle = (Rectangle) shape;
        Console.WriteLine(rectangle.Height);
    }
}

void BasicPatterns(object shape)
{
    switch (shape)
    {
        case Rectangle r:
            Console.WriteLine(r.Height);
            break;
        
        case Circle c:
            Console.WriteLine(c.Radius);
            break;
    }
}

void WhenClausePatterns(object shape)
{
    switch (shape)
    {
        case Rectangle r when r.Height > 10:
            Console.WriteLine(r.Height);
            break;
        
        case Circle c when c.Radius < 100:
            Console.WriteLine(c.Radius);
            break;
    }
}

void SimpleTypePattern(object shape)
{
    var greetingsFromAShape = shape switch
    {
        Circle c => $"I am a circle {c.Radius}",
        Rectangle r => $"I am a rectangle with height {r.Height}",
        _ => "Nah, I'm not a shape"
    };
}

void AndOrPattern(char input)
{
    var isLetter = input is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');
}

void NotPatterns(object shape)
{
    if (shape is not Rectangle)
    {
        Console.WriteLine("I am not a Rectangle");
    }
    
    // that is way more readable than:
    if (!(shape is Rectangle))
    {
        Console.WriteLine("I am still not a Rectangle");
    }

    var shortSyntaxExample = shape is not null ? 100 : 0;
}

void RelationalPatterns(Circle circle)
{
    var circleTShirtSize = circle.Radius switch
    {
        < 10 => "S",
        >= 10 and < 20 => "M",
        >= 20 and < 40 => "L",
        >= 40 => "XL",
        null => "-"
    };
}

void PropertyPatterns(string hello, string[] greetings)
{
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
}

class Rectangle
{
    public int Height { get; set; }
}

class Circle
{
    public int? Radius { get; set; }
}