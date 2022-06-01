using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom_Task
{
    internal class Student
    {
        private string firstName;
        private string lastName;
        private string subject;

        public Student()
        {

        }

        public Student(string firstName, string lastName, string subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }


        public string FirstName 
        {
            get => this.firstName;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or white space");
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or white space");
                }

                this.lastName = value;
            }
        }
        public string Subject 
        {
            get => this.subject;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Subject cannot be null or white space");
                }

                this.subject = value;
            }
        }


        public override string ToString()
        {
            return
                $"Student: First Name = {this.FirstName}, " +
                $"Last Name = {this.LastName}, " +
                $"Subject = {this.Subject}";
        }
    }
}
