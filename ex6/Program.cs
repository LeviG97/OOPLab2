using ex6;
Console.Write("Enter student name >> ");
string name = Console.ReadLine();
Console.Write("Enter student number >> ");
string number = Console.ReadLine();
CAO myStudent;
myStudent = new CAO(name, number);
myStudent.GetSubjectInfo();

Console.ReadLine();

