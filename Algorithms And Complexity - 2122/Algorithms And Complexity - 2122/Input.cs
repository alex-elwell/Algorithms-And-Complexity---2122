using System.Text;

namespace Algorithms_And_Complexity___2122;

public class Input
{
    /// <summary>
    /// Returns a dictionary of arrays to be used. 
    /// </summary>
    /// <returns>Dictionary as such: Key: File Name, Value: List of Strings holding the respective files data</returns>
    public static Dictionary<string, string?[]> FileReturn()
    {
        //Setting the filepath where the program is being run - works on MacOS and Windows
        string filepath = AppDomain.CurrentDomain.BaseDirectory;
        //Get the directoryInfo from the filepath. 
        DirectoryInfo d = new DirectoryInfo(filepath);
        //Dictionary to store file data and names
        var dictionary = new Dictionary<string, string?[]>();
        
        //Loop through the DirectoryInfo and save the fileNames and data within - if there are no text files we would do nothing and return an empty dictionary. 
        foreach (var file in d.GetFiles("*.txt"))
        {
            //Create string that gets the Directory with the name of the file attached to the end to make it into a working directory. 
            string fileDirectory = file.DirectoryName + "/" + file.Name;
            
            //if the file has a directory name then continue - this accounts for a null value returned from the program. 
            if (file.DirectoryName != null)
            {
                // New List that holds strings we will be getting from the files
                var list = new List<string?>();
                // File Stream that will open and access the file as needed. 
                var fileStream = new FileStream(fileDirectory, FileMode.Open, FileAccess.Read);
 
                // Adding lines to the list using the stream reader that we created above. We're setting the encoding to the default for the file. 
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    // String to hold the data we need to put in to the list. 
                    string? line;
                    
                    // If the streamReader gives a present value then add to the list.  
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // Adding to the list to be added to the dictionary at the end. 
                        list.Add(line);
                    }
                }
                // Create a string that holds the lines of the code.
                var lines = list.ToArray();
                
                // Add this new list along with the file name to the dictionary 
                dictionary.Add(file.Name, lines);
            }
        }
        
        //Count to hold the amount of values in the dictionary. 
        int count = 0;
        // For each item in the dictionary we add to the count to find out how many items are in the dictionary
        foreach (var unused in dictionary)
        {
            //adding one to count
            count++;
        }
        //if the count is the expected amount do nothing but if its not then ask for the required amount
        if (count != 6)
        {
            //Ask for the amount of expected data 
            Console.WriteLine("How many data files are you expecting to be inputted?");
            string? required = Console.ReadLine();
            //if required is not null and count is equal to the required data then continue. 
            if (required != null && count != int.Parse(required))
            {
                Console.WriteLine("The count is not equal to the expected value");
                Console.WriteLine("Please check the files in the net 6.0 folder and restart the program.");
                Environment.Exit(001);
            }
        }
        //add combined array's to the dictionary to be analysed

        Dictionary<string, string?[]> tempDictionary = new Dictionary<string, string?[]>();

        List<string?> temp256 = new List<string?>();
        List<string?> temp2048 = new List<string?>();



        //Index of - items we want - index again of the other item - index of - last item we want
        
        foreach (var i in dictionary)
        {
            if (i.Key.Contains("256"))
            {
                foreach (var y in i.Value)
                {
                    // Console.WriteLine(y);
                    temp256.Add(y);
                }
            }
            else if (i.Key.Contains("2048"))
            {
                foreach (var y in i.Value)
                {
                    temp2048.Add(y);
                }
            }
        }
        tempDictionary.Add("256 Merge", temp256.ToArray());
        tempDictionary.Add("2048 Merge", temp2048.ToArray());
        //Add temp dictionary to new dictionary. 
        tempDictionary.ToList().ForEach(x => dictionary.Add(x.Key, x.Value));

        
        //Return's the dictionary.  
        return dictionary;
    }
}