using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using AppPrueba.Data.Main.Contracts;
using AppPrueba.Data.Main.Entities;
using Microsoft.Extensions.Configuration;

namespace AppPrueba.Data.Main
{
    public class PruebaRepository : IPruebaRepository
    {
        private readonly string _connectionString;

        public PruebaRepository(IConfiguration configuration)
        {
            _connectionString = "Server=(localdb)\\myServerBBDD;Database=mytasks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        }

        public UsersEntity GetFirstUsers()
        {
            List<UsersEntity> result = new List<UsersEntity>();
            using (var context = new PruebaContext())
            {
                result = context.Users.Select(x => x).ToList();
            }

            return result.FirstOrDefault();
        }

        public IEnumerable<UsersEntity> GetUsers()
        {
            List<UsersEntity> users = new List<UsersEntity>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT UserID, UserName FROM Users";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsersEntity user = new UsersEntity
                            {
                                UserID = reader.GetInt64(0),
                                UserName = reader.GetString(1)
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users.ToArray();
        }
    }
}
