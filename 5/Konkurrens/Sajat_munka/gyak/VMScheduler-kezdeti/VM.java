import java.util.concurrent.BlockingQueue;
import java.util.concurrent.ArrayBlockingQueue;

public class VM3 {
  static class Process {
    // TODO változók létrehozása
	// TODO create variables
	
    // TODO konstruktor készítése
	// TODO write a constructor
	
    // TODO getter metódus a feladatban leírt változóhoz
	// TODO write the getter methods mentioned in the task description
	
    // TODO feladat elvégézését szimuláló metódus
	// TODO method simulating the completion of a task
    public void dispatch() {
    }

    public static void work(int ms) {
      try {
        Thread.sleep(ms);
      } catch (InterruptedException e) { e.printStackTrace(); }
    }
  }

  // TODO 3. Feladat naplózás
  // TODO Task 3: logging
  static class ConsoleLogger implements Runnable {
  }

  private static BlockingQueue<Process> queue = new ArrayBlockingQueue<>(8);
  
  //TODO 2. Feladat atomi változók létrehozása
  //TODO Rask 2: create atomic variables
  
  
  //  private static ConsoleLogger consoleLogger = new ConsoleLogger();


  public static void main(String[] args) {
  }

  // TODO 1. Feladat
  // TODO Task 1
  public static void part1() {

  }

  // TODO 2. Feladat
  // TODO Task 2
  public static void part2() {
  }

  // TODO 3. Feladat
  // TODO Task 3
  public static void part3() {

  }

  // TODO 2. Feladat
  // TODO Task 2
  private static void gracefulShutdown(Thread user, Thread scheduler) {

  }

  // TODO 1. Feladat
  // TODO Task 1
  private static Thread startUser1() {

  }

  // TODO 1. Feladat
  // TODO Task 1
  private static Thread startScheduler1() {

  }
  
  // TODO 2. Feladat
  // TODO Task 2
  private static Thread startUser2() {

  }

  // TODO 2. Feladat
  // TODO Task 2
  private static Thread startScheduler2() {

  }
}
