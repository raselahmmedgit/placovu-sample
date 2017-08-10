using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.BreadcrumbSample.Models
{
    public class StudentRepository
    {
        public List<Student> GetStudents
        {
            get
            {
                return Constants.StudentList;
            }
        }

        public Student GetStudent(int Id)
        {
            var Student = new Student();
            if (Constants.StudentList != null)
            {
                Student = Constants.StudentList.SingleOrDefault(item => item.Id == Id);
            }
            else
            {
                Student.IsError = true;
                Student.ErrorMessage = Constants.Messages.NotFound;
            }
            return Student;
        }

        public Student AddStudent(Student student)
        {
            if (Constants.StudentList != null)
            {
                Constants.StudentList.Add(student);
                student.IsSuccess = true;
                student.SuccessMessage = Constants.Messages.SaveSuccess;
            }
            else
            {
                student.IsError = true;
                student.ErrorMessage = Constants.Messages.UnhandelledError;
            }

            return student;
        }

        public Student EditStudent(Student student)
        {
            var editStudent = Constants.StudentList.FirstOrDefault(item => item.Id == student.Id);

            if (Constants.StudentList != null)
            {
                editStudent = student;
                student.IsSuccess = true;
                student.SuccessMessage = Constants.Messages.UpdateSuccess;
            }
            else
            {
                student.IsError = true;
                student.ErrorMessage = Constants.Messages.UnhandelledError;
            }

            return student;
        }

        public Student DeleteStudent(int Id)
        {
            Student student;
            if (Constants.StudentList != null)
            {
                student = Constants.StudentList.SingleOrDefault(item => item.Id == Id);

                if (student != null)
                {
                    Constants.StudentList.Remove(student);
                }
                else
                {
                    student = new Student();
                    student.IsError = true;
                    student.ErrorMessage = Constants.Messages.NotFound;
                }
            }
            else
            {
                student = new Student();
                student.IsError = true;
                student.ErrorMessage = Constants.Messages.NotFound;
            }

            return student;
        }
    }
}