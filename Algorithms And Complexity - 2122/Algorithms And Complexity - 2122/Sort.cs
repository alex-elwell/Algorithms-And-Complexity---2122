namespace Algorithms_And_Complexity___2122;

//Class Sort to handle the sorting of any data
public class Sort
{
    //Constructor to set required data
    public Sort(int[] data)
    {
        Data = data;
    }

    //Public variables that we are using for both the data we initialise with the instantiation of sort class + step counters used in recursive algorithms
    private int[] Data { get; set; }
    public int StepCount { get; set; }
    public int QuickSortStep { get; set; } = 0;
    public int MergeSortStep { get; set; } = 0; 
    public int[] QuickSort(int[] data, int reverse, int low, int high)
    {
        // Algorithm
        if (reverse == 1)
        {
            if (low < high)
            {
                int partition = QuickSortPartition(data, low, high);
                QuickSort(data, reverse, low, partition - 1);
                QuickSort(data, reverse, partition + 1, high);
            }
        }
        if (reverse == 2)
        {
            if (low < high)
            {
                int partition = QuickSortPartitionReverse(data, low, high);
                QuickSort(data, reverse, low, partition - 1);
                QuickSort(data, reverse, partition + 1, high);
            }

        }
        // StepCount = QuickSortStep;
        //return array 
        return data;
    }

    
    public int QuickSortPartition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; //Pivot - element to be placed right
        int i = low - 1;
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                QuickSortStep++;
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        QuickSortStep++;
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;
        return (i + 1);
    }


    public int QuickSortPartitionReverse(int[] arr, int low, int high)
    {
        int pivot = arr[high]; //Pivot - element to be placed right
        int i = low - 1;
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] > pivot)
            {
                QuickSortStep++;
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        QuickSortStep++;
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;
        return (i + 1);
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
                for (var i = 0; i <= dataCopy.Length - 2; i++)
                {
                    if (dataCopy[i] > dataCopy[i + 1])
                    {
                        temp = dataCopy[i + 1];
                        dataCopy[i + 1] = dataCopy[i];
                        dataCopy[i] = temp;
                        stepCount = stepCount+3;
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
                    if (dataCopy[i] < dataCopy[i + 1])
                    {
                        temp = dataCopy[i + 1];
                        dataCopy[i + 1] = dataCopy[i];
                        dataCopy[i] = temp;
                        stepCount +=3;
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
                    if (valueToCopy < dataCopy[j])
                    {
                        stepCount += 3;
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
                    if (valueToCopy > dataCopy[j])
                    {
                        stepCount += 3;
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

    public int[] MergeSortMain(int reverse, int[] data)
    {
        if (reverse == 1)
        {
            int[] left;
            int[] right;
            //Creating new array of the data to be changed locally. 
            // int[] data = new int[data.Length];
            // Array.Copy(data, data, data.Length);
            int[] result = new int[data.Length];

            //If the result is smaller then 1 - then stop the recursion. 
            if (data.Length <= 1)
            {
                return data;
            }
            //Set the mid point to be used for splitting array
            int mid = data.Length / 2;
        
            //Create left and right array's to be sorted separately
            left = new int[mid];
        
            //Now account for the their being an even or odd amount of numbers in the list
            if (data.Length % 2 == 0)
            {
                //even amount of numbers on either side
                right = new int[mid];
            }
            else
            {
                //odd amount of numbers so we add one
                right = new int[mid + 1];
            }
        
            //now we have empty array's that are the right length - populate them now.
            for (int i = 0; i < mid; i++)
            {
                MergeSortStep++;
                //Populate left array
                left[i] = data[i];
            }

            int x = 0;
            for (int i = mid; i < data.Length; i++)
            {
                MergeSortStep++;
                //add to the right - we need a new pointer to start populating from the left 
                right[x] = data[i];
                x++;
            }
        
            //As this is a recursive algorithm we need to actually call the merge 

            left = MergeSortMain(reverse, left);

            right = MergeSortMain(reverse, right);

            result = Merge(left, right);
        
            return result;
        }
        else
        {
            int[] left;
            int[] right;
            //Creating new array of the data to be changed locally. 
            // int[] data = new int[data.Length];
            // Array.Copy(data, data, data.Length);
            int[] result = new int[data.Length];

            //If the result is smaller then 1 - then stop the recursion. 
            if (data.Length <= 1)
            {
                return data;
            }
            //Set the mid point to be used for splitting array
            int mid = data.Length / 2;
        
            //Create left and right array's to be sorted separately
            left = new int[mid];
        
            //Now account for the their being an even or odd amount of numbers in the list
            if (data.Length % 2 == 0)
            {
                //even amount of numbers on either side
                right = new int[mid];
            }
            else
            {
                //odd amount of numbers so we add one
                right = new int[mid + 1];
            }
        
            //now we have empty array's that are the right length - populate them now.
            for (int i = 0; i < mid; i++)
            {
                MergeSortStep++;
                //Populate left array
                left[i] = data[i];
            }

            int x = 0;
            for (int i = mid; i < data.Length; i++)
            {
                MergeSortStep++;
                //add to the right - we need a new pointer to start populating from the left 
                right[x] = data[i];
                x++;
            }
        
            //As this is a recursive algorithm we need to actually call the merge 

            left = MergeSortMain(reverse, left);

            right = MergeSortMain(reverse, right);

            result = MergeReverse(left, right);
        
            return result;
        }
    }

    public int[] Merge(int[] left, int[] right)
    {
        int resultLen = right.Length + left.Length;
        int[] result = new int[resultLen];
        int indexLeft = 0;
        int indexRight = 0;
        int resultIndex = 0;

        // While array Left or Right still has the 
        while (indexLeft < left.Length || indexRight < right.Length)
        {
            //if both of the arrays have numbers/elements in them
            if (indexLeft < left.Length && indexRight < right.Length)
            {
                //if element in left array is smaller then items in the right - add that to the result array
                if (left[indexLeft] <= right[indexRight])
                {
                    MergeSortStep ++;
                    result[resultIndex] = left[indexLeft];
                    indexLeft++;
                    resultIndex++;
                }
                //if not then add right item to the result 
                else
                {
                    MergeSortStep++;
                    result[resultIndex] = right[indexRight];
                    indexRight++;
                    resultIndex++;
                }
            }
            //if the left array has elements still then add to the result 
            else if (indexLeft < left.Length)
            {
                MergeSortStep++;
                result[resultIndex] = left[indexLeft];
                indexLeft++;
                resultIndex++;
            }
            //if the right array still has elements - add to the result
            else if (indexRight < right.Length)
            {
                MergeSortStep++;
                result[resultIndex] = right[indexRight];
                indexRight++;
                resultIndex++;
            }
        }
        return result;
    }
    public int[] MergeReverse(int[] left, int[] right)
    {
        int resultLen = right.Length + left.Length;
        int[] result = new int[resultLen];
        int indexLeft = 0;
        int indexRight = 0;
        int resultIndex = 0;

        // While array Left or Right still has the 
        while (indexLeft < left.Length || indexRight < right.Length)
        {
            //if both of the arrays have numbers/elements in them
            if (indexLeft < left.Length && indexRight < right.Length)
            {
                //if element in left array is smaller then items in the right - add that to the result array
                if (left[indexLeft] >= right[indexRight])
                {
                    MergeSortStep++;
                    result[resultIndex] = left[indexLeft];
                    indexLeft++;
                    resultIndex++;
                }
                //if not then add right item to the result 
                else
                {
                    MergeSortStep++;
                    result[resultIndex] = right[indexRight];
                    indexRight++;
                    resultIndex++;
                }
            }
            //if the left array has elements still then add to the result 
            else if (indexLeft < left.Length)
            {
                MergeSortStep++;
                result[resultIndex] = left[indexLeft];
                indexLeft++;
                resultIndex++;
            }
            //if the right array still has elements - add to the result
            else if (indexRight < right.Length)
            {
                MergeSortStep++;
                result[resultIndex] = right[indexRight];
                indexRight++;
                resultIndex++;
            }
        }
        return result;
    }
}