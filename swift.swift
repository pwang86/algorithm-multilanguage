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
}