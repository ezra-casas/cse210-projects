using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello World! This is the Exercise5 Project.");
    DisplayWelcome();
    string username = PromptUserName();
    int number = PromptUserNumber();

    DisplayResult(number, username);
  }


  static void DisplayWelcome(){
    Console.WriteLine("Welcome to the Program!");
  }

  static string PromptUserName(){
    Console.WriteLine("Please enter your name: ");
    string username = Console.ReadLine();  
    return username;
  }
  static int PromptUserNumber(){
    Console.WriteLine("Please enter your favorite number: ");
    int number = int.Parse(Console.ReadLine());
    return number;
  }

  static int SquareNumber(int number){
    return number * number;
  }

  static void DisplayResult(int number, string username){
    Console.WriteLine($"{username}, the square of your number is {SquareNumber(number)}");
  }

}
