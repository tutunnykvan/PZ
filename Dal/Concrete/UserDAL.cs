using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;



namespace DAL.Concrete
{
    public class UserDAL : IUserDAL
    {
        private string connectionString;


        public UserDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        ///////////////////////////////////////////////////////
        public UserDTO CreateUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into UserName(Email,Password,PersonId) output   INSERTED.Id values(@Email,@Password,@PersonId)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Email", user.Email);
                comm.Parameters.AddWithValue("@Password", user.Password);
                comm.Parameters.AddWithValue("@PersonId", user.PersonId);

                conn.Open();

                user.Id = Convert.ToInt32(comm.ExecuteScalar());
                return user;
            }
        }

        ///////////////////////////////////////
        public List<UserDTO> GetAllUser()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from UserName";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<UserDTO> user = new List<UserDTO>();
                while (reader.Read())
                {
                   user.Add(new UserDTO
                   {
                       Id = (int)reader["Id"],
                       Email = reader["Email"].ToString(),
                       Password = Encoding.ASCII.GetBytes(reader["Password"].ToString()),
                       PersonId = (int)reader["PersonId"]
                   });
                }

                return user;
            }
        }

        //////////////////////////////////////////////////////

        public void DeleteUser(int id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from User where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
        //////////////////////////////////////////////
        public UserDTO GetUserById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select* from User where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                UserDTO user = new UserDTO
                {
                    Id = (int)reader["Id"],
                    Email = reader["Email"].ToString(),
                    Password = Encoding.ASCII.GetBytes(reader["Password"].ToString()),
                    PersonId = (int)reader["PersonId"]
                };
                return user;
            }
        }
        public UserDTO UpdateUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update UserName set Email=@Email,Password=@Password,PersonId=@PersonId where Id=@Id)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Email", user.Email);
                comm.Parameters.AddWithValue("@Password", user.Password);
                comm.Parameters.AddWithValue("@PersonId", user.PersonId);
                conn.Open();

                user.Id = Convert.ToInt32(comm.ExecuteScalar());
                return user;
            }
        }

    }





}
