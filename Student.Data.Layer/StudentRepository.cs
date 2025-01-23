using Microsoft.Data.SqlClient;
using Student.Shared;
namespace Student.Data.Layer
{
    public interface IStudentRepository
    {
        List<StudentModel> GetStudents();
    }
        public class StudentRepository : IStudentRepository
        {
            private readonly IConnectivity con;

            public StudentRepository(IConnectivity con)
            {
                this.con = con;
            }

            public List<StudentModel> GetStudents()
            {
                List<StudentModel> studentsdetails = new List<StudentModel>();

                using (SqlConnection connection = con.GetConnection())
                {
                    connection.Open();
                    string getStudentsDetails = "DISPLAY_STUDENTS_SP";
                    SqlCommand cmd = new SqlCommand(getStudentsDetails, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StudentModel student = new StudentModel
                        {
                            roll_no = reader.GetString(0),
                            name = reader.GetString(1),
                            email = reader.GetString(2),
                            gender = reader.GetString(3),
                            year = reader.GetInt32(4),
                            address = reader.GetString(5),
                            phoneNumber = reader.GetString(6)
                        };
                        studentsdetails.Add(student);
                    }
                    return studentsdetails;
                }
            }
        }
}
