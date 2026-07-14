using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace StudentManagementSystem
{
    internal class HashTable
    {

        private StudentRecord[] studentRecords = new StudentRecord[10];

        public int Hash(int key)
        {
            int _arrayLength = studentRecords.Length;
            int hashOutput = key % _arrayLength;
            return hashOutput;
        }

        public bool Contains(int key)
        {
            int hashValue = Hash(key);
            StudentRecord previousStudent = null;
            StudentRecord currentStudent = this.studentRecords[hashValue];
            while (currentStudent != null)
            {
                if (currentStudent.StudentId == key)
                {
                    return true;
                }
                previousStudent = currentStudent;
                currentStudent = currentStudent.Next;
            }
            return false;

        }

        public bool Add(StudentRecord value)
        {
            int hashValue = Hash(value.StudentId);
            if (studentRecords[hashValue] is StudentRecord)
            {
                if (!Contains(value.StudentId))
                {
                    StudentRecord currentStudent = this.studentRecords[hashValue];
                    while (currentStudent.Next is StudentRecord)
                    {
                        currentStudent = currentStudent.Next;
                    }
                    currentStudent.Next = value;
                    return true;
                }
                return false;
            }
            else
            {
                studentRecords[hashValue] = value;
                return true;
            }
        }

        public bool Remove(int key)
        {
            int hashValue = Hash(key);
            StudentRecord previousStudent = null;
            StudentRecord currentStudent = this.studentRecords[hashValue];
            while (currentStudent is StudentRecord)
            {

                if (currentStudent.StudentId == key)
                {
                    if (previousStudent == null)
                    {
                        this.studentRecords[hashValue] = currentStudent.Next;
                        return true;
                    }
                    previousStudent.Next = currentStudent.Next;
                    return true;
                }
                previousStudent = currentStudent;
                currentStudent = currentStudent.Next;
            }
            return false;
        }

        public StudentRecord Search(int key)
        {
            int hashValue = Hash(key);
            StudentRecord previousStudent = null;
            StudentRecord currentStudent = this.studentRecords[hashValue];
            while (currentStudent is StudentRecord)
            {

                if (currentStudent.StudentId == key)
                {
                    return currentStudent;
                }
                previousStudent = currentStudent;
                currentStudent = currentStudent.Next;
            }
            return null;
        }

        public bool Update(StudentRecord student, string fullName, DateTime dateOfBirth, string phoneNumber, string emailAddress, string major)
        {
            student.FullName = fullName;
            student.DateOfBirth = dateOfBirth;
            student.PhoneNumber = phoneNumber;
            student.EmailAddress = emailAddress;
            student.Major = major;
            return true;
        }

        public string ViewAll()
        {
            string output = $"";
            foreach (var record in this.studentRecords)
            {
                if (record is StudentRecord)
                {
                    output += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
                    StudentRecord currentStudent = record;
                    while (currentStudent is StudentRecord)
                    {
                        output += currentStudent.View() + "\n";
                        currentStudent = currentStudent.Next;
                    }
                }
            }
            return output;
        }
    }
}