// See https://aka.ms/new-console-template for more information


//Setting the workspace to get classes from

using Algorithms_And_Complexity___2122;

// Calling FileReturn and saving the output as 'output' (Dictionary)
var output = Input.FileReturn();

// Printing the output of the FileReturn()
foreach (var i in output)
{
    Console.WriteLine(i);
    
    // checking for the returned values  
    
    // foreach (var x in i.Value)
    // {
    //     Console.WriteLine(x);
    // }
}

//Count for the amount of data 
int count = 0;
//Outputting instructions to User Terminal
Console.WriteLine("Please Choose A file:");
//Creating new List that will hold all of the Key's we can use to access the dictionary
List<string> keyList = new List<string>();
//Loop through the Dictionary from FileReturn (output) 
foreach (var i in output)
{
    //Output the options to the user
    Console.WriteLine(count + " " + i.Key);
    //Adding the key to to the KeyList to allow us to access Dictionary
    keyList.Add(i.Key);
    //Adding to the count / the index of keyList
    count++;
}

// var - allows for string or null - saving input from terminal
var option = Console.ReadLine();
//While the user has not inputted something valid
while (true)
{
    // Try to catch int.Parse throwing an error when something other then a number is inputted. 
    try
    {
        // If option is not null and input is smaller then or equal to the amount of keys
        if (option != null && int.Parse(option) <= keyList.Count)
        {
            // Break while loop - user has inputted valid option
            break;
        }
        //Tell user to only enter an option
        else
        {
            Console.WriteLine("Please only enter an option above!");
        }
    }
    //Tell the user to only enter a number - error caught from the int.Parse
    catch (Exception)
    {
        Console.WriteLine("Please only enter a number");
    }
}
string fileName = keyList[int.Parse(option)];
string?[] data = output[keyList[int.Parse(option)]].ToArray();

Console.WriteLine($"File name: {fileName}");
foreach (var i in data)
{
    Console.WriteLine($"data: {i}");
}
