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

    
    public int QuickSortStep { get; set; } = 0;

    public int[] QuickSort(int[] data, int reverse, int low, int high )
    {
        // Algorithm
        if (low < high)
        {
            int partition = QuickSortPartition(data, low, high);
            QuickSort(data, reverse, low, partition - 1);
            QuickSort(data, reverse, partition + 1, high);
        }

        if (reverse == 2)
        {
            //TODO - make this reverse - if not remove option for this and do it one way only!
        }
        //return array 
        return data;
    }

    public int QuickSortPartition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; //Pivot - element to be placed right
        int i = low - 1;
        for (int j = low; j <= high-1; j++)
        {
            QuickSortStep++;
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;
        return (i+1);
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
                for (var i = 0; i <= dataCopy.Length - 2; i++)
                {
                    stepCount++;
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
    
    public int[] InsertionSort(int reverse)
    {
        
        int[] dataCopy = new int[Data.Length];
        Array.Copy(Data, dataCopy, Data.Length);
        if (reverse == 1)
        {
            //Step Counter
            int stepCount = 0;
        
            //initialising required integers for sort - all 0 except n
            int i, j, valueToCopy;

            for (i = 1; i < dataCopy.Length; i++)
            {
                valueToCopy = dataCopy[i];
                for (j = i - 1; j >= 0;)
                {
                    stepCount++;
                    if (valueToCopy < dataCopy[j])
                    {
                        dataCopy[j + 1] = dataCopy[j];
                        j--;
                        dataCopy[j + 1] = valueToCopy;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            StepCount = stepCount;
            return dataCopy;
        }
        else
        {
            //Step Counter
            int stepCount = 0;
        
            //initialising required integers for sort - all 0 except n
            int i, j, valueToCopy;

            for (i = 1; i < dataCopy.Length; i++)
            {
                valueToCopy = dataCopy[i];
                for (j = i - 1; j >= 0;)
                {
                    stepCount++;
                    if (valueToCopy > dataCopy[j])
                    {
                        dataCopy[j + 1] = dataCopy[j];
                        j--;
                        dataCopy[j + 1] = valueToCopy;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            StepCount = stepCount;       
            return dataCopy;
        }
    }
    public int[] MergeSortMain(int reverse)
    {
        //TODO - merge sort 
        
        
        
        //Merge Sort 
        return new int[1];
    }

    // private int merge(int[] data, int l, int m, int r)
    // {
    //     
    //     return 1;
    //
    // }
}