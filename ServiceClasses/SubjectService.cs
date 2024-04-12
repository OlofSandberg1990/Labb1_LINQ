using Labb1_LINQ.Data;

internal class SubjectService
{
    public static void CheckSubject(SchoolDbContext db)
    {
        Console.Clear();

        //Skapar en bool som kollar om Programmering1 finns det som subject
        bool containsMath = db.Subjects
            .Any(s => s.SubjectName.Contains("Programmering1"));

        Console.WriteLine("-----Ämnen som undervisas-----");
        foreach (var subject in db.Subjects)
        {
            Console.WriteLine(subject.SubjectName);
        }
        Console.WriteLine();

        if (containsMath)
        {
            //Om boolen retunerar true
            Console.WriteLine("Programmering1 fanns med i listan");
        } else
        {
            //Om boolen retunerar false
            Console.WriteLine("Programmering1 fanns inte med i listan");
        }

        Console.WriteLine("\nTryck på enter för att komma tillbaka till menyn");
        Console.ReadKey();
        Console.Clear();
    }

    public static void ChangeSubjectName(SchoolDbContext db)
    {
        Console.Clear();
        Console.WriteLine("-----Byta namn på ett ämne-----");
        Console.WriteLine("Vilket ämne vill du byta namn på?");

        int count = 1;

        //Skapar lista med de Subjects som finns.
        var subjectList = db.Subjects.ToList();


        foreach (var subjects in subjectList)
        {
            Console.WriteLine($"{count}, {subjects.SubjectName}");
            count++;
        }

        int userChoice = CheckIfInt(1, subjectList.Count - 1);

        //Sparar det valda ämnet som chosenSubject
        var chosenSubject = subjectList[userChoice - 1];

        Console.WriteLine($"Du valde '{chosenSubject.SubjectName}'.");
        Console.WriteLine("Vad vill du byta namnet till?");

        //Tar in och tillsätter det nya namnet till chosenSubject
        string newName = Console.ReadLine();

        chosenSubject.SubjectName = newName;

        //Sparar till databasen
        db.SaveChanges();

        Console.WriteLine($"Ämnet heter nu {chosenSubject.SubjectName}");

        Console.WriteLine("\nTryck på enter för att komma tillbaka till menyn");
        Console.ReadKey();
        Console.Clear();



    }

    public static int CheckIfInt(int min, int max)
    {
        bool run = true;
        int result = 0;

        while (run)
        {
            string inputString = Console.ReadLine();

            if (int.TryParse(inputString, out result) && result >= min && result <= max)  //Fastställer så det inmatade talet är en int och inom inparametrarnas intervall.
            {
                run = false;

            } else
            {
                Console.WriteLine("Felaktig inmatning, ange ett giltligt tal");
            }


        }
        return result;
    }
}
