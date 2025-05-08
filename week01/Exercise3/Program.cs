using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello World! This is the Exercise3 Project.");

    bool playAgain = true;
    while (playAgain){

      bool gameActive = true;
      Random ranNum = new Random();
      int number = ranNum.Next(1,100);
      int score = 0;
      while(gameActive == true){ 
        Console.WriteLine("Between 1 and 100, What's your guess?");
        int guess = int.Parse(Console.ReadLine());
        score++;
        if (guess == number){gameActive = false;}
        if(guess < number){
          Console.WriteLine("Higher!");
        }
        if (guess > number){
          Console.WriteLine("Lower!");
        }
      }
      Console.WriteLine("You guessed it!");
      Console.WriteLine($"You guessed {score} amount of times!");

      Console.WriteLine("Play again?\n y/n?");
      string response = Console.ReadLine();
      response = response.ToUpper();
      if(response == "Y"){
        gameActive = true;
      }
      else if (response == "N"){
        playAgain = false;
        break;
      }
      else{
        Console.WriteLine("Invalid input!");
      }

    }
    Console.WriteLine("Thanks for playing!");
  }
}
