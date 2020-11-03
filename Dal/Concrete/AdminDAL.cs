using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Concrete
{
        public  class AdminDAL : IAdminDAL
    {
        private string connectionString;


        public AdminDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        ///////////////////////////////////////////////////////
        public AdminDTO CreateAdmin(AdminDTO admin)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Admin(StartingWorking,FinishingWorking,PersonId) output   INSERTED.Id values(@StartingWorking,@FinishingWorking,@PersonId)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@StartingWorking", admin.StartingWorking);
                comm.Parameters.AddWithValue("@FinishingWorking", admin.FinishingWorking);
                comm.Parameters.AddWithValue("@PersonId", admin.PersonId);
                conn.Open();

                admin.Id = Convert.ToInt32(comm.ExecuteScalar());
                return admin;
            }
        }

        ///////////////////////////////////////
        public List<AdminDTO> GetAllAdmin()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Admin";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<AdminDTO> admin = new List<AdminDTO>();
                while (reader.Read())
                {
                    admin.Add(new AdminDTO
                    {
                        Id = (int)reader["Id"],
                        StartingWorking=Convert.ToDateTime( reader["StartingWorking"]),
                        FinishingWorking = Convert.ToDateTime(reader["FinishingWorking"]),
                        PersonId = (int)reader["PersonId"]
                    });
                }

                return admin;
            }
        }

        //////////////////////////////////////////////////////

        public void DeleteAdmin(int id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Admin where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
        //////////////////////////////////////////////
        public AdminDTO GetAdminById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select* from Admin where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                AdminDTO admin = new AdminDTO
                {
                    Id = (int)reader["Id"],
                    StartingWorking = Convert.ToDateTime(reader["StartingWorking"]),
                    FinishingWorking = Convert.ToDateTime(reader["FinishingWorking"]),
                    PersonId = (int)reader["PersonId"]
                };
                return admin;
            }
        }
        public AdminDTO UpdateAdmin(AdminDTO admin)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Admin set StartingWorking=@StartingWorking,FinishingWorking=@FinishingWorking,PersonId=@PersonId where Id=@Id)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@StartingWorking", admin.StartingWorking);
                comm.Parameters.AddWithValue("@FinishingWorking", admin.FinishingWorking);
                comm.Parameters.AddWithValue("@Id", admin.Id);
                comm.Parameters.AddWithValue("@PersonId", admin.PersonId);
                conn.Open();

                admin.Id = Convert.ToInt32(comm.ExecuteScalar());
                return admin;
            }
        }

        bool Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select UserEmail, UserPassword from User JOIN User ON Person.PersonId where Person.RoleId = 2 AND UserEmail = @email AND UserPassword = @password";
               
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@email", username);
                comm.Parameters.AddWithValue("@password", password);
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                string _email = (string)reader["UserEmail"];
                string _password = (string)reader["UserPassword"];

                return _email != null && _password != null;

            }



        }

    }





}
