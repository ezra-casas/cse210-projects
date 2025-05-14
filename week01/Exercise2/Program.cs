using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello World! This is the Exercise2 Project.");

    Console.WriteLine("What's your grade percentage?");
    float score = float.Parse(Console.ReadLine());
    string grade = "";

    if (score >= 90){
      grade = "A";
    }
    if(score >= 80 && score < 90){
      grade = "B";
    }
    if(score >= 70 && score < 80){
      grade = "C";
    }
    if(score >= 60 && score < 70){
      grade = "D";
    }
    if(score < 60){
      grade = "F";
    }

    if (score >= 70){
      Console.WriteLine($"You passed the class with a {grade}");
    }
  }
}
