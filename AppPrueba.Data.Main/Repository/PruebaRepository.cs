using AppPrueba.Data.Main.Contracts;
using AppPrueba.Data.Main.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppPrueba.Data.Main
{
    public class PruebaRepository : IPruebaRepository
    {
        private readonly string _connectionString = "Server=(localdb)\\myServerBBDD;Database=mytasks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

        private readonly PruebaContext _dbContext;

        public PruebaRepository(IConfiguration configuration, PruebaContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<IEnumerable<UsersEntity>> GetUsersAll()
        {
            IQueryable<UsersEntity> res = _dbContext.Users;

            return await res.ToListAsync();
        }
    }
}
