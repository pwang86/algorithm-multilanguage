public class Solution {

    // linear search
    public int LinearSearch(int[] arr, int item) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == item) return i;
        }
        return -1;
    }

    // binary search (sorted array)   
    public int BinarySearch(int[] arr, int item) {
        int l = 0, r = arr.Length - 1;
        while (l <= r) {
            int mid = Math.Floor((l + r) / 2);
            if (arr[mid] == item) return mid;
            else if (arr[mid] > item) r = mid - 1;
            else l = mid + 1;
        }
        return -1;
    }

    // bubble sort
    public int[] BubbleSort(int[] arr) {
        int[] copyArr = new int[arr.Length];
        copyArr.CopyTo(arr, 0);
        bool swapped = false;

        for (int i = 1; i < arr.Length - 1; i++) {
            for (int j = 0; j < arr.Length - i; j++) {
                if (copyArr[j] > copyArr[j + 1]) {
                    int tmp = copyArr[j];
                    copyArr[j] = copyArr[j + 1];
                    copyArr[j + 1] = tmp;
                    swapped = true;
                }
            }
            if (!swapped) return copyArr;
        }
        return copyArr;
    }

    // quick sort
    public int[] QuickSort(int[] arr) {
        if (arr.Length < 2) return arr;

        int pivotIndex = arr.Length >> 1; // Math.Floor(arr.Length / 2)
        int pivot = arr[pivotIndex];

        ArrayList lo = new ArrayList();
        ArrayList hi = new ArrayList();
        ArrayList res = new ArrayList();

        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] < pivot || (arr[i] == pivot && i != pivotIndex)) {
                lo.Add(arr[i]);
            } else if (arr[i] > pivot) {
                hi.Add(arr[i]);
            }
        }
        res.Add(QuickSort(lo.ToArray()));
        res.Add(pivot);
        res.Add(QuickSort(hi.ToArray()));

        return res.ToArray();
    }

    // merge sort
    public int[] MergeSort(int[] arr) {
        if (arr.Length < 2) return arr;

        int mid = arr.Length >> 1;
        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];
        int[] res = new int[arr.Length];

        for (int i = 0; i < mid; i++) {
            left[i] = arr[i];
        }
        for (int i = 0; i + mid < arr.Length; i++) {
            right[i] = arr[i + mid];
        }

        left = MergeSort(left);
        right = MergeSort(right);

        int indexRes = 0, indexLeft = 0, indexRight = 0;
        while (indexLeft < left.Length || indexRight < right.Length) {
            if (indexLeft < left.Length && indexRight < right.Length) {
                if (left[indexLeft] <= right[indexRight]) {
                    res[indexRes] = left[indexLeft];
                    indexLeft++;
                    indexRes++; 
                } else {
                    res[indexRes] = right[indexRight];
                    indexRight++;
                    indexRes++;
                }
            } else if (indexLeft < left.Length) {
                res[indexRes] = left[indexLeft];
                indexLeft++;
                indexRes++; 
            } else if (indexRight < right.Length) {
                res[indexRes] = right[indexRight];
                indexRight++;
                indexRes++; 
            }
        }

        return res;
    }

    // heap sort
    public int[] HeapSort(int[] arr) {
        if (arr.Length < 2) return arr;

        int[] copyArr = new int[arr.Length];
        copyArr.CopyTo(arr, 0);
        int len = copyArr.Length;

        for (int i = len >> 1 - 1; i >= 0; i--) {
            Heapify(copyArr, len, i);
        }
        for (int i = len - 1; i > 0; i--) {
            copyArr[0] = copyArr[0] ^ copyArr[i] ^ (copyArr[i] = copyArr[0]);  // swap
            Heapify(copyArr, i, 0);
        }

        return copyArr;
    }

    public void Heapify(int[] arr, int n, int i) {
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        int max = i;

        if (left < n && arr[left] > arr[max]) max = left;
        if (right < n && arr[right > arr[max]]) max = right;
        if (max != i) {
            arr[max] = arr[max] ^ arr[i] ^ (arr[i] = arr[max]);
            Heapify(arr, n, max);
        }
        
    }

    // selection sort
    public int[] SelectionSort(int[] arr) {
        if (arr.Length < 2) {
            return arr
        }

        int[] res = new int[arr.Length];
        res.CopyTo(arr, 0);

        for (int i = 0 ; i < res.Length - 1; i++) {
            int min = i;
            for (int j = 0; j < res.Length; j++) {
                if (res[j] < res[min]) {
                    min = j;
                }
            }
            if (min != i) {
                res[min] = res[min] ^ res[i] ^ (res[i] = res[min]);
            }
        } 
    }

    // insertion sort
    public int[] InsertionSort(int[] arr) {
        if (arr.Length < 2) return arr;
        int[] res = new int[arr.Length];

        for (int i = 1; i < res.Length; i++) {
            int currentIndex = i;
            while (currentIndex > 0 && res[currentIndex] < res[currentIndex - 1]) {
                res[currentIndex] = res[currentIndex] ^ res[currentIndex - 1] ^ (res[currentIndex - 1] = res[currentIndex]);
                currentIndex--;
            }
        }

        return res;
    }

    // optimised insertion sort
    public int[] InsertionSort2(int[] arr) {
        if (arr.Length < 2) return arr;
        int[] res = new int[arr.Length];

        for (int i = 1; i < res.Length; i++) {
            int currentIndex = i;
            int tmp = res[currentIndex];
            while (currentIndex > 0 && tmp < res[currentIndex - 1]) {
                res[currentIndex] = res[currentIndex - 1];
                currentIndex--;
            }
            res[currentIndex] = tmp;
        }

        return res;
    }
}
