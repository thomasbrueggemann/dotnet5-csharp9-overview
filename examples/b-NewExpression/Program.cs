/*
  _   _                 ______                              _             
 | \ | |               |  ____|                            (_)            
 |  \| | _____      __ | |__  __  ___ __  _ __ ___  ___ ___ _  ___  _ __  
 | . ` |/ _ \ \ /\ / / |  __| \ \/ / '_ \| '__/ _ \/ __/ __| |/ _ \| '_ \ 
 | |\  |  __/\ V  V /  | |____ >  <| |_) | | |  __/\__ \__ \ | (_) | | | |
 |_| \_|\___| \_/\_/   |______/_/\_\ .__/|_|  \___||___/___/_|\___/|_| |_|
                                   | |                                    
                                   |_|                                                      
 */

/* WHAT


    
*/

/* WHY



*/

using System;

Container container = new();
Vessel vessel = new(container);

DateTime datetime = new(2020, 12, 4);

public class Container
{
    public int Tons { get; set; }
}

public class Vessel
{ 
    public Vessel(Container c)
    {
    }
}