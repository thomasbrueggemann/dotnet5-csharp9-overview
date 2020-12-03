/*
   _____                     _             _     _____      _
  / ____|                   (_)           | |   |  __ \    | |
 | |     _____   ____ _ _ __ _  __ _ _ __ | |_  | |__) |___| |_ _   _ _ __ _ __  ___
 | |    / _ \ \ / / _` | '__| |/ _` | '_ \| __| |  _  // _ \ __| | | | '__| '_ \/ __|
 | |___| (_) \ V / (_| | |  | | (_| | | | | |_  | | \ \  __/ |_| |_| | |  | | | \__ \
  \_____\___/ \_/ \__,_|_|  |_|\__,_|_| |_|\__| |_|  \_\___|\__|\__,_|_|  |_| |_|___/


It’s sometimes useful to express that a method override in a derived class
has a more specific return type than the declaration in the base type.

*/

using System;
using System.Collections.Generic;

Console.WriteLine("I am here to make this a top level program, try comment me out 🥴");

public abstract class Cargo
{
    public decimal WeightInTons { get; set; }
}

public class Container : Cargo
{
    public int Teu { get; set; }
}

public class BreakBulk : Cargo
{
    public decimal Length { get; set; }
    public decimal Width { get; set; }
}

public abstract class CargoCalculator
{
    public abstract IReadOnlyCollection<Cargo> GetCargo();
}

public class ContainerCalculator : CargoCalculator
{
    public override IReadOnlyCollection<Container> GetCargo() // <- covariant return
    {
        return new List<Container>();
    }
}

public class BreakBulkCalculator : CargoCalculator
{
    public override IReadOnlyCollection<BreakBulk> GetCargo() // <- covariant return
    {
        return new List<BreakBulk>();
    }
}