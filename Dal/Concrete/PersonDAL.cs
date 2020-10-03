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
    public class PersonDAL : IPersonDAL
    {
        private string connectionString;


        public PersonDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        ///////////////////////////////////////////////////////
        public PersonDTO CreatePerson(PersonDTO person)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Person(FirstName,LastName,Birthday,RoleId) output   INSERTED.PersonId values(@FirstName,@LastName,@Birthday,@RoleId)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FirstName", person.FirstName);
                comm.Parameters.AddWithValue("@LastName", person.LastName);
                comm.Parameters.AddWithValue("@Birthday", person.Birthday);
                comm.Parameters.AddWithValue("@RoleId", person.RoleId);
                conn.Open();

                person.PersonId = Convert.ToInt32(comm.ExecuteScalar());
                return person;
            }
        }

        ///////////////////////////////////////
        public List<PersonDTO> GetAllPerson()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Person";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<PersonDTO> person = new List<PersonDTO>();
                while (reader.Read())
                {
                   person.Add(new PersonDTO
                   {
                       PersonId = (int)reader["PersonId"],
                       FirstName = reader["FirstName"].ToString(),
                       LastName = reader["LastName"].ToString(),
                       Birthday = Convert.ToDateTime(reader["Birthday"]),
                       RoleId = (int)reader["RoleId"]
                   });
                }

                return person;
            }
        }

        //////////////////////////////////////////////////////

        public void DeletePerson(int id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Person where PersonId = @Personid";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Personid", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
        //////////////////////////////////////////////
        public PersonDTO GetPersonById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                PersonDTO person = new PersonDTO();
                comm.CommandText = $"select * from Person where Id = {id}";
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    person = new PersonDTO

                    {
                        PersonId = (int)reader["PersonId"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Birthday = Convert.ToDateTime(reader["Birthday"]),
                        RoleId = (int)reader["RoleId"]
                    };
                };
                return person;
            }
        }
        public PersonDTO UpdatePerson(PersonDTO person)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Person set FirstName=@FirstName,LastName=@LastName,Birthday=@Birthday,RoleId=@RoleId where Id=@Id)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FirstName", person.FirstName);
                comm.Parameters.AddWithValue("@LastName", person.LastName);
                comm.Parameters.AddWithValue("@Birthday", person.Birthday);
                comm.Parameters.AddWithValue("@PersonId", person.PersonId);
                comm.Parameters.AddWithValue("@RoleId", person.RoleId);
                conn.Open();

                person.PersonId = Convert.ToInt32(comm.ExecuteScalar());
                return person;
            }
        }

    }





}
