using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public int ID { get; set; }
    public List<int> Grades { get; set; }

    public Student(string name, int id)
    {
        Name = name;
        ID = id;
        Grades = new List<int>();
    }

    // Method to calculate average
    public double CalculateAverage()
    {
        if (Grades.Count == 0) return 0;

        int sum = 0;
        foreach (int grade in Grades)
        {
            sum += grade;
        }
        return (double)sum / Grades.Count;
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nStudent Grade Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. Calculate Average Grade");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AddGrade();
                    break;
                case "3":
                    CalculateAverage();
                    break;
                case "4":
                    DisplayStudents();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Exiting... Bye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name. Student not added.");
            return;
        }

        Console.Write("Enter student ID: ");
        string? idInput = Console.ReadLine();
        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID. Student not added.");
            return;
        }

        students.Add(new Student(name, id));
        Console.WriteLine("Student added successfully!");
    }

    static void AddGrade()
    {
        Console.Write("Enter student ID to add grade: ");
        string? idInput = Console.ReadLine();
        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Student? student = students.Find(s => s.ID == id);

        if (student != null)
        {
            Console.Write("Enter grade to add: ");
            string? gradeInput = Console.ReadLine();
            if (!int.TryParse(gradeInput, out int grade))
            {
                Console.WriteLine("Invalid grade.");
                return;
            }

            student.Grades.Add(grade);
            Console.WriteLine("Grade added successfully!");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void CalculateAverage()
    {
        Console.Write("Enter student ID to calculate average: ");
        string? idInput = Console.ReadLine();
        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Student? student = students.Find(s => s.ID == id);

        if (student != null)
        {
            double average = student.CalculateAverage();
            Console.WriteLine($"Average grade for {student.Name} is {average:F2}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        foreach (Student student in students)
        {
            Console.WriteLine($"\nStudent Name: {student.Name}");
            Console.WriteLine($"Student ID: {student.ID}");
            Console.WriteLine("Grades: " + (student.Grades.Count > 0 ? string.Join(", ", student.Grades) : "No grades added"));
        }
    }
}
