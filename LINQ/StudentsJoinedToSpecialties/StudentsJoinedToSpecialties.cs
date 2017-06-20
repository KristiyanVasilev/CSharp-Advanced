namespace StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var specialties = new List<StudentSpecialties>();
            var students = new List<Student>();
            while (input != "Students:")
            {
                var tokens = input.Split();
                specialties.Add(new StudentSpecialties(tokens[0] + " " + tokens[1], int.Parse(tokens[2])));
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "END")
            {
                var tokens = input.Split();
                students.Add(new Student(tokens[1] + " " + tokens[2], int.Parse(tokens[0])));
                input = Console.ReadLine();
            }
            specialties
            .Join(students, pr => pr.FacNumber, st => st.FacNumber, (sp, st) => new
            {
                Name = st.StudentName,
                FacNum = sp.FacNumber,
                Spec = sp.SpecialityName
            })
            .OrderBy(res => res.Name)
            .ToList()
            .ForEach(res => Console.WriteLine($"{res.Name} {res.FacNum} {res.Spec}"));
        }
    }
    public class StudentSpecialties
    {
        public string SpecialityName { get; set; }
        public int FacNumber { get; set; }

        public StudentSpecialties(string name, int num)
        {
            this.SpecialityName = name;
            this.FacNumber = num;
        }
    }
    public class Student
    {
        public string StudentName { get; set; }
        public int FacNumber { get; set; }

        public Student(string name, int num)
        {
            this.StudentName = name;
            this.FacNumber = num;
        }
    }
}
