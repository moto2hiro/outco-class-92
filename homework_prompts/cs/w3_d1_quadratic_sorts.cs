﻿/**
 *  Homework 07 - Quadratic Sorts
 *
 *  Problem 1: Insertion Sort
 *
 *  Prompt:    Given an unsorted array of integers, return the array sorted
 *             using insertion sort.
 *
 *  Input:     input {Array}
 *  Output:    {Array}
 *
 *  Example:   [3,9,1,4,7] --> [1,3,4,7,9]
 *
 *
 *  Problem 2: Selection Sort
 *
 *  Prompt:    Given an unsorted array of integers, return the array
 *             sorted using selection sort.
 *
 *  Input:     input {Array}
 *  Output:    {Array}
 *
 *  Example:   [3,9,1,4,7] --> [1,3,4,7,9]
 *
 *
 *  Problem 3: Bubble Sort
 *
 *  Prompt:    Given an unsorted array of integers, return the array
 *             sorted using bubble sort.
 *
 *  Input:     input {Array}
 *  Output:    {Array}
 *
 *  Example:   [3,9,1,4,7] --> [1,3,4,7,9]
 */

using System;
using System.Linq;


class BasicSort
{

  // Time Complexity: O(N^2)
  // Auxiliary Space Complexity: O(1)
  public static int[] insertion(int[] input)
  {
    if (input == null || input.Length == 0) return null;

    for (var i = 1; i < input.Length; i++)
    {
      var j = i;
      var canShiftMore = true;
      while (canShiftMore && j > 0)
      {
        if (input[j] > input[j - 1])
        {
          canShiftMore = false;
        }
        else
        {
          var tmp = input[j];
          input[j] = input[j - 1];
          input[j - 1] = tmp;
          j--;
        }
      }
    }

    return input;
  }


  // Time Complexity: O(N^2)
  // Auxiliary Space Complexity: O(1)
  public static int[] selection(int[] input)
  {
    if (input == null || input.Length == 0) return null;

    for (var i = 0; i < input.Length; i++)
    {
      var minIdx = i;
      for (var j = i; j < input.Length; j++)
      {
        if (input[j] < input[minIdx])
        {
          minIdx = j;
        }
      }
      var tmp = input[i];
      input[i] = input[minIdx];
      input[minIdx] = tmp;
    }

    return input;
  }


  // Time Complexity: O(N^2)
  // Auxiliary Space Complexity: O(1)
  public static int[] bubble(int[] input)
  {
    if (input == null || input.Length == 0) return null;

    var hasSwapped = true;
    while (hasSwapped)
    {
      hasSwapped = false;
      for (var i = 0; i < input.Length - 1; i++)
      {
        if (input[i] > input[i + 1])
        {
          var tmp = input[i];
          input[i] = input[i + 1];
          input[i + 1] = tmp;
          hasSwapped = true;
        }
      }
    }

    return input;
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
    sortTests("Insertion Sort Tests", BasicSort.insertion);
    sortTests("Selection Sort Tests", BasicSort.selection);
    sortTests("Bubble Sort Tests", BasicSort.bubble);
  }

  private static void sortTests(String testName, Func<int[], int[]> sorter)
  {
    int[] testCount = { 0, 0 };
    Console.WriteLine(testName);
    runTest(sortTest1, sorter, "should sort example input", testCount);
    runTest(sortTest2, sorter, "should sort single-element input", testCount);
    runTest(sortTest3, sorter, "should sort moderate-sized input", testCount);
    Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
  }

  private static bool sortTest1(Func<int[], int[]> sorter)
  {
    return sorter(new int[] { 3, 9, 1, 4, 7 }).SequenceEqual(new int[] { 1, 3, 4, 7, 9 });
  }

  private static bool sortTest2(Func<int[], int[]> sorter)
  {
    return sorter(new int[] { 10 }).SequenceEqual(new int[] { 10 });
  }

  private static bool sortTest3(Func<int[], int[]> sorter)
  {
    int[] input = new int[1000];
    int[] solution = new int[1000];
    int randNum;
    Random rand = new Random();
    for (int i = 0; i < input.Length; i++)
    {
      randNum = rand.Next(0, 1000);
      input[i] = randNum;
      solution[i] = randNum;
    }
    input = sorter(input);
    Array.Sort(solution);
    return isSorted(input) && input.SequenceEqual(solution);
  }


  // checks if array is sorted in linear time
  private static bool isSorted(int[] input)
  {
    for (int i = 1; i < input.Length; i++)
    {
      if (input[i - 1] > input[i])
      {
        return false;
      }
    }
    return true;
  }


  // do not edit below, this is to wrap the test and check for exceptions
  private static void runTest(Func<Func<int[], int[]>, bool> test,
          Func<int[], int[]> sorter, string testName, int[] testCount)
  {

    testCount[1]++;
    bool testPassed = false;
    // Attempt to run test and suppress exceptions on failure
    try
    {
      testPassed = test(sorter);
      if (testPassed) testCount[0]++;
    }
    catch { }
    string result = "  " + (testCount[1] + ")   ") + testPassed + " : " + testName;
    Console.WriteLine(result);
  }
}