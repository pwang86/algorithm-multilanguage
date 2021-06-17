from typing import List
import random

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
    def heapify(self, arr: List[int], n: int, i: int) -> None:
        left = 2 * i + 1
        right = 2 * i + 2
        max = i

        if left < n and arr[left] > arr[max]:
            max = left
        if right < n and arr[right] > arr[max]:
            max = right
        if max != i:
            arr[max], arr[i] = arr[i], arr[max]
            self.heapify(arr, n, max)
        

    def heapSort(self, arr: List[int]) -> List[int]:
        res = arr.copy()
        length = len(res)

        for i in range(length // 2 - 1, -1, -1):
            self.heapify(res, length, i)
        for i in range(len - 1, 0, -1):
            res[0], res[i] = res[i], res[0]
            self.heapify(res, i, 0)
        return res
    
    # selection sort
    def selectionSort(self, arr: List[int]) -> List[int]:
        if len(arr) < 2:
            return arr
        
        res = arr.copy()
        for i in range(len(arr) - 1):
            minInex = i
            for j in range(i + 1, len(arr)):
                if res[j] < res[minInex]:
                    minInex = j
            if minInex != i:
                res[minInex], res[i] = res[i], res[minInex]
        return res

    # insertion sort
    def insertionSort(self, arr: List[int]) -> List[int]:
        if len(arr) < 2:
            return arr
        res = arr.copy()

        for i in range(1, len(res)):
            currentIndex = i
            while currentIndex > 0 and res[currentIndex] < res[currentIndex - 1]:
                res[currentIndex], res[currentIndex - 1] = res[currentIndex - 1], res[currentIndex]
                currentIndex -= 1
        return res

    # optimised insertion sort
    def insertionSort2(self, arr: List[int]) -> List[int]:
        if len(arr) < 2:
            return arr
        res = arr.copy()

        for i in range(1, len(res)):
            currentIndex = i
            tmp = res[currentIndex]
            while currentIndex > 0 and tmp < res[currentIndex - 1]:
                res[currentIndex] = res[currentIndex - 1]
                currentIndex -= 1
            res[currentIndex] = tmp

        return res 

    # shuffle
    def shuffle(self, arr: List[int]) -> List[int]:
        res = arr.copy()

        for i in range (len(res) - 1, 0, -1):
            j = random.randint(0, i)
            if i != j:
                res[i], res[j] = res[j], res[i]
        
        return res

    # spiral matrix II 
    def generateMatrix(self, n: int) -> List[List[int]]:
        res = [[0] * n for i in range(n)]
        loop = n // 2
        startX = startY = 0
        count = 1
        offset = 1
        mid = n // 2
        while loop > 0:
            i = startX
            j = startY
            while j < startY + n - offset:
                res[i][j] = count
                count += 1
                j += 1
            while i < startX + n - offset:
                res[i][j] = count
                count += 1
                i += 1
            while j > startY:
                res[i][j] = count
                count += 1
                j -= 1
            while i > startX:
                res[i][j] = count
                count += 1
                i -= 1
            loop -= 1
            offset += 2
            startX += 1
            startY += 1
        
        if n % 2 == 1:
            res[mid][mid] = count
        
        return res