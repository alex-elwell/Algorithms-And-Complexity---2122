using System.Text;

namespace Algorithms_And_Complexity___2122;

public class Input
{
    /// <summary>
    /// Returns a dictionary of arrays to be used. - TODO - add how it returns
    /// </summary>
    /// <param name="type"> the way the user wants to input data? - TODO - check this. </param>
    /// <returns>Dictionary containing the names and values of each metric.</returns>
    public Dictionary<string, string?[]> FileReturn()
    {
        //Write to the console where the files should be - if they're not present then quit after our return to main.
        Console.WriteLine("PLease ensure that the supplied text files are in the following directory: bin/Debug/net6.0/");
        //Setting the filepath where the program is being run - works on MacOS and Windows
        string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        //Get the directoryInfo from the filepath. 
        DirectoryInfo d = new DirectoryInfo(filepath);
        //Dictionary to store file data and names
        var dictionary = new Dictionary<string, string?[]>();
        
        //Loop through the DirectoryInfo and save the fileNames and data within - if there are no text files we would do nothing and return an empty dictionary. 
        foreach (var file in d.GetFiles("*.txt"))
        {
            //Create string that gets the Directory with the name of the file attached to the end to make it into a working directory. 
            string? fileDirectory = file.DirectoryName + "/" + file.Name;
            
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
                // Key = file name, Value = Data from the file. 
                dictionary.Add(file.Name, lines);
            }
        }
        
        //TODO - check if the data in the dictionary is what we want and if not quit and inform user where to put the data. 
        // Possibly try to access the 2nd or third item as there are 6 so if there isnt a 5th or 6th then we know we dont have a complete data set?
        // Could ask how many files the user has if its not right before quitung - would account for there being a different amount of data if
        // they use something other then provided...
        
        
        
        
        
        //Return's the dictionary.  
        return dictionary;
    }
}