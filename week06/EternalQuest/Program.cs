using System;

/*
-------------------------------------
Eternal Quest – Created by Carlos Enrique Guardado Cruz
Course: W06 Project: Eternal Quest Program
Description:
  Console program to track goals: Simple, Eternal, and Checklist.
  Implements inheritance, polymorphism, encapsulation, saving/loading.

Extra Features Implemented (Creativity - Level System):
  - Player Rank System (levels based on score): Novice, Adventurer, Hero, Master, Eternal Legend.
  - Program notifies when the player levels up.
  - All classes are in separate files and follow naming / style conventions.
-------------------------------------
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest! ");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
