using Microsoft.Data.SqlClient;
using StudentManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StudentRepository sr = new StudentRepository();
            List<StudentRecord> students = sr.GetAllStudents();
            HashTable hashTable = new HashTable();
            foreach (StudentRecord student in students)
            {
                hashTable.Add(student, true);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
