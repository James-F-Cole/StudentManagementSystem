using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class StudentRecord
    {
        private int _studentId;
        public int StudentId { get { return _studentId; } set { _studentId = value; } }

        private string _fullName;
        public string FullName { get { return _fullName; } set { _fullName = value; } }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }

        private string _phoneNumber;
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        private string _emailAddress;
        public string EmailAddress { get { return _emailAddress; } set { _emailAddress = value; } }

        private string _department;
        public string Department { get { return _department; } set { _department = value; } }
        
        private string _major;
        public string Major { get { return _major; } set { _major = value; } }

        private StudentRecord _next;
        public StudentRecord Next { get { return _next; } set { _next = value; } }

        public StudentRecord(int studentID, string fullName, DateTime dateOfBirth, string phoneNumber, string emailAddress, string department, string major)
        {

            this.StudentId = studentID;
            this.FullName = fullName;
            this.DateOfBirth = dateOfBirth;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.Department = department;
            this.Major = major;
            this.Next = null;

        }

        public string View()
        {
            return $"ID: {this.StudentId}  |  Full Name: {this.FullName}  |  Date Of Birth: {this.DateOfBirth}  |  Phone Number: {this.PhoneNumber}  |  Email Address: {this.EmailAddress}  |  Major: {this.Major}";
        }
    }
}
