using System;

class Program
{
    static void Main(string[] args)
    {
        Job pizzaHut = new Job();
        pizzaHut._company = "Pizza Hut";
        pizzaHut._jobTitle = "Cook";
        pizzaHut._startYear = 2024;
        pizzaHut._endYear = 2025;

        Job apple = new Job();
        apple._company = "Apple";
        apple._jobTitle = "Backend Engineer";
        apple._startYear = 2024;
        apple._endYear = 2025;


        Resume myResume = new Resume();
        myResume._name = "Ezra";
        myResume._jobs.Add(apple);
        myResume._jobs.Add(pizzaHut);


        myResume.DisplayResume();
    }
}
