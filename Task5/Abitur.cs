using System;

namespace Task5
{
    public interface Abitur
    {
        string PreferredFaculty{ get; set; }

        void Enroll(String faculty);
        void ChangePreferredDaculty(String faculty);
    }
}