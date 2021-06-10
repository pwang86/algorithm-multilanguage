from typing import List

class Solution:
    
    # linear search
    def linearSearch(self, arr: List[int], item: int) -> int:
        for i in range(len(arr)):
            if arr[i] == item:
                return i
        return -1

    # binary search (sorted array)
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

    # bubble sort
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

    # quick sort
    def quickSort(self, arr: List[int]) -> List[int]:
        if len(arr) < 2:
            return arr

        pivotIndex = len(arr) // 2
        pivot = arr[pivotIndex]

        # create a List
        lo = []
        hi = []
        res = []

        for i in range(len(arr)):
            if arr[i] < pivot or (arr[i] == pivot and i != pivotIndex):
                lo.append(arr[i])
            elif arr[i] > pivot:
                hi.append(arr[i])
        
        res.append(self.quickSort(lo))
        res.append(pivot)
        res.append(self.quickSort(hi))

        return res

    # merge sort
    def mergeSort(self, arr: List[int]) -> List[int]:
        if len(arr) < 2:
            return arr
        
        mid = len(arr) // 2

        left = []
        right = []
        res = []

        for i in range(mid):
            left.append(arr[i])

        for i in range(mid, len(arr)):
            right.append(arr[i])
        
        left = self.mergeSort(left)
        right = self.mergeSort(right)

        indexLeft = indexRight = indexRes = 0
        while indexLeft < len(left) or indexRight < len(right):
            if indexLeft < len(left) and indexRight < len(right):
                if left[indexLeft] <= right[indexRight]:
                    res[indexRes] = left[indexLeft]
                    indexRes += 1
                    indexLeft += 1
                else:
                    res[indexRes] = right[indexRes]
                    indexRes += 1
                    indexRight += 1
            elif indexLeft < len(left):
                res[indexRes] = left[indexLeft]
                indexRes += 1
                indexLeft += 1
            elif indexRight < len(right):
                res[indexRes] = right[indexRes]
                indexRes += 1
                indexRight += 1
        
        return res

    # heap sort
    def heapify(self, arr: List[int], i: int) -> None:
        left = 2 * i + 1
        right = 2 * i + 2
        max = i

        if left < len(arr) and arr[left] > arr[max]:
            max = left
        if right < len(arr) and arr[right] > arr[max]:
            max = right
        if max != i:
            arr[max], arr[i] = arr[i], arr[max]
            self.heapify(arr, max)
        

    def heapSort(self, arr: List[int]) -> List[int]:
        res = arr.copy()
        length = len(res)

        for i in range(length // 2 - 1, -1, -1):
            self.heapify(res, i)
        for i in range(len - 1, 0, -1):
            res[0], res[i] = res[i], res[0]
            self.heapify(res, 0)
        return res