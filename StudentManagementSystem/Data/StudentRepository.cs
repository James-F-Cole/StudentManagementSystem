using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace StudentManagementSystem.Data
{
    internal class StudentRepository
    {
        Database db = new Database();
        public bool InsertStudent(int StudentID, string FullName, DateTime DateOfBirth, string PhoneNumber, string EmailAddress, string Department, string Major)
        {
            string query = "INSERT INTO Students(StudentID, FullName, DateOfBirth, PhoneNumber, EmailAddress, Department, Major) VALUES (@StudentID, @FullName, @DateOfBirth, @PhoneNumber, @EmailAddress, @Department, @Major)";
            using (Microsoft.Data.SqlClient.SqlConnection conn = db.GetConnection())
            {
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);
                    cmd.Parameters.AddWithValue("@FullName", FullName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress);
                    cmd.Parameters.AddWithValue("@Department", Department);
                    cmd.Parameters.AddWithValue("@Major", Major);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"[CREATE] Successful. Rows inserted: {rowsAffected}.");
                    return true;
                }
            }
        }

        public bool UpdateStudent(int StudentID, string FullName, DateTime DateOfBirth, string PhoneNumber, string EmailAddress, string Department, string Major)
        {
            string query = "UPDATE Students SET FullName = @FullName, DateOfBirth = @DateOfBirth, PhoneNumber = @PhoneNumber, EmailAddress = @EmailAddress, Department = @Department, Major = @Major WHERE StudentID = @StudentID";
            using (Microsoft.Data.SqlClient.SqlConnection conn = db.GetConnection())
            {
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);
                    cmd.Parameters.AddWithValue("@FullName", FullName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress);
                    cmd.Parameters.AddWithValue("@Department", Department);
                    cmd.Parameters.AddWithValue("@Major", Major);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"[UPDATE] Successful. Rows updated: {rowsAffected}.");
                    return true;

                }
            }
        }

        public bool DeleteStudent(int StudentID)
        {
            string query = "DELETE FROM Students WHERE StudentID = @StudentID";
            using (Microsoft.Data.SqlClient.SqlConnection conn = db.GetConnection())
            {
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"[DELETE] Successful. Rows deleted: {rowsAffected}.");
                    return true;

                }
            }
        }

        public List<StudentRecord> GetAllStudents()
        {
            List<StudentRecord> students = new List<StudentRecord>();
            string query = "SELECT StudentID, FullName, DateOfBirth, PhoneNumber, EmailAddress, Department, Major FROM Students";
            using (Microsoft.Data.SqlClient.SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                {
                    using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int StudentID = reader.GetInt32(0);
                            string FullName = reader.GetString(1);
                            DateTime DateOfBirth = reader.GetDateTime(2);
                            string PhoneNumber = reader.GetString(3);
                            string EmailAddress = reader.GetString(4);
                            string Department = reader.GetString(5);
                            string Major = reader.GetString(6);
                            StudentRecord student = new StudentRecord(StudentID, FullName, DateOfBirth, PhoneNumber, EmailAddress, Department, Major);
                            students.Add(student);

                        }
                    }


                }
            }
            return students;
        }
    }
}
