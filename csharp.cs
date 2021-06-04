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
}
