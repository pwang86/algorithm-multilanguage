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
}
