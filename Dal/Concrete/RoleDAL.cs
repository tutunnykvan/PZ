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
    public class RoleDAL : IRoleDAL
    {
        private string connectionString;


        public RoleDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        ///////////////////////////////////////////////////////
        public RoleDTO CreateRole(RoleDTO role)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Role(RoleNAme,Description) output   INSERTED.RoleId values(@RoleNAme,@Description)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@RoleName", role.RoleName);
                comm.Parameters.AddWithValue("@Description", role.Description);
                conn.Open();

                role.RoleId = Convert.ToInt32(comm.ExecuteScalar());
                return role;
            }
        }

        ///////////////////////////////////////
        public List<RoleDTO> GetAllRole()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Role";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<RoleDTO> role = new List<RoleDTO>();
                while (reader.Read())
                {
                    role.Add(new RoleDTO
                    {
                        RoleId = (int)reader["RoleId"],
                        RoleName = reader["RoleName"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }

                return role;
            }
        }

        //////////////////////////////////////////////////////

        public void DeleteRole(int id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Role where RoleId = @Roleid";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Roleid", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
        //////////////////////////////////////////////
        public RoleDTO GetRoleById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select* from Role where RoleId = @Roleid";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Roleid", id);
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                RoleDTO role = new RoleDTO
                {
                    RoleId = (int)reader["RoleId"],
                    RoleName = reader["RoleName"].ToString(),
                    Description = reader["Description"].ToString()

                };
                return role;
            }
        }
        public RoleDTO UpdateRole(RoleDTO role)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Role set RoleName=@RoleName,Description=@Description where Id=@Id)";
                comm.Parameters.Clear();

                comm.Parameters.AddWithValue("@RoleName", role.RoleName);
                comm.Parameters.AddWithValue("@Description", role.Description);
                comm.Parameters.AddWithValue("@Id", role.RoleId);
                conn.Open();

                role.RoleId = Convert.ToInt32(comm.ExecuteScalar());
                return role;
            }
        }

    }





}