using System;
using System.Collections.Generic;
using System.Linq;
using TeacherService.Exceptions;
using Models.Students;
using TeacherService.Repositories;

namespace TeacherServiceApp.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? 
                throw new ArgumentNullException(nameof(studentRepository));
        }

        // ========== CREATE ==========
        public void CreateStudent(Student student)
        {
            // 1. Student nullmi?
            if (student == null)
                throw new ValidationException("Student cannot be null!");

            // 2. Ism null yoki bo'shmi?
            if (string.IsNullOrWhiteSpace(student.FirstName))
                throw new ValidationException("First name cannot be empty!");

            if (string.IsNullOrWhiteSpace(student.LastName))
                throw new ValidationException("Last name cannot be empty!");

            // 3. GPA tekshirish
            if (student.GPA < 0 || student.GPA > 5)
                throw new ValidationException("GPA must be between 0 and 5!");

            // 4. ClassRoom tekshirish
            if (string.IsNullOrWhiteSpace(student.ClassRoom))
                throw new ValidationException("Class room cannot be empty!");

            student.ID = Guid.NewGuid();
            student.CreatedAt = DateTime.UtcNow;

            _studentRepository.Add(student);
        }

        // ========== READ (All) ==========
        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        // ========== READ (By ID) ==========
        public Student GetStudentById(Guid studentId)
        {
            if (studentId == Guid.Empty)
                throw new ValidationException("Invalid student ID!");

            var student = _studentRepository.GetById(studentId);

            if (student == null)
                throw new NotFoundException($"Student with ID '{studentId}' not found!");

            return student;
        }

        // ========== UPDATE ==========
        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new ValidationException("Student cannot be null!");

            if (string.IsNullOrWhiteSpace(student.FirstName))
                throw new ValidationException("First name cannot be empty!");

            if (string.IsNullOrWhiteSpace(student.LastName))
                throw new ValidationException("Last name cannot be empty!");

            if (student.GPA < 0 || student.GPA > 5)
                throw new ValidationException("GPA must be between 0 and 5!");

            var existing = _studentRepository.GetById(student.ID);

            if (existing == null)
                throw new NotFoundException($"Student with ID '{student.ID}' not found!");

            existing.FirstName = student.FirstName;
            existing.LastName = student.LastName;
            existing.Address = student.Address;
            existing.GPA = student.GPA;
            existing.ClassRoom = student.ClassRoom;
            existing.UpdatedAt = DateTime.UtcNow;

            _studentRepository.Update(existing);
        }

        // ========== DELETE ==========
        public void DeleteStudentById(Guid studentId)
        {
            if (studentId == Guid.Empty)
                throw new ValidationException("Invalid student ID!");

            var student = _studentRepository.GetById(studentId);

            if (student == null)
                throw new NotFoundException($"Student with ID '{studentId}' not found!");

            _studentRepository.Delete(studentId);
        }

        // ========== GET STUDENT FROM USER ==========
        public Student GetStudentFormUser()
        {
            Console.WriteLine("\n📝 === NEW STUDENT ===\n");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("GPA (0-5): ");
            if (!double.TryParse(Console.ReadLine(), out double gpa))
                gpa = 0;

            Console.Write("Class Room (e.g. 10A): ");
            string classRoom = Console.ReadLine();

            // Validatsiya
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ValidationException("First name cannot be empty!");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ValidationException("Last name cannot be empty!");

            if (gpa < 0 || gpa > 5)
                throw new ValidationException("GPA must be between 0 and 5!");

            return new Student
            {
                ID = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Address = address ?? "",
                GPA = gpa,
                ClassRoom = classRoom ?? "N/A",
                CreatedAt = DateTime.UtcNow
            };
        }

        // ========== SEARCH ==========
        public List<Student> GetStudentsByName(string name, int pageNumber, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Search name cannot be empty!");

            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            return _studentRepository.GetAll()
                .Where(s => s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        // ========== PRINT ==========
        public void PrintStudentInfo(Student student)
        {
            if (student == null)
                throw new NotFoundException("Student is null!");

            Console.WriteLine("═══════════════════════════════════");
            Console.WriteLine($"🆔 ID:        {student.Id}");
            Console.WriteLine($"👤 Name:      {student.FullName}");
            Console.WriteLine($"📚 Class:     {student.ClassRoom}");
            Console.WriteLine($"📊 GPA:       {student.GPA:F2}");
            Console.WriteLine($"📍 Address:   {student.Address}");
            Console.WriteLine($"📅 Created:   {student.CreatedAt:dd.MM.yyyy}");
            Console.WriteLine("═══════════════════════════════════");
        }

        // ========== COUNT BY CLASS ==========
        public void GetStudentCountByClass()
        {
            var students = _studentRepository.GetAll();

            if (!students.Any())
                throw new NotFoundException("No students found!");

            var groups = students
                .GroupBy(s => s.ClassRoom)
                .OrderBy(g => g.Key)
                .ToList();

            Console.WriteLine("\n📊 STUDENT COUNT BY CLASS:");
            Console.WriteLine("═══════════════════════════════════");

            foreach (var group in groups)
            {
                Console.WriteLine($"📚 {group.Key}: {group.Count()} students");
            }

            Console.WriteLine($"\n📌 Total: {students.Count} students");
        }

        // ========== STATISTICS ==========
        public double GetAverageGPA()
        {
            var students = _studentRepository.GetAll();
            if (!students.Any())
                throw new NotFoundException("No students to calculate average GPA!");

            return students.Average(s => s.GPA);
        }

        public int GetTotalCount()
        {
            return _studentRepository.GetAll().Count;
        }
    }
}