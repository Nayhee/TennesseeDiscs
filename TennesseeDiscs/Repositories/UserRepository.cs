using TennesseeDiscs.Models;
using TennesseeDiscs.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace TennesseeDiscs.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
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


        public User GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT u.Id, u.Name, u.firebaseUserId, u.Email, u.userTypeId, ut.Name as UserTypeName
                                        FROM Users u
                                        LEFT JOIN UserType ut on ut.Id=u.userTypeId
                                        WHERE u.firebaseUserId = @FirebaseUserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "firebaseUserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            UserTypeId = DbUtils.GetInt(reader, "userTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "userTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            }
                        };
                    }
                    reader.Close();

                    return user;
                }
            }
        }



        public List<User> GetAllUsers()
        {
            using(var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT u.*, ut.Name as UserTypeName 
                                        FROM Users u 
                                        JOIN UserType ut on ut.Id=u.UserTypeId ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<User> users = new List<User>();
                        while(reader.Read())
                        {
                            User user = new User
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                UserType = new UserType
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                }
                            };
                            users.Add(user);
                        }
                        return users;
                    }
                }
            }
        }

        public User GetUserById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT u.*, ut.Name as UserTypeName 
                                        FROM Users u 
                                        JOIN UserType ut on ut.Id=u.UserTypeId
                                        WHERE u.Id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                UserType = new UserType
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                }
                            };
                            return user;
                        }
                        return null;
                    }
                }
            }
        }
        public User GetUserByEmail(string email)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT u.*, ut.Name as UserTypeName 
                                        FROM Users u 
                                        JOIN UserType ut on ut.Id=u.UserTypeId
                                        WHERE u.Email = @email";

                    cmd.Parameters.AddWithValue("@email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                UserType = new UserType
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                }
                            };
                            return user;
                        }
                        return null;
                    }
                }
            }
        }

        public List<UserType> GetUserTypes()
        {
            using(var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT * FROM UserType";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<UserType> userTypes = new List<UserType>();
                        while (reader.Read())
                        {
                            UserType userType = new UserType
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                            };
                            userTypes.Add(userType);
                        }
                        return userTypes;
                    }
                }
            }
        }

        public void AddUser(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Users ([Name], Email, UserTypeId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@name, @email, @userTypeId)";
                    DbUtils.AddParameter(cmd, "@name", user.Name);
                    DbUtils.AddParameter(cmd, "@email", user.Email);
                    DbUtils.AddParameter(cmd,"@userTypeId", user.UserTypeId);
                    int id = (int)cmd.ExecuteScalar();
                    user.Id = id;
                }
            }
        }
        public void UpdateUser(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Users
                                        SET 
                                            [Name] = @name, 
                                            Email = @email, 
                                            UserTypeId = @userTypeId
                                        WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@name", user.Name);
                    DbUtils.AddParameter(cmd, "@email", user.Email);
                    DbUtils.AddParameter(cmd, "@userTypeId", user.UserTypeId);
                    DbUtils.AddParameter(cmd, "@id", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUser(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" DELETE FROM Users WHERE Id=@id";
                    DbUtils.AddParameter(cmd, "@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
