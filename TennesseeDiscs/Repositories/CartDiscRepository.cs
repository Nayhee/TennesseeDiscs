using TennesseeDiscs.Models;
using TennesseeDiscs.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace TennesseeDiscs.Repositories
{
    public class CartDiscRepository : ICartDiscRepository
    {
        private readonly string _connectionString;

        public CartDiscRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }




        public void AddDiscToCart(int cartId, int discId, int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" INSERT INTO CartDisc (CartId, DiscId, UserId)
                                          OUTPUT INSERTED.ID
                                          VALUES (@cartId, @discId, @userId);";
                    DbUtils.AddParameter(cmd, "@cartId", cartId);
                    DbUtils.AddParameter(cmd, "@discId", discId);
                    DbUtils.AddParameter(cmd, "@userId", userId);

                    cmd.ExecuteScalar();

                }
            }
        }

        public void RemoveDiscFromCart(int cartId, int discId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"

                    ";
                }
            }
        }

    }
}
