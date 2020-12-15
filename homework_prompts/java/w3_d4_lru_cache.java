//
//  Homework 15 - LRU Cache
//
//  Problem: LRU Cache
//
//  Instructions: LRU Cache is a popular and challenging algorithm question
//                commonly asked during whiteboarding and tech screen sessions.
//
//                While difficult, this exercise is a good problem to test your
//                ability to build and manipulate data structures.
//
//                Design and implement a data structure for a Least Recently
//                Used (LRU) Cache.
//
//                This implementation involves a doubly linked list and a hash map.
//
//          NOTE: A LRU caching scheme is designed to remove the least recently
//                used item when a new item is added to the cache which is
//                currently at or has just reached capacity.
//
//                An item is considered to be recently used if it has just been
//                accessed or added.
//
//          I.  Node Class
//              Create a Node class
//
//              The Node class should contain the following properties:
//              key: {Integer}
//              value: {Integer}
//              previous: {Node} (initially None)
//              next: {Node} (initially None)
//
//         II.  LRUCache Class
//              Create an LRUCache class
//
//              The LRUCache class should contain the following properties:
//              capacity: {Integer}
//              count: {Integer} (initially 0)
//              cache: {Hash Table} The keys represent unique ids of each node, and the values represent the node objects
//                                that possess those keys.
//              head: {Node}
//              tail: {Node}
//
//     Your LRU cache should have the following methods:
//
//      get(key): Retreives a value from the cache (will always be positive) at
//                the key if the key exists in the cache, otherwise returns -1.
//
// set(key,value): Inserts the value at the key or creates a new key:value entry
//                if key is not present. When the cache reaches its capacity, it
//                should invalidate the least recently used item before
//                inserting a new item.
//
//          HINT: Consider what data structure(s) might be neccessary to
//                implement the LRU Cache
//
//     Example:
//     lruCache = new LRUCache(3);
//     lruCache.set('doc', 'david');
//     lruCache.set('cpo', 'joshua');
//     lruCache.set('ceo', 'andy');
//
//     lruCache.get('doc'); => 'david'
//     lruCache.set('swe', 'ron');
//     lruCache.get('cpo'); => -1
//
//

import java.util.*;

class Node {
}


class LRUCache{


  /**
   * Always add the new node right after head;
   */
  private void addNode(Node node){
  }

  /**
   * Remove an existing node from the linked list.
   */
  private void removeNode(Node node){
  }

  /**
   * Move certain node in between to the head.
   */
  private void moveToHead(Node node){
  }

  // pop the current tail.
  private Node removeFromTail(){
    //YOUR WORK HERE
    return new Node();
  }

  private Hashtable<String, Node> cache = new Hashtable<String, Node>();
  private int count;
  private int capacity;
  private Node head, tail;

  public LRUCache(int capacity) {
  }

  public String get(String key) {
    // YOUR WORK HERE
    return " ";
  }


  public void set(String key, String value) {
  }



}

























////////////////////////////////////////////////////////////
///////////////  DO NOT TOUCH TEST BELOW!!!  ///////////////
////////////////////////////////////////////////////////////

// use the Main class to run the test cases
class Main {
  private int[] testCount;

  // an interface to perform tests
  public interface Test {
    public boolean execute();
  }

  public static void main(String[] args) {

    // instantiate the testing of each module by resetting count and printing title of module
    int[] testCount = {0, 0};
    System.out.println("LRU Cache tests");

    // tests are in the form as shown
    assertTest(testCount, "should be able to set and get key-value pairs", new Test() {
      public boolean execute() {

        LRUCache lruCache = new LRUCache(3);
        lruCache.set("doc", "david");
        lruCache.set("cpo", "joshua");
        lruCache.set("ceo", "andy");
        String example1 = lruCache.get("doc");
        String example2 = lruCache.get("cpo");
        String example3 = lruCache.get("ceo");
        return example1 == "david" && example2 == "joshua" && example3 == "andy";

      }
    });

    // tests are in the form as shown
    assertTest(testCount, "should be able overwrite values with same keys when using set method", new Test() {
      public boolean execute() {

        LRUCache lruCache = new LRUCache(3);
        lruCache.set("student", "henry");
        lruCache.set("student", "eliza");
        String example = lruCache.get("student");
        return example == "eliza";
      }
    });

    // tests are in the form as shown
    assertTest(testCount, "old key value pairs should be removed when capacity has been exceeded", new Test() {
      public boolean execute() {

        LRUCache lruCache = new LRUCache(3);
        lruCache.set("dentist", "akali");
        lruCache.set("doctor", "swain");
        lruCache.set("lawyer", "kennan");
        lruCache.set("judge", "leona");
        return lruCache.get("dentist") == null && lruCache.get("doctor") == "swain";
      }
    });

    // tests are in the form as shown
    assertTest(testCount, "most recently modified/viewed items should be moved to front of LRU cache while stale items are moved to end", new Test() {
      public boolean execute() {

        LRUCache lruCache = new LRUCache(3);
        lruCache.set("doc", "david");
        lruCache.set("cpo", "joshua");
        lruCache.set("ceo", "andy");
        lruCache.get("doc");
        lruCache.set("swe", "ron");
        return lruCache.get("cpo") == null && lruCache.get("swe") == "ron";
      }
    });

    // tests are in the form as shown
    assertTest(testCount, "should be able to replace multiple stale items", new Test() {
      public boolean execute() {

        LRUCache lruCache = new LRUCache(3);
        lruCache.set("one", "hello");
        lruCache.set("two", "bye");
        lruCache.set("three", "blah");
        lruCache.set("four", "foo");
        lruCache.set("five", "fum");
        lruCache.set("six", "great");
        String ex1 = lruCache.get("one");
        String ex2 = lruCache.get("two");
        String ex3 = lruCache.get("three");
        String ex4 = lruCache.get("four");
        String ex5 = lruCache.get("five");
        String ex6 = lruCache.get("six");
        return ex1 == null && ex2 == null && ex3 == null && ex4 == "foo" && ex5 == "fum" && ex6 == "great";
      }
    });

    // print the result of tests passed for a module
    System.out.println("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");

  }


  // do not edit below, this is to wrap the test and check for exceptions
  private static void assertTest(int[] count, String name, Test test) {
    String pass = "false";
    count[1]++;

    try {
      if (test.execute()) {
        pass = " true";
        count[0]++;
      }
    } catch(Exception e) {}
    String result = "  " + (count[1] + ")   ").substring(0, 5) + pass + " : " + name;
    System.out.println(result);
  }
}
