using System;

namespace Task6
{
    public class PartTimeStudent:Student
    {
        public int AvgGrade { get; set; }
        public string CurrentFaculty { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine(PreferredFaculty + " " + CurrentFaculty+ " "  + Year+" "+AvgGrade);
        }

        public PartTimeStudent(string preferredFaculty, string currentFaculty, int year) : base(preferredFaculty, currentFaculty, year)
        {
        }

        public PartTimeStudent()
        {
            
        }
        public void test(){}
    }
}