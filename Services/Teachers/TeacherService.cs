using System;
using System.Collections.Generic;
using System.Linq;
using TeacherService.Exceptions;       
using Models.Teachers;      
using TeacherService.Repositories;        

namespace TeacherServiceApp.Services.Teachers
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        // ✅ KONSTRUKTOR
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository ?? 
                throw new ArgumentNullException(nameof(teacherRepository));
        }

        // ========== CREATE ==========
        public void CreateTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ValidationException("Teacher cannot be null!");

            if (string.IsNullOrWhiteSpace(teacher.FirstName))
                throw new ValidationException("First name cannot be empty!");

            if (string.IsNullOrWhiteSpace(teacher.LastName))
                throw new ValidationException("Last name cannot be empty!");

            if (string.IsNullOrWhiteSpace(teacher.Subject))
                throw new ValidationException("Subject cannot be empty!");

            if (teacher.Salary < 0)
                throw new ValidationException("Salary cannot be negative!");

            teacher.Id = Guid.NewGuid();
            teacher.CreatedAt = DateTime.UtcNow;

            _teacherRepository.Add(teacher);
        }

        // ========== READ (All) ==========
        public List<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        // ========== READ (By ID) ==========
        public Teacher GetTeacherById(Guid teacherId)
        {
            if (teacherId == Guid.Empty)
                throw new ValidationException("Invalid teacher ID!");

            var teacher = _teacherRepository.GetById(teacherId);

            if (teacher == null)
                throw new NotFoundException($"Teacher with ID '{teacherId}' not found!");

            return teacher;
        }

        // ========== UPDATE ==========
        public void UpdateTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ValidationException("Teacher cannot be null!");

            if (string.IsNullOrWhiteSpace(teacher.FirstName))
                throw new ValidationException("First name cannot be empty!");

            if (string.IsNullOrWhiteSpace(teacher.LastName))
                throw new ValidationException("Last name cannot be empty!");

            if (string.IsNullOrWhiteSpace(teacher.Subject))
                throw new ValidationException("Subject cannot be empty!");

            if (teacher.Salary < 0)
                throw new ValidationException("Salary cannot be negative!");

            var existing = _teacherRepository.GetById(teacher.Id);

            if (existing == null)
                throw new NotFoundException($"Teacher with ID '{teacher.Id}' not found!");

            existing.FirstName = teacher.FirstName;
            existing.LastName = teacher.LastName;
            existing.Subject = teacher.Subject;
            existing.Salary = teacher.Salary;
            existing.UpdatedAt = DateTime.UtcNow;

            _teacherRepository.Update(existing);
        }

        // ========== DELETE ==========
        public void DeleteTeacherById(Guid teacherId)
        {
            if (teacherId == Guid.Empty)
                throw new ValidationException("Invalid teacher ID!");

            var teacher = _teacherRepository.GetById(teacherId);

            if (teacher == null)
                throw new NotFoundException($"Teacher with ID '{teacherId}' not found!");

            _teacherRepository.Delete(teacherId);
        }

        // ========== GET TEACHER FROM USER ==========
        public Teacher GetTeachersFromUser()
        {
            Console.WriteLine("\n📝 === NEW TEACHER ===\n");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Subject: ");
            string subject = Console.ReadLine();

            Console.Write("Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                salary = 0;
            }

            // ✅ Validatsiya (Exception throw)
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ValidationException("First name cannot be empty!");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ValidationException("Last name cannot be empty!");

            if (string.IsNullOrWhiteSpace(subject))
                throw new ValidationException("Subject cannot be empty!");

            if (salary < 0)
                throw new ValidationException("Salary cannot be negative!");

            return new Teacher
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Subject = subject,
                Salary = salary,
                CreatedAt = DateTime.UtcNow
            };
        }

        // ========== PRINT TEACHER INFO ==========
        public void TeacherPrintInfo(Teacher teacher)
        {
            if (teacher == null)
                throw new NotFoundException("Teacher is null!");

            Console.WriteLine("═══════════════════════════════════");
            Console.WriteLine($"🆔 ID:        {teacher.Id}");
            Console.WriteLine($"👤 Name:      {teacher.FullName}");
            Console.WriteLine($"📚 Subject:   {teacher.Subject}");
            Console.WriteLine($"💰 Salary:    {teacher.Salary:C}");
            Console.WriteLine($"📅 Created:   {teacher.CreatedAt:dd.MM.yyyy}");
            Console.WriteLine("═══════════════════════════════════");
        }
    }
}