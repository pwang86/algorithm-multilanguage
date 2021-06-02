class Solution:
    
    #linear search
    def linearSearch(self, arr: List[int], item: int) -> int:
        for i in range(len(arr)):
            if arr[i] == item:
                return i
        return -1