// See https://aka.ms/new-console-template for more information
//Setting the workspace to get classes from
using Algorithms_And_Complexity___2122;
//
// //Creating a new instance of input to get the file's needed. 
// var input = new Input();
//Calling FileReturn and saving the output as 'output' (List)
var output = Input.FileReturn();

// //Printing the output of the FileReturn()
// foreach (var i in output)
// {
//     Console.WriteLine(i);
//     // checking for the returned values  
//     // foreach (var x in i.Value)
//     // {
//     //     Console.WriteLine(x);
//     // }
// }


//TODO - get the user's input on file.

int count = 0;
Console.WriteLine("Please Choose A file:");
foreach (var i in output)
{
    Console.WriteLine(count + " " + i.Key);
    count++;
}
string? option = Console.ReadLine();

//TODO - make this use a list and then index the list to get to the key value to access the dictionary. 
