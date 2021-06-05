from typing import List

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

    #bubble sort
    def bubbleSort(self, arr: List[int]) -> List[int]:
        swapped = False
        copyArr = arr.copy()
        for i in range(1, len(arr) - 1):
            for j in range(len(arr) - i):
                if copyArr[j] > copyArr[j + 1]:
                    tmp = copyArr[j + 1]
                    copyArr[j + 1] = copyArr[j]
                    copyArr[j] = tmp
                    swapped = True
            if swapped != True:
                return copyArr
        return copyArr