// See https://aka.ms/new-console-template for more information
//read file
string filePath = "results.txt";

try
{

    string[] fileCotents = File.ReadAllLines(filePath);

    //calculate total
    int totalPoints = 0, points = 0, result = 0;
    foreach (string line in fileCotents)    
    {
        result = Convert.ToInt32(line);

        if (result >= 90)
            points = 100;
        else if (result >= 80)
            points = 88;
        else if (result >= 70)
            points = 77;
        else if (result >= 60)
            points = 66;
        else if (result >= 50)
            points = 56;
        else if (result >= 40)
            points = 46;
        else if (result >= 30)
            points = 37;
        else
            points = 0;

        totalPoints += points;
    }

    //append file
    File.AppendAllText(filePath, Environment.NewLine + "Total Points: " + totalPoints.ToString());

}

catch (IOException io)
{
    Console.WriteLine(io.Message);
}
