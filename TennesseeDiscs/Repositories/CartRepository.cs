using TennesseeDiscs.Models;
using TennesseeDiscs.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace TennesseeDiscs.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly string _connectionString;

        public CartRepository(IConfiguration configuration)
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

        public Cart GetUsersCurrentCart(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 c.Id, c.DateCreated FROM Cart c WHERE c.UserId=@userId ORDER BY c.DateCreated DESC";
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Cart cart = new Cart()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                            };
                            cart.Discs = GetACartsDiscs(cart.Id);
                            return cart;
                        }
                        else
                        {
                        return null;
                        }
                    }
                }
            }
        }


        public List<Disc> GetACartsDiscs(int cartId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT * FROM disc d  
                                        JOIN CartDisc cd on cd.DiscId=d.Id
                                        JOIN Cart c on c.Id=cd.CartId
                                        where c.Id=@id;
                    ";
                    cmd.Parameters.AddWithValue("@id", cartId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Disc> discs = new List<Disc>();
                        while (reader.Read())
                        {
                            Disc disc = new Disc
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                BrandId = reader.GetInt32(reader.GetOrdinal("BrandId")),
                                Condition = reader.GetString(reader.GetOrdinal("Condition")),
                                Speed = reader.GetInt32(reader.GetOrdinal("Speed")),
                                Glide = reader.GetInt32(reader.GetOrdinal("Glide")),
                                Turn = reader.GetInt32(reader.GetOrdinal("Turn")),
                                Fade = reader.GetInt32(reader.GetOrdinal("Fade")),
                                Plastic = reader.GetString(reader.GetOrdinal("Plastic")),
                                Price = reader.GetInt32(reader.GetOrdinal("Price")),
                                Weight = reader.GetInt32(reader.GetOrdinal("Weight")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                                DiscTypeId = reader.GetInt32(reader.GetOrdinal("DiscTypeId")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                            };
                            discs.Add(disc);
                        }
                        return discs;
                    }
                }
            }
        }

        public Cart GetCartById(int cartId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.*, u.id as UsersId, u.Name
                                        FROM Cart c 
                                        JOIN Users u on u.Id=c.UserId
                                        WHERE c.Id=@id
                    ";
                    cmd.Parameters.AddWithValue("@id", cartId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cart cart = new Cart
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                User = new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UsersId")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                }
                            };
                            cart.Discs = GetACartsDiscs(cart.Id);
                            return cart;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }


        public void AddCart(Cart cart)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" INSERT INTO Cart (UserId, DateCreated)
                                          OUTPUT INSERTED.ID
                                          VALUES (@userId, @dateCreated)";
                    DbUtils.AddParameter(cmd, "@userId", cart.UserId);
                    DbUtils.AddParameter(cmd, "@dateCreated", cart.DateCreated);

                    int id = (int)cmd.ExecuteScalar();
                    cart.Id = id;
                }
            }
        }

        public void DeleteCart(int cartId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" DELETE FROM Cart WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", cartId);
                }
            }
        }

    }
}
