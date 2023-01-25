using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SampleProject.Model;
using SampleProject.Repository.Interfaces;

namespace SampleProject.Repository
{
    public class StudentService : IStudentRepository 
    {
        private readonly string _connectionString;
        public StudentService(string connectionString)
        {
            _connectionString = connectionString;
            Console.WriteLine(connectionString);
        }

        public async Task<BaseResponse> SelectStudent(string StudentID)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@StudentID", StudentID);
                    var results = await connection.QueryAsync<Student>("[getStudentDetails]", para, commandType: CommandType.StoredProcedure);
                    return new BaseResponseService().GetSuccessResponse(results);
                }
                
            }
            catch (SqlException ex)
            {

                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }

        // Getting All Students
        public async Task<BaseResponse> SelectAllStudents()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var results = await connection.QueryAsync<Student>("[getStudentDetails]", commandType: CommandType.StoredProcedure);
                    return new BaseResponseService().GetSuccessResponse(results);
                }

            }
            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }

        //Delete Student
        public async Task<BaseResponse> DeleteStudent(string studentID)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@StudentID", studentID); 

                    var results = await connection.QueryAsync<Student>("[DeleteStudentByID]", para,commandType: CommandType.StoredProcedure);
                    return new BaseResponseService().GetSuccessResponse(results);
                }

            }
            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }

        // Insert Student
        public async Task<BaseResponse> InsertStudent(Student student)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@StudentID", student.StudentID);
                    para.Add("@fName", student.fName);
                    para.Add("@lName", student.lName);
                    para.Add("@DOB", student.DOB);
                    para.Add("@Address", student.Address);

                    var results = await connection.QueryAsync<Student>("[InsertStudent]", para, commandType: CommandType.StoredProcedure);
                    Console.WriteLine(results);
                    return new BaseResponseService().GetSuccessResponse(results);
                }

            }
            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }

        // Update Student
        public async Task<BaseResponse> UpdateStudent(Student st)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@StudentID", st.StudentID);
                    para.Add("@fName", st.fName);
                    para.Add("@lName", st.lName);
                    para.Add("@DOB", st.DOB);
                    para.Add("@Address", st.Address);

                    var results = await connection.QueryAsync<Student>("[UpdateStudent]", para, commandType: CommandType.StoredProcedure);
                    Console.WriteLine(results);
                    return new BaseResponseService().GetSuccessResponse(results);
                }

            }
            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }
    }
}
