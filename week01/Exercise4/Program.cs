using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        // List<T> variableName;
        // List<int> numbers;
        // List<string> words;
        // We need to initialize these classes via: new List<t>();
        //
        
        Console.WriteLine("Enter a list of numbers. Type 0 to finish.");
        
        bool loop = true;
        List<int> numbers = new List<int>();
        int total = 0;

        while(loop){
          int number = int.Parse(Console.ReadLine());
          if(number == 0){
            loop = false;
            break;
          }
          else{
            numbers.Add(number);
            total += number;

          }
        }
        Console.WriteLine($"Total: {total}");

        double average = total / numbers.Count;
        Console.WriteLine($"Average: {average}");
    }
}
