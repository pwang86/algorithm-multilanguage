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
