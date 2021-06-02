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
}