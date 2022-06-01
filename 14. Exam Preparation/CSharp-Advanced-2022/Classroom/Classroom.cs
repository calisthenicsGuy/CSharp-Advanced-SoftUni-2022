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
            List<Student> targetStudent = GetTargetStudents(firstName, lastName);

            if (targetStudent == null)
            {
                return "Student not found";
            }

            this.Students.Remove(targetStudent[0]);
            return $"Dismissed student {firstName} {lastName}";
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

        public List<Student> GetStudent(string firstName, string lastName)
        {
            var targetStudents = GetTargetStudents(firstName, lastName);

            return targetStudents;
        }

        private List<Student> GetTargetStudents(string firstName, string lastName)
        {
            var targetStudents = new List<Student>();
            foreach (Student student in Students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    targetStudents.Add(student);
                }
            }

            return targetStudents;
        }
    }
}
