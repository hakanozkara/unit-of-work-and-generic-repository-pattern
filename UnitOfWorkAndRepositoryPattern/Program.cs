using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkAndRepositoryPattern.DbContext;
using UnitOfWorkAndRepositoryPattern.Entities;
using UnitOfWorkAndRepositoryPattern.Repositories;

namespace UnitOfWorkAndRepositoryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUnitOfWork _unitOfWork = new UnitOfWork();
            School newSchool = new School()
            {
                Name = "Ankara Lisesi"
            };


            _unitOfWork.School.Insert(newSchool);
            _unitOfWork.Save();

            List<Student> newStudents = new List<Student>();

            Student firstStudent = new Student()
            {
                FirstName = "Hakan",
                LastName = "Özkara",
                No = 1,
                SchoolId = 1
            };

            Student secondStudent = new Student()
            {
                FirstName = "Mehmet",
                LastName = "Özkara",
                No = 2,
                SchoolId = 1
            };

            newStudents.Add(firstStudent);
            newStudents.Add(secondStudent);

            _unitOfWork.Student.Insert(newStudents);
            _unitOfWork.Save();


            var updateStudent = _unitOfWork.Student.GetBy(filter: p => p.FirstName == "Hakan").FirstOrDefault();
            updateStudent.No = 3;
            _unitOfWork.Student.Update(updateStudent);
            _unitOfWork.Save();

            var students = _unitOfWork.Student.GetAll();
            foreach (var student in students)
            {
                Console.WriteLine($"Adı: {student.FirstName}\nSoyadı: {student.LastName}\nNo: {student.No}\nOkulu: {student.School.Name}\n\n\n");
            }

            Console.Read();

        }
    }
}
