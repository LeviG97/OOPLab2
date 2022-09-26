// See https://aka.ms/new-console-template for more information

    //read file

    string filePath = "results.txt";
    string[] fileContents = File.ReadAllLines(filePath);

    //call method to calculate points
    int totalPoints = CalculatePoints(fileContents);

    //output to screen
    Console.WriteLine($"The total points are {totalPoints}");

    //pause
    Console.ReadLine();

// end of main
static int CalculatePoints(string[] data)
{
    int[] gradeBoundries = new int[8] { 90, 80, 70, 60, 50, 40, 30, 0 };
    int[] higherPoints = new int[8] { 100, 88, 77, 66, 56, 46, 37, 0 };

    //calculate total
    int totalPoints = 0, points = 0, result = 0;

    for ( int i = 0; i < data.Length; i++)
    {
        result = Convert.ToInt32(data[i]);

        //loop through boundaries
        for ( int j = 0; j < gradeBoundries.Length; j++)
        {
            if (result >= gradeBoundries[j])
            {
                points = higherPoints[j];
                break;
            }
        }
        totalPoints += points;
    }
    return totalPoints;
    
}

