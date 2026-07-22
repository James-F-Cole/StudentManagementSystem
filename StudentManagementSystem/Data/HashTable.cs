using Microsoft.Data.SqlClient;
using StudentManagementSystem.Data;
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

        StudentRepository sr = new StudentRepository();
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

        public bool Add(StudentRecord student, bool savedToDatabase = false)
        {
            int hashValue = Hash(student.StudentId);
            if (studentRecords[hashValue] is StudentRecord)
            {
                if (!Contains(student.StudentId))
                {
                    StudentRecord currentStudent = this.studentRecords[hashValue];
                    while (currentStudent.Next is StudentRecord)
                    {
                        currentStudent = currentStudent.Next;
                    }
                    currentStudent.Next = student;
                    if (!savedToDatabase)
                    {
                        sr.InsertStudent(student.StudentId, student.FullName, student.DateOfBirth, student.PhoneNumber, student.EmailAddress, student.Department, student.Major);
                    }
                    return true;

                }
                return false;
            }
            else
            {
                studentRecords[hashValue] = student;
                if (!savedToDatabase)
                {
                    sr.InsertStudent(student.StudentId, student.FullName, student.DateOfBirth, student.PhoneNumber, student.EmailAddress, student.Department, student.Major);
                }
                return true;
            }
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
        public bool Update(int studentID, string fullName, DateTime dateOfBirth, string phoneNumber, string emailAddress, string department, string major)
        {
            StudentRecord student = Search(studentID);
            if (student == null)
            {
                return false;
            }
            student.FullName = fullName;
            student.DateOfBirth = dateOfBirth;
            student.PhoneNumber = phoneNumber;
            student.EmailAddress = emailAddress;
            student.Department = department;
            student.Major = major;

            sr.UpdateStudent(studentID, fullName, dateOfBirth, phoneNumber, emailAddress, department, major);
            return true;
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
                        sr.DeleteStudent(currentStudent.StudentId);
                        return true;
                    }
                    previousStudent.Next = currentStudent.Next;
                    sr.DeleteStudent(currentStudent.StudentId);
                    return true;
                }
                previousStudent = currentStudent;
                currentStudent = currentStudent.Next;
            }
            return false;
        }


        public List<StudentRecord> GetAllStudents()
        {
            List<StudentRecord> students = new List<StudentRecord>();
            foreach (StudentRecord record in this.studentRecords)
            {
                StudentRecord currentRecord = record;
                while (currentRecord is StudentRecord)
                {
                    students.Add(currentRecord);
                    currentRecord = currentRecord.Next;
                }
            }
            return students;
        }

        public void LoadStudents()
        {
            StudentRepository sr = new StudentRepository();
            List<StudentRecord> students = sr.GetAllStudents();
            foreach (StudentRecord student in students)
            {
                this.Add(student, true);
            }
        }

    }
}