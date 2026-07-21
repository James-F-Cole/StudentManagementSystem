# Student Management System

A simple **Student Management System** built with **C# Windows Forms** that demonstrates the implementation of a **Hash Table** using **Separate Chaining (Linked Lists)** as the collision resolution technique.

The project was developed as a Data Structures assignment to illustrate how hash tables can efficiently store, retrieve, update, and delete student records.

---

# Features

The application supports the following operations:

* Add a new student record
* Search for a student by Student ID
* Update an existing student record
* Delete a student record
* Display all stored student records
* Prevent duplicate Student IDs from being inserted

---

# Student Record Structure

Each student record contains the following information:

| Field         | Data Type |
| ------------- | --------- |
| Student ID    | Integer   |
| Full Name     | String    |
| Date of Birth | DateTime  |
| Phone Number  | String    |
| Email Address | String    |
| Department    | String    |
| Major         | String    |

Each `StudentRecord` also contains a `Next` reference, allowing multiple records to be linked together when hash collisions occur.

---

# Data Structure

## Hash Table

The application stores student records inside a hash table implemented as:

* Fixed-size array
* Array size: **10 buckets**
* Collision handling using **Separate Chaining**
* Each bucket stores the head of a singly linked list of `StudentRecord` objects

```
Hash Table

Bucket 0 → Student → Student → null

Bucket 1 → null

Bucket 2 → Student → null

Bucket 3 → Student → Student → Student → null

...
```

---

# Hash Function

The hash function computes the bucket index using the student's ID.

```text
Hash(key) = key % 10
```

For example:

| Student ID | Bucket |
| ---------- | ------ |
| 101        | 1      |
| 212        | 2      |
| 333        | 3      |
| 441        | 1      |

Student IDs **101** and **441** both hash to bucket **1**, so they are stored in the same linked list.

---

# Collision Resolution

The project resolves collisions using **Separate Chaining**.

When two students produce the same hash value:

1. The first student is stored directly in the bucket.
2. Additional students are appended to the linked list.
3. Searching traverses the linked list until the matching Student ID is found.

---

# Core Classes

## StudentRecord

Represents a single student node.

### Properties

* StudentId
* FullName
* DateOfBirth
* PhoneNumber
* EmailAddress
* Department
* Major
* Next

### Methods

#### View()

Returns a formatted string representation of the student record.

---

## HashTable

Manages all student records using hashing.

### Internal Storage

```text
StudentRecord[] studentRecords = new StudentRecord[10];
```

### Methods

#### Hash(int key)

Computes the hash value for a Student ID.

Returns:

* Bucket index

---

#### Add(StudentRecord value)

Adds a new student record.

Behavior:

* Computes hash value
* Checks for duplicate Student ID
* Inserts into the appropriate bucket
* Appends to the linked list if a collision occurs

Returns:

* `true` if insertion succeeds
* `false` if the Student ID already exists

---

#### Contains(int key)

Checks whether a Student ID already exists.

Returns:

* `true` if found
* `false` otherwise

---

#### Search(int key)

Searches for a student by Student ID.

Returns:

* Matching `StudentRecord`
* `null` if not found

---

#### Update(...)

Updates an existing student's information.

Fields that can be updated:

* Full Name
* Date of Birth
* Phone Number
* Email Address
* Department
* Major

Returns:

* `true`

---

#### Remove(int key)

Deletes a student record.

Handles removal from:

* Beginning of a linked list
* Middle of a linked list
* End of a linked list

Returns:

* `true` if removed
* `false` if not found

---

#### ViewAll()

Traverses every bucket and linked list, returning a formatted string containing all stored student records.

---

# Algorithm Summary

## Insert

1. Compute hash value.
2. Check whether the Student ID already exists.
3. If the bucket is empty, insert directly.
4. Otherwise, append to the linked list.

---

## Search

1. Compute hash value.
2. Traverse the linked list in the bucket.
3. Return the matching student if found.

---

## Delete

1. Compute hash value.
2. Traverse the linked list.
3. Relink nodes if necessary.
4. Remove the matching student.

---

## Update

1. Search for the student.
2. Modify the student's properties.
3. Return success.

---

# Time Complexity

| Operation | Average Case | Worst Case |
| --------- | ------------ | ---------- |
| Insert    | O(1)         | O(n)       |
| Search    | O(1)         | O(n)       |
| Delete    | O(1)         | O(n)       |
| Update    | O(1)         | O(n)       |
| View All  | O(n)         | O(n)       |

Where **n** is the number of student records stored in the table.

---

# Current Limitations

* Fixed hash table size of 10 buckets.
* No automatic resizing or rehashing.
* Data is stored only in memory.
* Records are lost when the application closes.
* Student IDs are the only search key.

---

# Technologies Used

* C#
* .NET Framework
* Windows Forms
* Hash Tables
* Separate Chaining (Linked Lists)
* Object-Oriented Programming

---

# Future Improvements

Possible enhancements include:

* Dynamic resizing and rehashing
* Persistent storage using files or a database
* Search by name, department, or major
* Record sorting
* Export to CSV or Excel
* Input validation
* Improved user interface
* Statistical analysis of bucket distribution

---

# Authors
- Edwin Harris
- Havious M. Wah
- James F. Cole

Developed as a Data Structures project demonstrating the implementation of a hash table using separate chaining for efficient student record management.
