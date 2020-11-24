using System;

namespace Task6
{
    public interface Abitur
    {
        string PreferredFaculty{ get; set; }

        void Enroll(String faculty);
        void ChangePreferredFaculty(String faculty);
    }
}