class Solution:
    
    #linear search
    def linearSearch(self, arr: List[int], item: int) -> int:
        for i in range(len(arr)):
            if arr[i] == item:
                return i
        return -1

    #binary search (sorted array)
    def binarySearch(self, arr: List[int], item: int) -> int:
        l, r = 0, len(arr) - 1
        while l <= r:
            mid = (l + r) // 2
            if arr[mid] == item:
                return mid
            elif arr[mid] > item:
                r = mid - 1
            else:
                l = mid + 1
        return -1