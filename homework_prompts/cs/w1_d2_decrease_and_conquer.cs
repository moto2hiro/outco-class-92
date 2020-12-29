/*
 * Homework 03 - Decrease and Conquer
 * Utilize the decrease and conquer pattern to solve these problems.
 */

using System;
using System.Linq;
using System.Collections.Generic;

class Problems
{

  /*
   *
   *  Number of Ones
   *
   * *Given a sorted bit array (values of either 0 or 1), determine the number of 1's in the array.*
   *
   * **Parameters**
   * Input: arr {Array of ints}
   * Output: {int}
   *
   * **Constraints**
   * Time: O(logN)
   * Space: O(1)
   *
   * **Examples**
   * `[0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1] --> 8`
   * `[0, 0, 0] --> 0`
   * `[0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1] --> 7`
   */

  public static int numberOfOnes(int[] arr)
  {
    if (arr == null || arr.Length == 0 || (arr.Length == 1 && arr[0] == 0))
    {
      return 0;
    }

    var left = 0d;
    var right = arr.Length - 1;
    var hasOne = false;
    while (left < right)
    {
      var mid = (int)Math.Floor(left + (right - left) / 2);
      if (arr[mid] == 1)
      {
        right = mid;
        hasOne = true;
      }
      else
      {
        left = mid + 1;
      }
    }

    return (hasOne) ? (int)(arr.Length - left) : 0;
  }


  /*
   * Closest Value
   *
   * Given a sorted bit array of integers, and a target value, find the number in the array that is closest to the target.*
   *
   * **Parameters**
   * Input: arr {Array of ints}
   * Input: target {int}
   * Output: {int}
   *
   * **Constraints**
   * If there are two numbers tied for the closest value, return the lowest value.
   *
   * Time: O(logN)
   * Space: O(1)
   *
   * **Examples**
   * `[1, 2, 3, 5, 5, 7, 9, 10, 11], 6 --> 5`
   * `[1, 2, 3], 8 --> 3`
   * `[1, 10, 22, 59, 67, 72, 100], 70 --> 72`
   */

  public static int closestValue(int[] arr, int target)
  {
    if (target <= arr[0])
      return arr[0];
    if (target >= arr[arr.Length - 1])
      return arr[arr.Length - 1];

    var left = 0d;
    var right = arr.Length - 1;
    var mid = 0;
    while (left < right)
    {
      mid = (int)Math.Floor(left + (right - left) / 2);
      if (arr[mid] == target)
      {
        return arr[mid];
      }

      if (target < arr[mid])
      {
        if (mid > 0 && target > arr[mid - 1])
        {
          return getClosest(arr[mid - 1], arr[mid], target);
        }

        right = mid;
      }
      else
      {
        if (mid < right - 1 && target < arr[mid + 1])
        {
          return getClosest(arr[mid], arr[mid + 1], target);
        }

        left = mid + 1;
      }
    }

    return arr[mid];
  }

  public static int getClosest(int val1, int val2, int target)
  {
    if (target - val1 > val2 - target)
      return val2;
    else
      return val1;
  }


  /*
   * Square Root
   *
   * Given an positive integer, find the square root.*
   *
   * **Parameters**
   * Input: value {double}
   * Output: {double}
   *
   * **Constraints**
   * Do not use a native built in method.
   * Ensure the result is accurate to 6 decimal places (0.000001)
   *
   * Time: O(logN)
   * Space: O(1)
   *
   * **Examples**
   * `4 --> 2.0`
   * `98 --> 9.899495`
   * `14856 --> 121.885192
   */

  public static double squareRoot(double n)
  {
    if (n == 0 || n == 1)
      return n;

    var left = 0d;
    var right = n;
    var mid = 0d;
    while (left < right)
    {
      mid = left + (right - left) / 2;
      var square = (double)(mid * mid);
      if (square == n)
      {
        return mid;
      }

      if (n < square)
      {
        if (mid > 0 && n > square - 0.000001)
        {
          return Math.Round(mid, 6);
        }
        right = mid;
      }
      else
      {
        if (mid < right - 0.000001 && n < square + 0.000001)
        {
          return Math.Round(mid, 6);
        }
        left = mid + 0.000001;
      }
    }

    return Math.Round(mid, 6);
  }


  /*
   * Greater Values
   *
   * *Given an sorted array of integers, and a target value return the number of values greater the target.*
   *
   * **Parameters**
   * Input: arr {Array of ints}
   * Input: target {int}
   * Output: {int}
   *
   * **Constraints**
   *
   * Time: O(logN)
   * Space: O(1)
   *
   * **Examples**
   * `[1, 2, 3, 5, 5, 7, 9, 10, 11], 5 --> 4`
   * `[1, 2, 3], 4 --> 0`
   * `[1, 10, 22, 59, 67, 72, 100], 13 --> 5`
   *
  */

  public static int greaterValues(int[] arr, int target)
  {
    if (arr == null || arr.Length == 0)
    {
      return 0;
    }
    if (arr[0] > target)
    {
      return arr.Length;
    }
    if (arr[arr.Length - 1] < target)
    {
      return 0;
    }

    var left = 0d;
    var right = arr.Length - 1;
    var mid = 0;
    while (left < right)
    {
      mid = (int)Math.Floor(left + (right - left) / 2);
      if (arr[mid] > target)
      {
        right = mid;
      }
      else
      {
        left = mid + 1;
      }
    }
    return arr.Length - mid;
  }

  /*
   * Sorted and Rotated Array [Extra Credit]
   *
   * *Given a array that is sorted and rotated, find out if a target value exists in the array.*
   *
   * An sorted array is rotated by taking an unknown amount of values from the beginning and placing it at the end.
   *
   * `[3, 4, 5, 1, 2]` is rotated left by 2.
   * `[99, 14, 25, 78, 93]` is rotated to the right by 1.
   *
   * **Parameters**
   * Input: arr {Array of ints}
   * Input: target {int}
   * Output: {bool}
   *
   * **Constraints**
   * Time: O(logN)
   * Space: O(1)
   *
   * **Examples**
   * `[35, 46, 79, 102, 1, 14, 29, 31], 46 --> true`
   * `[35, 46, 79, 102, 1, 14, 29, 31], 47 --> false`
   * `[7, 8, 9, 10, 1, 2, 3, 4, 5, 6], 9 --> true`
   */

  public static bool rotatedArraySearch(int[] nums, int target)
  {
    var length = nums.Length - 1;
    var pivot = getPivot(nums, 0, length);

    // no pivot case
    if (pivot == -1)
    {
      return binarySearch(nums, 0, length, target);
    }

    // pivot is target case
    if (nums[pivot] == target)
    {
      return true;
    }

    // target is on the left side of pivot case
    if (nums[0] <= target)
    {
      return binarySearch(nums, 0, pivot - 1, target);
    }

    // target is on the right side of pivot case
    return binarySearch(nums, pivot + 1, length, target);
  }

  private static int getPivot(int[] nums, int start, int end)
  {
    if (end < start)
    {
      return -1;
    }
    if (end == start)
    {
      return start;
    }

    var mid = (start + end) / 2;
    if (mid < end && nums[mid] > nums[mid + 1])
    {
      return mid;
    }
    if (mid > start && nums[mid] < nums[mid - 1])
    {
      return (mid - 1);
    }
    if (nums[start] >= nums[mid])
    {
      return getPivot(nums, start, mid - 1);
    }
    return getPivot(nums, mid + 1, end);
  }

  private static bool binarySearch(int[] nums, int start, int end, int target)
  {
    if (end < start)
    {
      return false;
    }

    var mid = (start + end) / 2;
    if (nums[mid] == target)
    {
      return true;
    }

    // target is right side of pivot
    if (nums[mid] < target)
    {
      return binarySearch(nums, (mid + 1), end, target);
    }

    // target is left side of pivot
    return binarySearch(nums, start, (mid - 1), target);
  }

  /*
   * Multiplication Using Russian Peasant [Extra Credit]
   *
   * *Given two positive integers, return its product using Russian Peasant method of multiplication*
   *
   * Read up on how to apply the Russian Peasant method [here](https: *en.wikipedia.org/wiki/Ancient_Egyptian_multiplication). It is also referred to as the Egyptian multiplication.
   *
   * **Parameters**
   * Input: a {int}
   * Input: b {int}
   * Output: {int}
   *
   * **Constraints**
   * Assume a <= b, and the value of a is N.
   *
   * Time: O(logN)
   * Space: O(1)
   *
   * **Examples**
   * `487, 734 --> 357458`
   * `846, 908--> 768168`
   */

  public static int multiplicationRussianPeasant(int a, int b)
  {
    var ret = 0;

    while (b > 0)
    {
      if (b % 2 != 0)
      {
        ret += a;
      }
      a *= 2;
      b /= 2;
    }
    return ret;
  }
}




////////////////////////////////////////////////////////////
///////////////  DO NOT TOUCH TEST BELOW!!!  ///////////////
////////////////////////////////////////////////////////////

// use the Test class to run the test cases
class Test
{
  public static void Main()
  {
    Problems.closestValue(new int[] { 2, 4, 6, 10, 12 }, 20);

    numberOfOnesTests();
    closestValueTests();
    squareRootTests();
    greaterValuesTests();
    rotatedSortedArrayTests();
    multiplicationRussianTests();
  }

  private static void numberOfOnesTests()
  {
    int[] testCount = { 0, 0 };
    Console.WriteLine("Number Of Ones Tests");
    runTest(numberOfOnesTest1, "should return correct number of ones for array with zeroes and ones", testCount);
    runTest(numberOfOnesTest2, "should return correct number of ones for array with all zeroes", testCount);
    runTest(numberOfOnesTest3, "should return correct number of ones for array with all ones", testCount);
    Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
  }

  private static void closestValueTests()
  {
    int[] testCount = { 0, 0 };
    Console.WriteLine("Closest Value Tests");
    runTest(closestValueTest1, "should return correct closest value for number in the middle range", testCount);
    runTest(closestValueTest2, "should return closest value for highest number", testCount);
    runTest(closestValueTest3, "should return closest value for lowest number", testCount);
    Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
  }

  private static void squareRootTests()
  {
    int[] testCount = { 0, 0 };
    Console.WriteLine("Square Root Tests");
    runTest(squareRootTest1, "should return correct square root for number < 10", testCount);
    runTest(squareRootTest2, "should return correct square root for number between 10 and 100", testCount);
    runTest(squareRootTest3, "should return correct square root for number over 10,000", testCount);
    Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
  }

  private static void greaterValuesTests()
  {
    int[] testCount = { 0, 0 };
    Console.WriteLine("Greater Values Tests");
    runTest(greaterValuesTest1, "should return greater values for number in the middle of the array", testCount);
    runTest(greaterValuesTest2, "should return 0 for number greater than largest in the array", testCount);
    runTest(greaterValuesTest3, "should return length of array for number less than least in the array", testCount);
    Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
  }

  private static void rotatedSortedArrayTests()
  {
    int[] testCount = { 0, 0 };
    Console.WriteLine("Rotated Sorted Array Tests");
    runTest(rotatedSortedArrayTest1, "returns true when target is in the array", testCount);
    runTest(rotatedSortedArrayTest2, "returns false when target is not in the array", testCount);
    runTest(rotatedSortedArrayTest3, "returns true when target is the first number in the array", testCount);
    runTest(rotatedSortedArrayTest4, "returns true when target is the last number in the array", testCount);
    Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
  }

  private static void multiplicationRussianTests()
  {
    int[] testCount = { 0, 0 };
    Console.WriteLine("Multiplication Russian Tests");
    runTest(multiplicationRussianTest1, "returns correct value for two integers", testCount);
    Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
  }


  private static bool numberOfOnesTest1()
  {
    int output = Problems.numberOfOnes(new int[] { 0, 0, 0, 1, 1, 1 });
    return output == 3;
  }

  private static bool numberOfOnesTest2()
  {
    int output = Problems.numberOfOnes(new int[] { 0, 0, 0, 0, 0, 0 });
    return output == 0;
  }

  private static bool numberOfOnesTest3()
  {
    int output = Problems.numberOfOnes(new int[] { 1, 1, 1, 1, 1 });
    return output == 5;
  }


  private static bool closestValueTest1()
  {
    int output = Problems.closestValue(new int[] { 1, 2, 3, 5, 5, 7, 9, 10, 11 }, 6);
    return output == 5;
  }

  private static bool closestValueTest2()
  {
    int output = Problems.closestValue(new int[] { 1, 2, 3 }, 8);
    return output == 3;
  }

  private static bool closestValueTest3()
  {
    int output = Problems.closestValue(new int[] { -2, -1, 0 }, -5);
    return output == -2;
  }

  private static bool squareRootTest1()
  {
    double output = Problems.squareRoot(4.0);
    return output == 2.0;
  }

  private static bool squareRootTest2()
  {
    double output = Problems.squareRoot(98.0);
    return output == 9.899495;
  }

  private static bool squareRootTest3()
  {
    double output = Problems.squareRoot(14856.0);
    return output == 121.885192;
  }


  private static bool greaterValuesTest1()
  {
    int output = Problems.greaterValues(new int[] { 1, 2, 3, 5, 5, 7, 9, 10, 11 }, 5);
    return output == 4;
  }

  private static bool greaterValuesTest2()
  {
    int output = Problems.greaterValues(new int[] { 1, 2, 3 }, 4);
    return output == 0;
  }

  private static bool greaterValuesTest3()
  {
    int output = Problems.greaterValues(new int[] { 1, 10, 22, 59, 67, 72, 100 }, -2);
    return output == 7;
  }


  private static bool rotatedSortedArrayTest1()
  {
    bool output = Problems.rotatedArraySearch(new int[] { 35, 46, 79, 102, 1, 14, 29, 31 }, 46);
    return output == true;
  }

  private static bool rotatedSortedArrayTest2()
  {
    bool output = Problems.rotatedArraySearch(new int[] { 35, 46, 79, 102, 1, 14, 29, 31 }, 47);
    return output == false;
  }

  private static bool rotatedSortedArrayTest3()
  {
    bool output = Problems.rotatedArraySearch(new int[] { 7, 8, 9, 10, 1, 2, 3, 4, 5, 6 }, 7);
    return output == true;
  }

  private static bool rotatedSortedArrayTest4()
  {
    bool output = Problems.rotatedArraySearch(new int[] { 7, 8, 9, 10, 1, 2, 3, 4, 5, 6 }, 6);
    return output == true;
  }


  private static bool multiplicationRussianTest1()
  {
    int output = Problems.multiplicationRussianPeasant(487, 734);
    return output == 357458;
  }


  private static void runTest(Func<bool> test, string testName, int[] testCount)
  {
    testCount[1]++;
    bool testPassed = false;
    // Attempt to run test and suppress exceptions on failure
    try
    {
      testPassed = test();
      if (testPassed) testCount[0]++;
    }
    catch { }
    string result = "  " + (testCount[1] + ")   ") + testPassed + " : " + testName;
    Console.WriteLine(result);
  }
}
