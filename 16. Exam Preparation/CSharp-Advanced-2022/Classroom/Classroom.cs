using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classroom_Task
{
    internal class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Students = new List<Student>();
            this.Capacity = capacity;
        }

        public List<Student> Students 
        { 
            get => this.students; 
            set => this.students = value; 
        }
        public int Count { get; set; }
        public int Capacity { get; set; }


        public string RegisterStudent(Student student)
        {
            if (this.Count + 1 > this.Capacity)
            {
                return "No seats in the classroom";
            }

            this.Students.Add(student);
            this.Count++;
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            foreach (Student student in this.Students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    this.Students.Remove(student);
                    return $"Dismissed student {firstName} {lastName}";
                }
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> targetStudents = this.Students.Where(s => s.Subject == subject).ToList();

            if (targetStudents.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            return StudentThatLearningTargetSubject(targetStudents, subject);
        }

        private string StudentThatLearningTargetSubject(List<Student> targetStudents, string subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (Student student in targetStudents)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            var targetStudent = GetTargetStudent(firstName, lastName);

            return targetStudent;
        }

        private Student GetTargetStudent(string firstName, string lastName)
        {
            var targetStudent = new Student();
            foreach (Student student in this.Students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    targetStudent = student;
                }
            }

            return targetStudent;
        }
    }
}
