/*
   _____ _        _   _                                                                     ______                _   _                 
  / ____| |      | | (_)          /\                                                       |  ____|              | | (_)                
 | (___ | |_ __ _| |_ _  ___     /  \   _ __   ___  _ __  _   _ _ __ ___   ___  _   _ ___  | |__ _   _ _ __   ___| |_ _  ___  _ __  ___ 
  \___ \| __/ _` | __| |/ __|   / /\ \ | '_ \ / _ \| '_ \| | | | '_ ` _ \ / _ \| | | / __| |  __| | | | '_ \ / __| __| |/ _ \| '_ \/ __|
  ____) | || (_| | |_| | (__   / ____ \| | | | (_) | | | | |_| | | | | | | (_) | |_| \__ \ | |  | |_| | | | | (__| |_| | (_) | | | \__ \
 |_____/ \__\__,_|\__|_|\___| /_/    \_\_| |_|\___/|_| |_|\__, |_| |_| |_|\___/ \__,_|___/ |_|   \__,_|_| |_|\___|\__|_|\___/|_| |_|___/
                                                           __/ |                                                                        
                                                          |___/                                                                         

- Anonymous and lambda functions can now be static
- Benefits: Avoid unintentionally capturing state from the enclosing context, which can result
            in unexpected retention of captured objects or unexpected additional allocations
            
https://anthonygiretti.com/2020/10/21/introducing-c-9-static-anonymous-functions/
*/

using System;

int TestMethod(Func<int, int> func)
{ 
    return func(1);
}

int y = 10;

// this captures 'y', causing unintended allocation.
TestMethod(x => x + y); 

// adding the static keyword indicates the anonymous function prevents this memory allocation.
//TestMethod(static x => x + y);

// in order to fix the error, the variable y needs to be changed into a constant or static field.
const int y2 = 10;
TestMethod(static x => x + y2); // okay :-)

