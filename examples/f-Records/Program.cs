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
