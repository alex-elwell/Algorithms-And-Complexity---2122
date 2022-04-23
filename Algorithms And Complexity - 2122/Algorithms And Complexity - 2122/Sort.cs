namespace Algorithms_And_Complexity___2122;

//Class Sort to handle the sorting of any data
public class Sort
{
    //Constructor to set required data
    public Sort(int[] data)
    {
        Data = data;
    }
    private int[] Data { get; set; }
    public int StepCount { get; set; }

    public int[] QuickSort(int reverse)
    {
        //Quick Sort algorithm!
        
        
        //automatically return array of [null]
        return new int[1];
    }

    public int[] BubbleSort(int reverse)
    {
        int[] dataCopy = new int[Data.Length];
        Array.Copy(Data, dataCopy, Data.Length);
        //Step Counter
        int stepCount = 0;
        
        
        //Ascending Order 
        if (reverse == 1)
        {
            int temp;
            for (var y = 0; y <= dataCopy.Length - 2; y++)
            {
                stepCount++;
                for (var i = 0; i <= dataCopy.Length - 2; i++)
                {
                    if (dataCopy[i] > dataCopy[i + 1])
                    {
                        temp = dataCopy[i + 1];
                        dataCopy[i + 1] = dataCopy[i];
                        dataCopy[i] = temp;
                    }
                }
            }
            //Updating the global stepCount - this can then be saved in Main
            StepCount = stepCount;
            return dataCopy;
        }
        else // Descending Order
        {
            int temp;
            for (var y = 0; y <= dataCopy.Length - 2; y++)
            {
                stepCount++;
                for (var i = 0; i <= dataCopy.Length - 2; i++)
                {
                    if (dataCopy[i] < dataCopy[i + 1])
                    {
                        temp = dataCopy[i + 1];
                        dataCopy[i + 1] = dataCopy[i];
                        dataCopy[i] = temp;
                    }
                }
            }
            StepCount = stepCount;
            return dataCopy;
        }
    }
    
    public int[] SelectionSort(int reverse)
    {
        return new int[1];
    }
    
    public int[] MergeSort(int reverse)
    {
        return new int[1];
    }
}