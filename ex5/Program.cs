// See https://aka.ms/new-console-template for more information
//Get student info
Console.Write("Enter your name >> ");
string name = Console.ReadLine();

Console.Write("Enter your name >> ");
string studentNumber = Console.ReadLine();

//Get subject info
string[] subjects = new string[7];
string[] levels = new string[7];
string[] results = new string[7];
int[] points = new int[7];

for (int i = 0; i < 7; i++)
{
    Console.Write($"Enter subject name >> {i+1}");
    subjects[i] = Console.ReadLine();

    Console.Write($"Enter subject level for  {subjects[i]} >> ");
    levels[i] = Console.ReadLine();

    Console.Write($"Enter subject result for {subjects[i]}");
    results[i] = Console.ReadLine();
}

//Get results
int totalPoints = CalculatePoints(results, levels, points);

//Display Results
DisplayResults(name, studentNumber, subjects, results, levels, points, totalPoints);

//Write to file
WriteDetailsToFile(name, studentNumber, subjects, results, levels, points, totalPoints);

Console.ReadLine();


statid void DisplayResults(string[] name, string[] studentNum, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints)
{
    Console.WriteLine($"Name: {name}");
    Console.WriteLine($"Student Number: {studentNum}");

    for (int i = 0; i < results.Length; i++)
    {
        Console.WriteLine($"{subjects[i],10}");
    } 
}

static int CalculatePoints(string[] data, string[] levels, int[] studentPoints)
{
    int[] gradeBoundries = new int[] { 90, 80, 70, 60, 50, 40, 30, 0 };
    int[] higherPoints = new int[] { 100, 88, 77, 66, 56, 46, 37, 0 };
    int[] ordinaryPoints = new int[] { 56, 46, 37, 28, 20, 12, 0, 0 };
    //calculate total
    int totalPoints = 0, points = 0;

    for (int i = 0; i < data.Length; i++)
    {
        int result = Convert.ToInt32(data[i]);

        //loop through boundaries
        for (int j = 0; j < gradeBoundries.Length; j++)
        {
            if (result >= gradeBoundries[j])
            {
                //check if higher or ordinary
                points = levels[i].ToLower().Equals("h") ? higherPoints[j] : ordinaryPoints[j];
                break;
            }
        }
        studentPoints[i] += points;
    }

    //Only use the top 6 for points calculation
    Array.Sort(studentPoints);
    Array.Reverse(studentPoints);

    for (int i = 0; i < 6; i++)
    {
        totalPoints += studentPoints[i];
    }
    
    return totalPoints;

}

