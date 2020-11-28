/*
  _______            _                    _   _____                                         
 |__   __|          | |                  | | |  __ \                                        
    | | ___  _ __   | |     _____   _____| | | |__) | __ ___   __ _ _ __ __ _ _ __ ___  ___ 
    | |/ _ \| '_ \  | |    / _ \ \ / / _ \ | |  ___/ '__/ _ \ / _` | '__/ _` | '_ ` _ \/ __|
    | | (_) | |_) | | |___|  __/\ V /  __/ | | |   | | | (_) | (_| | | | (_| | | | | | \__ \
    |_|\___/| .__/  |______\___| \_/ \___|_| |_|   |_|  \___/ \__, |_|  \__,_|_| |_| |_|___/
            | |                                                __/ |                        
            |_|                                               |___/                         
 */

/* WHAT

No need to write boilerplate code to start a program
Before C#9 it looked like:
    
using System;

namespace TopLevelPrograms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
    
*/

/* WHY

Top level programs allow us to easily start writing code.

*/

using System;
using System.Threading;
using System.Threading.Tasks;

Console.WriteLine("🏁 Let's go!");

var delayedTask = new Task(() =>
{ 
    Thread.Sleep(5000); 
    Console.WriteLine("😴 I am a bit delayed...");
});

delayedTask.Start();

await delayedTask;

Console.WriteLine("👋 Hello World!");




