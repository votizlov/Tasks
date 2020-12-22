namespace Task6
{
    public abstract class Student:Abitur
    {
        public Student(string preferredFaculty,string currentFaculty,int year)
        {
            Year = year;
            PreferredFaculty = preferredFaculty;
            CurrentFaculty = currentFaculty;
        }
        public string PreferredFaculty { get; set; }

        public string CurrentFaculty { get; set; }
        
        public int Year { get; set; }

        public void Enroll(string faculty)
        {
            CurrentFaculty = faculty;
        }

        public void ChangePreferredFaculty(string faculty)
        {
            PreferredFaculty = faculty;
        }

        public void ChangeYear(int year)
        {
            Year = year;
        }

        public Student()
        {
            
        }
    }
}