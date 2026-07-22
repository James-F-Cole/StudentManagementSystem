using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        HashTable hashTable = new HashTable();
        public Form1()
        {
            InitializeComponent();
            hashTable.LoadStudents();
            RefreshGrid();
        }

        private StudentRecord GetStudentFromForm()
        {
            return new StudentRecord(int.Parse(txtID.Text), txtFullName.Text, dtpDOB.Value, txtPhone.Text, txtEmail.Text,txtDepartment.Text, txtMajor.Text);
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtDepartment.Clear();
            txtMajor.Clear();

            dtpDOB.Value = DateTime.Today;
        }

        private void RefreshGrid()
        {
            dgvStudents.Rows.Clear();
            List<StudentRecord> students = hashTable.GetAllStudents();
            foreach (StudentRecord student in students.OrderBy(s => s.StudentId).ToList())
            {
                dgvStudents.Rows.Add(student.StudentId, student.FullName, student.DateOfBirth, student.PhoneNumber, student.EmailAddress, student.Department, student.Major);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentRecord student = GetStudentFromForm();
            if (hashTable.Add(student))
            {
                RefreshGrid();
                ClearFields();
                MessageBox.Show("Student added successfully.");
            }
            else
            {
                MessageBox.Show("Student ID already exists.");
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StudentRecord student = hashTable.Search(int.Parse(txtID.Text));
            if (student is StudentRecord)
            {
                MessageBox.Show("Student found.");
                txtID.Text = student.StudentId.ToString();
                txtFullName.Text = student.FullName;
                dtpDOB.Value = student.DateOfBirth;
                txtPhone.Text = student.PhoneNumber;
                txtEmail.Text = student.EmailAddress;
                txtDepartment.Text = student.Department;
                txtMajor.Text = student.Major;
            }
            else
            {
                ClearFields();
                MessageBox.Show("Student not found");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentRecord student = GetStudentFromForm();
            bool success = hashTable.Update(student.StudentId, student.FullName, student.DateOfBirth, student.PhoneNumber, student.EmailAddress, student.Department, student.Major);
            if (success)
            {
                RefreshGrid();
                ClearFields();
                MessageBox.Show("Update successful.");
            }
            else
            {
                ClearFields();
                MessageBox.Show("Update unsuccessful.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (hashTable.Remove(int.Parse(txtID.Text)))
            {
                RefreshGrid();
                ClearFields();
                MessageBox.Show("Student removed.");
            }
            else
            {
                ClearFields();
                MessageBox.Show("Student not found");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
