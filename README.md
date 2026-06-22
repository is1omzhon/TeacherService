# 🏫 School Management System

## 📌 Loyiha haqida

Bu loyiha **Student** va **Teacher** ma'lumotlarini boshqarish uchun yozilgan **konsol dasturi**.

Loyiha **OOP tamoyillari**, **Repository pattern**, **Exception Handling** va **JSON faylga ma'lumotlarni saqlash** texnologiyalarini o'z ichiga oladi.

---

## 🧱 Texnologiyalar

| Texnologiya | Maqsad |
|-------------|--------|
| C# .NET 6.0 | Dasturlash tili |
| Newtonsoft.Json | JSON fayllarga ma'lumotlarni saqlash/o'qish |
| Repository Pattern | Ma'lumotlar bilan ishlashni ajratish |
| Exception Handling | Xatoliklarni boshqarish |
| LINQ | Ma'lumotlarni qidirish, filter, saralash |
| Console Application | Foydalanuvchi interfeysi |

---

## 📁 Loyiha tuzilishi
#### TeacherService/
#### │
#### ├── 📁 Models/
#### │   ├── 📁 Common/
#### │   │   └── 📄 BaseEntity.cs          # Id, CreatedAt, UpdatedAt
#### │   │
#### │   ├── 📁 Students/
#### │   │   └── 📄 Student.cs             # FirstName, LastName, GPA, ClassRoom
#### │   │
#### │   └── 📁 Teachers/
#### │       └── 📄 Teacher.cs             # FirstName, LastName, Subject, Salary
#### │
#### ├── 📁 Repositories/
#### │   ├── 📄 IGenericRepository.cs      # Generic interfeys
#### │   ├── 📄 GenericRepository.cs       # Generic implementatsiya
#### │   ├── 📄 IStudentRepository.cs
#### │   ├── 📄 ITeacherRepository.cs
#### │   ├── 📄 StudentRepository.cs
#### │   └── 📄 TeacherRepository.cs
#### │
#### ├── 📁 Services/
#### │   ├── 📁 Students/
#### │   │   ├── 📄 IStudentService.cs
#### │   │   └── 📄 StudentService.cs
#### │   │
#### │   └── 📁 Teachers/
#### │       ├── 📄 ITeacherService.cs
#### │       └── 📄 TeacherService.cs
#### │
#### ├── 📁 Exceptions/
#### │   ├── 📄 ValidationException.cs     
#### │   └── 📄 NotFoundException.cs       
#### │
#### ├── 📁 Utils/
#### │   └── 📄 FileStorage.cs             
#### │
#### ├── 📁 Data/
#### │   ├── 📄 students.json              
#### │   └── 📄 teachers.json              
#### │
#### ├── 📄 Program.cs
#### └── 📄 README.md


---

## 🧩 Modellar

### Student

| Field | Type | Description |
|-------|------|-------------|
| Id | Guid | Unique identifier |
| FirstName | string | Ismi |
| LastName | string | Familiyasi |
| Address | string | Manzili |
| GPA | double | O'rtacha ball (0-5) |
| ClassRoom | string | Sinfi (10A, 11B...) |

### Teacher

| Field | Type | Description |
|-------|------|-------------|
| Id | Guid | Unique identifier |
| FirstName | string | Ismi |
| LastName | string | Familiyasi |
| Subject | string | Fani |
| Salary | decimal | Maoshi |

---

## 🔧 Funksiyalar

### Student

| Amal | Tavsif |
|------|--------|
| ➕ Create | Yangi student qo'shish |
| 📋 Read | Barcha studentlarni ko'rish |
| ✏️ Update | Student ma'lumotlarini yangilash |
| 🗑️ Delete | Studentni o'chirish |
| 🔍 Find by ID | ID bo'yicha qidirish |
| 📊 Count by Class | Sinf bo'yicha studentlar soni |

### Teacher

| Amal | Tavsif |
|------|--------|
| ➕ Create | Yangi teacher qo'shish |
| 📋 Read | Barcha teacherlarni ko'rish |
| ✏️ Update | Teacher ma'lumotlarini yangilash |
| 🗑️ Delete | Teacherni o'chirish |
| 🔍 Find by ID | ID bo'yicha qidirish |

---

## 🚀 Ishga tushirish

### 1. Repository ni klonlash


## READ
![1 Programma ishlashi](/assets/read.gif)

## CREATE
![2 Programma ishlashi](/assets/create.gif)

## UPDATE-DELETE
![3 Programma ishlashi](/assets/updateDelete.gif)

s




