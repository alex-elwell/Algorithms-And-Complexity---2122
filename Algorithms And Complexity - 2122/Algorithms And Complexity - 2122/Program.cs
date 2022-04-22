// See https://aka.ms/new-console-template for more information
//Setting the workspace to get classes from
using Algorithms_And_Complexity___2122;
//
// //Creating a new instance of input to get the file's needed. 
// var input = new Input();
//Calling FileReturn and saving the output as 'output' (List)
var output = Input.FileReturn();

// //Printing the output of the FileReturn()
foreach (var i in output)
{
    Console.WriteLine(i);
    // checking for the returned values  
    // foreach (var x in i.Value)
    // {
    //     Console.WriteLine(x);
    // }
}


int count = 0;
Console.WriteLine("Please Choose A file:");
List<string>? keyList = null;
foreach (var i in output)
{
    Console.WriteLine(count + " " + i.Key);
    //Conditional Access to prevent null not being loaded - error handling / preventing errors from occuring
    keyList?.Add(i.Key);
    count++;
}
string? option = Console.ReadLine();
//if option is equal to the length of list or smaller, continue
if (keyList != null && option != null && int.Parse(option) <= keyList.Count())
{
    string valueToUse = keyList[int.Parse(option)];
    
    
    //TODO - save the key and value that the user has chosen and move on to sorting.
}