namespace Algorithms_And_Complexity___2122;

public class Search
{
    public int StepCount { get; set; }
    
    public List<int> LinearSearch(int[] data, int query)
    {
        //List format - Index - data 
        List<int> dataReturn = new List<int>();

        //Linear Search
        
        //TODO - While data[i]<=query - do the thing - if not stop as it is an ordered list - do this after write up please
        
        for (int i = 0; i <= data.Length - 1; i++)
        {
            //if the current number is bigger then the number we want (ordered list) we can stop - limits the amount of time searching past query.  
            if (data[i] > query)
            {
                break;
            }
            StepCount++;
            if (data[i] == query)
            {
                dataReturn.Add(i);
                dataReturn.Add(data[i]);
            }
        }
        Console.WriteLine("---------------");
        string? option;
        if (dataReturn.Count < 1)
        {
            while (true)
            {
                Console.WriteLine("The data was not found - would you like to search for the nearest number? \nI use a binary search to achieve this. \n1: No\n2: Yes");
                option = Console.ReadLine();
                if (option == "1" || option == "2")
                {
                    break;
                }
            }
            if (option == "1")
            {
                //Returns an empty array
                return dataReturn;
            }
            else if (option == "2")
            {
                //Will check for next viable number
                //TODO - use binary search to find the nearest number in this case
                BinarySearch(data, query);
            }
        }
        foreach (var i in dataReturn)
        {
            Console.WriteLine($"We found: {dataReturn[1]} at: {dataReturn[0] + i}");
        }
        Console.WriteLine("---------------");
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
        return dataReturn;
    }

    public List<int> BinarySearch(int[] data, int query)
    {
        //Binary Search finds the first element in array - we also need to find the last element. 
        
        //List format - Index - data 
        List<int> dataReturn = new List<int>();
        int min = 0;
        int max = data.Length - 1;
        while (min <= max)
        {
            StepCount++;
            int middle = (min + max) / 2;
         
            if (query == data[middle])
            {
                // If there is a value - it adds if not - doesn't add
                dataReturn.Add(middle);
                dataReturn.Add(data[middle]);
                break;
            }else if (query < data[middle])
            {
                max = middle - 1;
            }
            else
            {
                min = middle + 1;
            }
        }
        
        // Result - saves the last index where the query existed
        int result = 0;
        //Search to find the last occurence in the array
        min = 0;
        max = data.Length-1;
        int near=0; //Hold the index of the enarest value
        while (min <= max)
        {
            StepCount++;
            int middle = (min + max) / 2;
            near = middle;
            if (data[middle] == query)
            {
                result = middle;
                min = middle + 1;
            }else if (data[middle] > query)
            {
                max = middle - 1;
            }else if (data[middle] < query)
            {
                min = middle + 1;
            }
        }
        // Add index to the dataReturn - if there is nothing to be found - 0 is added. 
        dataReturn.Add(result);
        try
        {
            var i = dataReturn[1];
            dataReturn.Add(data[result]);
        }
        catch (Exception )
        {
            
        }
        // if (result>1)
        // {
        //     dataReturn.Add(data[result]);
        // }
        
        Console.WriteLine("---------------");
        if (dataReturn.Count == 1 )
        {
            Console.WriteLine("Doesnt exist in the array. ");
            //Get the nearest value 
            Console.WriteLine($"Nearest Value: {data[near]} at: {near}");
        }else if (dataReturn.Count > 2)
        {
            for (var i = 0; i <= dataReturn.Count - 1; i++)
            {
                Console.WriteLine($"We found: {dataReturn[1]} at: {dataReturn[0] + i}");
            }
        }
        Console.WriteLine("---------------");
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
        //if its bigger then the index[^1] then give them the biggest item
        //Return nothing if nothing found. 
        
        //return the first and last index's
        return dataReturn;
    }
}