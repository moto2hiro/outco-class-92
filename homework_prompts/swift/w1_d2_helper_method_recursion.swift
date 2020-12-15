/**
 *  Homework 04 - Helper Method Recursion
 *
 *  Solve the following problems using helper method recursion.
 */


/**
 * 1a. What is the term when the recursive call invokes itself more than once.
 *
 */


/**
 * 1b. List the steps involved to build a Helper Method Recursion algorithm.
 *
 */


/**
 * 1c. Should the recursive case or base case typically be tackled first?
 *
 */


/**
 * 2a. Print each item in an array in order
 *
 * Input:   arr: [Int]
 * Output:  Void
 *
 * Example: printArray([1,2,3]) =>
 *          1
 *          2
 *          3
 */
 func printArray(_ arr: [Int]) {
  // YOUR WORK HERE
}


/**
 * 2b. Print each item in an array backwards
 *
 * Input:   arr: [Int]
 * Output:  Void
 *
 * Example: printReverse([1, 2, 3]) =>
 *          3
 *          2
 *          1
 */
func printReverse(_ arr: [Int]) {
  // YOUR WORK HERE
}


/**
 * 2c. Reverse a string
 *
 * Input:   str: String
 * Output:  String
 *
 * Example: reverseString("hello") => "olleh"
 */
func reverseString(_ str: String) -> String {
  // YOUR WORK HERE
  return ""
}


/**
 * 2d. Given an array of integers, create an array of two-item arrays
 *
 * Input:   arr [Int]
 * Output:  [[Int]]
 *
 * Example: arrayPairs([1, 2, 3, 4, 5, 6])  =>    [[1, 2], [3, 4], [5, 6]]
 * Example: arrayPairs([1, 2, 3, 4, 5])     =>    [[1, 2], [3, 4], [5, -1]]
 */
 func arrayPairs(_ arr: [Int]) -> [[Int]] {
   // YOUR WORK HERE
   return [[Int]]()
 }


/**
 * 2e. Flatten a nested array
 *
 * Input:   arr: [[Int]]
 * Output:  [Int]
 *
 * Example: flatten([[1, 2, 3], [4], [5, 6]]) => [1, 2, 3, 4, 5, 6]
 */
func flatten(_ arr: [[Int]]) -> [Int] {
  // YOUR WORK HERE
  return [Int]()
}


/**
 * 2f. Given a base and an exponent, create a func to find the power
 *
 * Input:   base: Int
 * Input:   exponent: Int
 * Output:  Int
 *
 * Example: power(3, 4) => 81
 *
 * 1 --> 3 --> 9 --> 27 --> 81
 */
func power(_ base: Int, _ exponent: Int) -> Int {
  // YOUR WORK HERE
  return 0
}


/**
 * 2g. Merge two sorted arrays
 *
 * Input:   arr1 [Int]
 * Input:   arr2 [Int]
 * Output:  [Int]
 *
 * Example: merge([1, 4, 7], [2, 3, 6, 9]) => [1, 2, 3, 4, 6, 7, 9]
 */
func merge(_ arr1: [Int], _ arr2: [Int]) -> [Int] {
  // YOUR WORK HERE
  return [Int]()
}


////////////////////////////////////////////////////////////
///////////////  DO NOT TOUCH TEST BELOW!!!  ///////////////
////////////////////////////////////////////////////////////

func assert(_ count: inout [Int], _ name: String, _ test: () -> Bool) {
  if count.count != 2 {
    count = [0, 0]
  } else {
    count[1] = count[1] + 1
  }

  var pass: String = "false"

  if test() {
    pass = " true"
    count[0] = count[0] + 1
  }
  print(count[1], ")   ", pass, ":", name)
}

var testCount: [Int] = [0, 0]


print("reverseString tests")

assert(&testCount, "able to reverse string 'hello'",  {
  let test:String = reverseString("hello")
  return test == "olleh"
})

assert(&testCount, "returns '' for an empty string input",  {
  let test:String = reverseString("")
  return test == ""
})

assert(&testCount, "returns same character for a single character input",  {
  let test:String = reverseString("a")
  return test == "a"
})

print("PASSED: ", testCount[0], " / ", testCount[1], "\n\n")
testCount = [0, 0]



print("arrayPairs tests")

assert(&testCount, "should return [[1, 2],[3, 4],[5, 6]] output for [1, 2, 3, 4, 5, 6] input",  {
  let test:[[Int]] = arrayPairs([1, 2, 3, 4, 5, 6])
  return test.count == 3 &&
    test[0][0] == 1 && test[0][1] == 2 &&
    test[1][0] == 3 && test[1][1] == 4 &&
    test[2][0] == 5 && test[2][1] == 6
})

assert(&testCount, "should return [[1, 2],[3, 4],[5, -1]] output for [1, 2, 3, 4, 5] input",  {
  let test:[[Int]] = arrayPairs([1, 2, 3, 4, 5])
  return test.count == 3 &&
    test[0][0] == 1 && test[0][1] == 2 &&
    test[1][0] == 3 && test[1][1] == 4 &&
    test[2][0] == 5 && test[2][1] == -1
})

assert(&testCount, "should return [] output for [] input",  {
  let test:[[Int]] = arrayPairs([])
  return test.count == 0
})

print("PASSED: ", testCount[0], " / ", testCount[1], "\n\n")
testCount = [0, 0]



print("flatten tests")

assert(&testCount, "should return [1, 2, 3, 4, 5, 6] output for [1, [2, 3, [4]], 5, [[6]]] input",  {
  let test:[Int] = flatten([[1], [2, 3, 4], [5], [6]])
  return test.count == 6 &&
    test[0] == 1 && test[1] == 2 &&
    test[2] == 3 && test[3] == 4 &&
    test[4] == 5 && test[5] == 6
})

assert(&testCount, "should return [] output for [] input",  {
  let test:[Int] = flatten([])
  return test.count == 0
})

assert(&testCount, "should return [1, 2, 3, 4, 5, 6] output for [1, [2, 3, [4], []], [], 5, [[], [6]]] input (note the empty arrays)",  {
  let test:[Int] = flatten([[1], [2, 3, 4], [], [5], [], [6]])
  return test.count == 6 &&
    test[0] == 1 && test[1] == 2 &&
    test[2] == 3 && test[3] == 4 &&
    test[4] == 5 && test[5] == 6
})

print("PASSED: ", testCount[0], " / ", testCount[1], "\n\n")
testCount = [0, 0]



print("power tests")

assert(&testCount, "should return 81 for 3 to the 4th power",  {
  let test:Int = power(3, 4)
  return test == 81
})

assert(&testCount, "should return 1 for 5 to the 0th power",  {
  let test:Int = power(5, 0)
  return test == 1
})

assert(&testCount, "should return 1 for 1 to the 100th power",  {
  let test:Int = power(1, 100)
  return test == 1
})

print("PASSED: ", testCount[0], " / ", testCount[1], "\n\n")
testCount = [0, 0]



print("merge tests")

assert(&testCount, "should return [1, 2, 3, 4, 6, 7, 9] when merging [1, 4, 7] and [2, 3, 6, 9]",  {
  let test:[Int] = merge([1, 4, 7], [2, 3, 6, 9])
  return test.count == 7 && test[0] == 1 &&
    test[1] == 2 && test[2] == 3 &&
    test[3] == 4 && test[4] == 6 &&
    test[5] == 7 && test[6] == 9;
})

assert(&testCount, "should handle inputs when left argument is empty array",  {
  let test:[Int] = merge([], [2, 3, 6, 9])
  return test.count == 4 &&
    test[0] == 2 &&
    test[1] == 3 &&
    test[2] == 6 &&
    test[3] == 9
})

assert(&testCount, "should handle inputs when right argument is empty array",  {
  let test:[Int] = merge([1, 4, 7], [])
  return test.count == 3 &&
    test[0] == 1 &&
    test[1] == 4 &&
    test[2] == 7
})

assert(&testCount, "should handle two empty arrays as inputs",  {
  let test:[Int] = merge([], [])
  return test.count == 0
})

print("PASSED: ", testCount[0], " / ", testCount[1], "\n\n")
