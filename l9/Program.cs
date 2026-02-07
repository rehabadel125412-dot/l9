using System;
using System.Collections.Generic;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public void Display()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}");
        if (Courses.Count > 0)
        {
            Console.Write("Courses: ");
            foreach (var c in Courses)
                Console.Write(c.Name + " ");
            Console.WriteLine();
        }
    }
}

class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Instructor
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class StudentManagementSystem
{
    List<Student> students = new List<Student>();
    List<Course> courses = new List<Course>();
    List<Instructor> instructors = new List<Instructor>();

    public void AddStudent()
    {
        try
        {
            Student s = new Student();
            Console.Write("Enter Student ID: ");
            s.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter Age: ");
            s.Age = int.Parse(Console.ReadLine());
            students.Add(s);
            Console.WriteLine("Student Added");
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void ViewStudents()
    {
        foreach (var s in students)
            s.Display();
    }

    public void SearchStudent()
    {
        try
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            var student = students.Find(s => s.Id == id);
            if (student != null)
                student.Display();
            else
                Console.WriteLine("Student Not Found");
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void UpdateStudent()
    {
        try
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Enter New Name: ");
                student.Name = Console.ReadLine();
                Console.Write("Enter New Age: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Student Updated");
            }
            else
                Console.WriteLine("Student Not Found");
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void DeleteStudent()
    {
        try
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            students.RemoveAll(s => s.Id == id);
            Console.WriteLine("Student Deleted");
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void AddCourse()
    {
        try
        {
            Course c = new Course();
            Console.Write("Enter Course ID: ");
            c.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Course Name: ");
            c.Name = Console.ReadLine();
            courses.Add(c);
            Console.WriteLine("Course Added");
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void AddInstructor()
    {
        try
        {
            Instructor i = new Instructor();
            Console.Write("Enter Instructor ID: ");
            i.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Instructor Name: ");
            i.Name = Console.ReadLine();
            instructors.Add(i);
            Console.WriteLine("Instructor Added");
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void EnrollStudent()
    {
        try
        {
            Console.Write("Enter Student ID: ");
            int sid = int.Parse(Console.ReadLine());
            Console.Write("Enter Course ID: ");
            int cid = int.Parse(Console.ReadLine());
            var student = students.Find(s => s.Id == sid);
            var course = courses.Find(c => c.Id == cid);
            if (student != null && course != null)
            {
                student.Courses.Add(course);
                Console.WriteLine("Student Enrolled");
            }
            else
                Console.WriteLine("Student or Course Not Found");
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void ViewCourses()
    {
        foreach (var c in courses)
            Console.WriteLine($"{c.Id} - {c.Name}");
    }

    public void ViewInstructors()
    {
        foreach (var i in instructors)
            Console.WriteLine($"{i.Id} - {i.Name}");
    }
}

class Program
{
    static void Main()
    {
        StudentManagementSystem sms = new StudentManagementSystem();
        int choice = -1;

        while (choice != 0)
        {
            try
            {
                Console.WriteLine("\n1.Add Student");
                Console.WriteLine("2.View Students");
                Console.WriteLine("3.Search Student");
                Console.WriteLine("4.Update Student");
                Console.WriteLine("5.Delete Student");
                Console.WriteLine("6.Add Course");
                Console.WriteLine("7.Add Instructor");
                Console.WriteLine("8.Enroll Student in Course");
                Console.WriteLine("9.View Courses");
                Console.WriteLine("10.View Instructors");
                Console.WriteLine("0.Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: sms.AddStudent(); break;
                    case 2: sms.ViewStudents(); break;
                    case 3: sms.SearchStudent(); break;
                    case 4: sms.UpdateStudent(); break;
                    case 5: sms.DeleteStudent(); break;
                    case 6: sms.AddCourse(); break;
                    case 7: sms.AddInstructor(); break;
                    case 8: sms.EnrollStudent(); break;
                    case 9: sms.ViewCourses(); break;
                    case 10: sms.ViewInstructors(); break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid Choice");
            }
        }
    }
}