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
}
