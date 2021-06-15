// some algorithms are from https://github.com/raywenderlich/swift-algorithm-club

class Solution {

    // linear search
    func linearSearch(_ arr: [Int], _ item: Int) -> Int {
        for (index, value) in arr.enumerated() {
            if value == item {
                return index
            }
        }
        return -1
    }

    // binary search (items in array are unique and arr is sorted)
    func binarySearch(_ arr: [Int], _ item: Int) -> Int {
        var l = 0
        var r = arr.count - 1
        while (l <= r) {
            let mid = (l + r) / 2
            if (arr[mid] == item) 
                return mid
            else if (arr[mid] > item)
                r = mid - 1
            else 
                l = mid + 1
        }
        return -1
    }

    // bubble sort
    func bubbleSort(_ arr: [Int]) -> [Int] {
        var swapped = false
        var copyArr = arr
        for i in 1 ..< arr.count - 1 {
            for j in 0 ..< arr.count - i {
                if (copyArr[j] > copyArr[j + 1]) {
                    var tmp = copyArr[j + 1]
                    copyArr[j + 1] = copyArr[j]
                    copyArr[j] = tmp
                    swapped = true
                }
            }
            if (!swapped) return copyArr
        }
        return copyArr
    }

    // quick sort 
    func quickSort(_ arr: [Int]) -> [Int] {
        // guard arr.count > 1 else { return arr}
        if (arr.count < 2)
            return arr
        
        let pivotIndex = arr.count / 2
        let pivot = arr[pivotIndex]

        // create an empty array
        var lo = [Int]()
        var hi = [Int]()
        var res = [Int]()

        for i in 0..<arr.count {
            if (arr[i] < pivot || (arr[i] == pivot && i != pivotIndex)) {
                lo.append(arr[i])
            } else if (arr[i] > pivot) {
                hi.append(arr[i])
            }
        }

        res.append(quickSort(lo))
        res.append(pivot)
        res.append(quickSort(hi))

        return res
    }

    // merge sort
    func mergeSort(_ arr: [Int]) -> [Int] {
        if (arr.count < 2)
            return arr
        
        let mid = arr.count / 2

        var left = [Int]()
        var right = [Int]()
        var res = [Int]()

        for i in 0..<mid {
            left.append(arr[i])
        }
        for i in mid..<arr.count {
            right.append(arr[i])
        }

        left = mergeSort(left)
        right = mergeSort(right)

        var indexLeft = 0, indexRight = 0, indexRes = 0
        while indexLeft < left.count || indexRight < right.count {
            if indexLeft < left.count && indexRight < right.count {
                if left[indexLeft] <= right[indexRight] {
                    res[indexRes] = left[indexLeft]
                    indexRes += 1
                    indexLeft += 1
                } else {
                    res[indexRes] = right[indexRight]
                    indexRes += 1
                    indexRight += 1
                }
            } else if indexLeft < left.count {
                res[indexRes] = left[indexLeft]
                indexRes += 1
                indexLeft += 1
            } else if indexRight < right.count {
                res[indexRes] = right[indexRight]
                indexRes += 1
                indexRight += 1
            }
        }

        return res
    }

    // heap sort
    func heapSort(_ arr: [Int]) -> [Int] {
        var res = arr
        let len = arr.count
        let tmp = len / 2 - 1


        for i in stride(from: tmp, through: 0, by: -1) {
            heapify(res, len, i)
        }

        for i in stride(from: len - 1, through: 1, by: -1) {
            swap(&res[0], &res[i])
            heapify(res, i, 0)
        }

        return res
    }

    func heapify(_ arr: [Int], _ n: Int, _ i: Int) {
        let left = 2 * i + 1
        let right = 2 * i + 2
        var max = indexLeft
        if left < n && arr[left] > arr[max] {
            max = left
        }
        if right < n && arr[right] > arr[max] {
            max = right
        }
        if max != i {
            swap(&arr[max], &arr[i])
            heapify(arr, n , max)
        }
    }

    // selection sort
    func selectionSort(_ arr: [Int]) -> [Int] {
        if arr.count < 2 {
            return arr
        }

        var res = arr
        for i in 0..<res.count - 1 {
            var minIndex = i

            for j in i + 1..<res.count {
                if res[j] < res[min] {
                    minIndex = j
                }
            }

            if i != min {
                res.swapAt(i, minIndex)
            }
         }

         return res
    }

    // insertion sort
    func insertionSort(_ arr: [Int]) -> [Int] {
        if arr.count < 2 {
            return arr
        }
        var res = arr;
        for i in 1..<res.count {
            var currentIndex = i
            while currentIndex > 0 && res[currentIndex] < res[currentIndex - 1] {
                res.swapAt(currentIndex - 1, currentIndex)
                currentIndex -= 1
            }
        }

        return res
    }

    // optimised insertion sort
    func insertionSort2(_ arr:[Int]) -> [Int] {
        if arr.count < 2 {
            return arr
        }
        var res = arr;
        for i in 1..<res.count {
            var currentIndex = i
            let tmp = res[currentIndex]
            while currentIndex > 0 && tmp < res[currentIndex - 1] {
                res[currentIndex] = res[currentIndex - 1]
                currentIndex -= 1
            }
            res[currentIndex] = tmp
        }
        return res
    }

}