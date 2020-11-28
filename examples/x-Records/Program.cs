/*
  _____                        _     
 |  __ \                      | |    
 | |__) |___  ___ ___  _ __ __| |___ 
 |  _  // _ \/ __/ _ \| '__/ _` / __|
 | | \ \  __/ (_| (_) | | | (_| \__ \
 |_|  \_\___|\___\___/|_|  \__,_|___/

*/

/* WHAT
 * Top level programs allow us to easily start writing code
 */

/* WHY

*/

using System;

var container1 = new Container();

var container2 = container1 with { Tons = 34 };

public record Container
{
  public int Tons { get; init; }
  public int Teu { get; init; }
  public bool Reefer { get; init; }
}
