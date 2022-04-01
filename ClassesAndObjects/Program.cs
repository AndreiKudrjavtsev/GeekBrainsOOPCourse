namespace OOPInCsharp.Lesson2.ClassesAndObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var students = new[]
            {
                new Student(),
                new Student(),
            };


            var teachers = new[]
            {
                new Teacher(),
                new Teacher(),
            };

            Person[] people = new Person[]
            {
                new Student(),
                new Student(),
                new Teacher(),
                new Teacher(),
            };

            //var studentsClasses = Student.Calculate(students);
            //var teachersClasses = Teacher.Calculate(teachers);
            //var sum = studentsClasses + teachersClasses;

            var sum = Person.Calculate(people);

            /////
            var student1 = new Student(1, "name");
        }

        // Есть универ
        // Есть студенты, есть преподаватели
        // у студентов есть кол-во посещенных пар
        // у преподов кол-во проведенных пар
        // Вывести: 
        // id   name    кол-во пар   
        // под этим общее кол-во всех людей 
        public class Person
        {
            public Person()
            {
            }

            public Person(string name) : this(default(int), name)
            {
                Name = name;
            }

            public Person(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }

            public static int Calculate(Person[] people)
            {
                var sum = 0;
                // calculations 
                var person = people[0];

                //var student = (Teacher)person;
                //sum = sum + student.ClassesAttended;

                if (person is Student)
                {
                    sum = sum + ((Student)person).ClassesAttended;
                }
                else if (person is Teacher)
                {
                    sum = sum + (person as Teacher).ClassesGiven;
                }

                return sum;
            }
        }

        public class Student : Person
        {
            public Student() { }

            public Student(int id, string name) : base(id, name)
            {

            }

            public int ClassesAttended { get; set; }

            public static int Calculate(Student[] students)
            {
                // calculations
                return 0;
            }
        }

        public class Teacher : Person
        {
            public int ClassesGiven { get; set; }

            public static int Calculate(Teacher[] teachers)
            {
                // calculations
                return 1;
            }
        }

        public class Foo { }
    }
}