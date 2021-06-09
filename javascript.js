// All algorithms are from https://www.30secondsofcode.org/ 

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

// quick sort
/**
 * 
 * @param {number[]} arr 
 * @returns {number[]} 
 */
const quickSort = arr => {
  if (arr.length < 2) return arr;
  const copyArr = [...arr];
  const pivotIndex = a.length >> 1;
  const pivot = copyArr[pivotIndex];
  const [lo, hi] = copyArr.reduce(
    (acc, val, i) => {
      if (val < pivot || (val == pivot && i != pivotIndex)) {
        acc[0].push(val);
      } else if (val > pivot) {
        acc[1].push(val);
      }
      return acc;
    },
    [[],[]]
  );
  return [...quickSort(lo), pivot, ...quickSort(hi)];
};

// merge sort
/**
 * 
 * @param {number[]} arr 
 * @returns {number[]} 
 */
const mergeSort = arr => {
  if (arr.length < 2) return arr;

  const mid = arr.length >> 1;
  const l = mergeSort(arr.slice(0, mid));
  const r = mergeSort(arr.slice(mid, arr.length));
  return Array.from({length: l.length + r.length}, () => {
    if (l.length == 0) return r.shift();
    else if (r.length == 0) return l.shift();
    else return l[0] > r[0] ? r.shift() : l.shift();
  });
};

// heap sort
/**
 * 
 * @param {number[]} arr 
 * @returns {number[]} 
 */
const heapSort = arr => {
  const copyArr = [...arr];
  let len = copyArr.length;

  const heapify = (a, i) => {
    const left = 2 * i + 1;
    const right = 2 * i + 2;

    let max = i;
    if (left < len && a[left] > a[max]) max = left;
    if (right < len && a[right] > a[max]) max = right;
    if (max != i) {
      [a[max], a[i]] = [a[i], a[max]];
      heapify(a, max);
    }
  };

  for (let i = len >> 1 - 1; i >= 0; i--) heapify(copyArr, i);
  for (let i = len - 1; i > 0; i--) {
    [a[0], a[i]] = [a[i], a[0]];
    heapify(copyArr, 0);
  }
  return copyArr;
};