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
}