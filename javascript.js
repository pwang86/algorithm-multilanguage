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
    const mid = Math.floor((l + r) / 2); // const mid = (l + r) >> 1;
    const guess = arr[mid];
    if (guess == item) return mid;
    if (guess > item) r = mid - 1;
    else l = mid + 1;
  }
  return -1;
};

// bubble sort
/**
 * 
 * @param {number[]} arr 
 * @returns {number[]} 
 */
const bubbleSort = arr => {
  let swapped = false;
  let a = [...arr];
  for (let i = 1; i < a.length - 1; i++) {
    for (let j = 0; j < a.length - i; j++) {
      if (a[j] > a[j + 1]) {
        [a[j], a[j + 1]] = [a[j + 1], a[j]];
        swapped = true;
      } 
    }
    if (!swapped) return a;
  }
  return a;
};