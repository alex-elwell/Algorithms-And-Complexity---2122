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

//Saving both the fileName and data to the corresponding variable 
var fileName = keyList[int.Parse(option)];
//array of integers - converting output array dictionary's request data (using key) into an array of integers
int[] data = Array.ConvertAll(output[keyList[int.Parse(option)]].ToArray(), s =>
{
    //If s (piece of data / number) is null - Alert error and exit with code 1 - if not null convert to int. 
    if (s != null) return int.Parse(s);
    Console.WriteLine("There was an error - please use a different data Source");
    Environment.Exit(1);
    return 0;
});

// foreach (var i in data)
// {
//     Console.WriteLine($"Data: {i}");
//     Console.WriteLine($"Data type: {i.GetType()}");
// }
// Console.WriteLine($"File name: {fileName}");

var sort = new Sort(data);


while (true)
{
    Console.WriteLine("Please Select a Sorting Algorithm: ");
    Console.WriteLine("1: Bubble Sort");
    Console.WriteLine("2: Quick Sort");
    Console.WriteLine("3: Selection Sort");
    Console.WriteLine("4: Merge Sort");
    string? sortDecision = Console.ReadLine();
    try
    {
        //this will throw an error if anything but a number is inputted
        if (sortDecision != null)
        {
            int.Parse(sortDecision);
        }
    }
    catch (Exception)
    {
        Console.WriteLine("You should only enter numbers into this field!");
        continue;
        // throw;
    }

    string? directionOption;
    while (true)
    {
        Console.WriteLine("1: Ascending \n2: Descending?");
        directionOption = Console.ReadLine();
        try
        {
            int.Parse(directionOption!);
        }
        catch (Exception )
        {
            Console.WriteLine("Please only enter numbers!");
            continue;
        }

        if (int.Parse(directionOption!) == 1 || int.Parse(directionOption!) == 2 )
        {
            break;
        }
        Console.WriteLine("PLease only enter 1 or 2 ");
    }
    
    if (int.Parse(sortDecision!) <= 4)
            {
                switch (sortDecision)
                {
                    case "1":
                        var bubbleSortReturn = sort.BubbleSort(int.Parse(directionOption!));
                        foreach (var i in bubbleSortReturn)
                        {
                            Console.WriteLine(i);
                        }
                        break;
                    case "2":
                        var quickSortReturn = sort.QuickSort(int.Parse(directionOption!));
                        Console.WriteLine(quickSortReturn);
                        break;
                    case "3":
                        var selectionSortReturn = sort.SelectionSort(int.Parse(directionOption!));
                        Console.WriteLine(selectionSortReturn);
                        break;
                    case "4":
                        var mergeSortReturn = sort.MergeSort(int.Parse(directionOption!));
                        Console.WriteLine(mergeSortReturn);
                        break;
                }
                break;
            }
        }

