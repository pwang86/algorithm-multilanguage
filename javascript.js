// Linear Search
/**
 * 
 * @param {number[]} arr 
 * @param {number} item 
 * @returns {number} 
 */
const linearSearch = (arr, item) => {
  for (const i in arr) {
    if (arr[i] == item) return +i; // use unary + to convert index from a string to a number
  }
  return -1;
};

// binary search (sorted array)
/**
 * 
 * @param {number[]} arr 
 * @param {number} item 
 * @returns {number} 
 */
const binarySearch = (arr, item) => {
  let l = 0, r = arr.length - 1;
  while (l <= r) {
    const mid = Math.floor((l + r) / 2);
    const guess = arr[mid];
    if (guess == item) return mid;
    if (guess > item) r = mid - 1;
    else l = mid + 1;
  }
  return -1;
};