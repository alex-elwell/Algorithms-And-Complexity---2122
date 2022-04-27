// See https://aka.ms/new-console-template for more information


//Setting the workspace to get classes from

using Algorithms_And_Complexity___2122;

// Calling FileReturn and saving the output as 'output' (Dictionary)
var output = Input.FileReturn();

List<int> masterStepCount = new List<int>();


while (true)
{
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

    string? option;
    //While the user has not inputted something valid
    while (true)
    {
        // var - allows for string or null - saving input from terminal
        option = Console.ReadLine();
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

    var sort = new Sort(data);

    string? sortDecision;
    while (true)
    {
        Console.WriteLine("Please Select a Sorting Algorithm: ");
        Console.WriteLine("1: Bubble Sort");
        Console.WriteLine("2: Quick Sort");
        Console.WriteLine("3: Insertion Sort");
        Console.WriteLine("4: Merge Sort- NOP");
        Console.WriteLine("5: Quit");
        sortDecision = Console.ReadLine();
        try
        {
            //this will throw an error if anything but a number is inputted
            if (sortDecision != null)
            {
                int.Parse(sortDecision);
                break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("You should only enter numbers into this field!");
            continue;
            // throw;
        }
    }

    if (sortDecision == "5")
    {
        break;
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
        catch (Exception)
        {
            Console.WriteLine("Please only enter numbers!");
            continue;
        }

        if (int.Parse(directionOption!) == 1 || int.Parse(directionOption!) == 2)
        {
            break;
        }

        Console.WriteLine("Please only enter 1 or 2 ");
    }

    int[] dataReturn = new int[] { };

    if (int.Parse(sortDecision!) <= 4)
    {
        switch (sortDecision)
            {
                case "1":
                    dataReturn = sort.BubbleSort(int.Parse(directionOption!));
                    
                    //adding to the masterStepCount that will hold both the type of search and the amount of steps
                    masterStepCount.Add(1);
                    masterStepCount.Add(sort.StepCount);
                    break;
                case "2":
                    int[] dataCopy = new int[data.Length];
                    Array.Copy(data, dataCopy, data.Length);
                    dataReturn = sort.QuickSort(dataCopy, int.Parse(directionOption!), 0, data.Length - 1);
                    //adding to the masterStepCount that will hold both the type of search and the amount of steps
                    masterStepCount.Add(2);
                    masterStepCount.Add(sort.StepCount);
                    foreach (var i in dataReturn)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case "3":
                    dataReturn = sort.InsertionSort(int.Parse(directionOption!));
                    //adding to the masterStepCount that will hold both the type of search and the amount of steps
                    masterStepCount.Add(3);
                    masterStepCount.Add(sort.StepCount);
                    break;
                case "4":
                    dataReturn = sort.MergeSortMain(int.Parse(directionOption!));
                    //adding to the masterStepCount that will hold both the type of search and the amount of steps
                    masterStepCount.Add(4);
                    masterStepCount.Add(sort.StepCount);
                    break;
            }
    }
    
    if (fileName.Contains("2048"))
    {
        //Print the 50th value for each thing 
        Console.WriteLine($"The size of the array is: {dataReturn.Length}");
        for (int i = 0; i < dataReturn.Length; i = i + 50)
        {
            Console.WriteLine($"Index: {i} Data: {dataReturn[i]}");
        }
    }
    else if (fileName.Contains("256"))
    {
        Console.WriteLine($"The size of the array is: {dataReturn.Length}");
        for (int i = 0; i < dataReturn.Length; i = i + 10)
        { 
            Console.WriteLine($"$index: {i} Data: {dataReturn[i]}");
        }
    }

    string? searchOption;
    while (true)
    {
        Console.WriteLine("\n1: Linear Search\n2: Binary Search");
        searchOption = Console.ReadLine();
        if (searchOption == "1" || searchOption == "2")
        {
            break;
        }
        else
        {
            Console.WriteLine("Please only enter '1' or '2'");
        }
    }
    
    //Searching Algorithms
    var search = new Search();
    string? query;
    // search - dataReturn(holding the data to be searched)
    while (true)
    {
        Console.WriteLine("What would you like to Search for?");
        query = Console.ReadLine();
        try
        {
            int queryInt = int.Parse(query.Trim());
            //if the parse worked - we just have a number so
            //we can continue to send this to the search
            break;
        }
        catch (Exception )
        {
            Console.WriteLine("Please Only enter a number");
        }
    }


    if (searchOption == "1")
    {
        //THIS COULD RETURN NULL / EMPTY LIST - ALLOW FOR THIS!
            
        var linearReturn = search.LinearSearch(dataReturn, int.Parse(query));
        foreach (var i in linearReturn)
        {
            Console.WriteLine(i);
        }
        int steps = sort.StepCount;
        masterStepCount.Add(5);
        masterStepCount.Add(steps);
    }else if (searchOption == "2")
    {
        search.BinarySearch(dataReturn, int.Parse(query));
        int steps = sort.StepCount;
        masterStepCount.Add(6);
        masterStepCount.Add(steps);
    }
    
    Console.WriteLine("The Amount of Steps are below:");
    
    for (int i = 0; i < masterStepCount.Count; i=i+2)
    {
        switch (masterStepCount[i])
        {
            case 1:
                Console.WriteLine($"Bubble Sort: {masterStepCount[i+1]}");
                break;
            case 2:
                Console.WriteLine($"Quick Sort: {masterStepCount[i+1]}");
                break;
            case 3:
                Console.WriteLine($"Insertion Sort: {masterStepCount[i+1]}");
                break;
            case 4:
                Console.WriteLine($"Merge Sort: {masterStepCount[i+1]}");
                break;
            case 5:
                Console.WriteLine($"Linear Search: {masterStepCount[i+1]}");
                break;
            case 6:
                Console.WriteLine($"Binary Search: {masterStepCount[i+1]}");
                break;
        }
    }
}