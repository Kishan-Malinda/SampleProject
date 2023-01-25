using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Model;

namespace SampleProject.Repository.Interfaces
{
    public interface IStudentRepository
    {

        Task<BaseResponse> SelectAllStudents();
        Task<BaseResponse> SelectStudent(string StudentID);
        Task<BaseResponse> DeleteStudent(string StudentID);
        Task<BaseResponse> InsertStudent(Student student);
        Task<BaseResponse> UpdateStudent(Student st);



    }
}
