using Models.Teachers;

namespace Services.Teachers;

public interface ITeacherService
{
    Teacher GetTeachersFromUser();

    void CreateTeacher(Teacher teacher);

    Teacher [] GetAllTeachers();

    void TeacherPrintInfo(Teacher teacher);
}