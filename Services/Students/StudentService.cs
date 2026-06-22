using System;
using System.Collections.Generic;
using System.Linq;
using Models.Students;
using TeacherService.Repositories;

namespace TeacherServiceApp.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        // ========== 1. CREATE ==========
        public void CreateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (string.IsNullOrWhiteSpace(student.FirstName) && string.IsNullOrWhiteSpace(student.LastName))
                throw new ArgumentException("Student nomi bo'sh bo'lishi mumkin emas!");

            student.ID = Guid.NewGuid();
            student.CreatedAt = DateTime.UtcNow;
            
            _studentRepository.Add(student);
            Console.WriteLine($"✅ Student {student.FullName} created!");
        }

        // ========== 2. READ (All) ==========
        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        // ========== 3. READ (By ID) ==========
        public Student GetStudentById(Guid studentId)
        {
            if (studentId == Guid.Empty)
                throw new ArgumentException("Invalid Student ID!");

            return _studentRepository.GetById(studentId);
        }

        // ========== 4. UPDATE ==========
        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            var existing = _studentRepository.GetById(student.ID);
            if (existing == null)
                throw new Exception($"Student with ID {student.ID} not found!");

            existing.FirstName = student.FirstName;
            existing.LastName = student.LastName;
            existing.Address = student.Address;
            existing.GPA = student.GPA;
            existing.ClassRoom = student.ClassRoom;
            existing.UpdatedAt = DateTime.UtcNow;

            _studentRepository.Update(existing);
            Console.WriteLine($"✅ Student {existing.FullName} updated!");
        }

        // ========== 5. DELETE ==========
        public void DeleteStudentById(Guid studentId)
        {
            if (studentId == Guid.Empty)
                throw new ArgumentException("Invalid Student ID!");

            var student = _studentRepository.GetById(studentId);
            if (student == null)
                throw new Exception($"Student with ID {studentId} not found!");

            _studentRepository.Delete(studentId);
            Console.WriteLine($"✅ Student {student.FullName} deleted!");
        }

        // ========== 6. GET STUDENT FROM USER ==========
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

            return new Student
            {
                ID = Guid.NewGuid(),
                FirstName = firstName ?? "Unknown",
                LastName = lastName ?? "Unknown",
                Address = address ?? "",
                GPA = gpa,
                ClassRoom = classRoom ?? "N/A",
                CreatedAt = DateTime.UtcNow
            };
        }

        // ========== 7. SEARCH BY NAME ==========
        public List<Student> GetStudentsByName(string name, int pageNumber, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty!");

            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            return _studentRepository.GetAll()
                .Where(s => s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        // ========== 8. PRINT STUDENT INFO ==========
        public void PrintStudentInfo(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("❌ Student is null!");
                return;
            }

            Console.WriteLine("═══════════════════════════════════");
            Console.WriteLine($"🆔 ID:        {student.ID}");
            Console.WriteLine($"👤 Name:      {student.FullName}");
            Console.WriteLine($"📚 Class:     {student.ClassRoom}");
            Console.WriteLine($"📊 GPA:       {student.GPA:F2}");
            Console.WriteLine($"📍 Address:   {student.Address}");
            Console.WriteLine($"📅 Created:   {student.CreatedAt:dd.MM.yyyy}");
            Console.WriteLine("═══════════════════════════════════");
        }

        // ========== 9. COUNT BY CLASS ==========
        public void GetStudentCountByClass()
        {
            var students = _studentRepository.GetAll();

            if (!students.Any())
            {
                Console.WriteLine("📭 No students found!");
                return;
            }

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

        // ========== 10. STATISTICS ==========
        public double GetAverageGPA()
        {
            var students = _studentRepository.GetAll();
            if (!students.Any()) return 0;
            return students.Average(s => s.GPA);
        }

        public int GetTotalCount()
        {
            return _studentRepository.GetAll().Count;
        }
    }
}