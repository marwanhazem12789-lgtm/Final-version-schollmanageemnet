using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.SubjectCustoms
{
    public interface ISubject : IGenaricRepo<Subject>
    {
        Subject GetFirstSubjectByTeacher(int teacherId);
        Subject GetLastSubjectByTeacher(int teacherId); 
        bool CheckSubjectIdExistsInList(int subjectId, List<int> subjectIds); 
        dynamic GetBasicInfoByTeacher(int teacherId); 
        List<Subject> GetSubjectsOrderedByMaxGradeDesc(); 
        List<Subject> GetSubjectsOrderedByTeacherAndGrade(); 
        int GetSubjectCountByTeacher(int teacherId); 
        List<Subject> GetSubjectsByTeacherToList(int teacherId); 
        dynamic GetSubjectsWithTeacherInfo(int teacherId); 
        List<Subject> TakeSubjects(int count); 
    }
}
