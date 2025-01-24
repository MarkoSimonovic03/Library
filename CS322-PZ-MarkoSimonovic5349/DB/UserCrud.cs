using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS322_PZ_MarkoSimonovic5349.Entities;
using MySql.Data.MySqlClient;

namespace CS322_PZ_MarkoSimonovic5349.DB
{
	public class UserCrud
	{
		// Creates a new user in the database and returns the created user
		public static User CreateUser(string username, string password, string email)
		{
			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();
				string query = "INSERT INTO users (Username, Password, Email) VALUES (@Username, @Password, @Email);";
				MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.Parameters.AddWithValue("@Username", username);
				cmd.Parameters.AddWithValue("@Password", password);
				cmd.Parameters.AddWithValue("@Email", email);

				cmd.ExecuteNonQuery();

				long newUserId = cmd.LastInsertedId;

				User newUser = new User
				{
					Id = (int)newUserId,
					Username = username,
					Password = password,
					Email = email
				};

				return newUser;
			}
		}

		// Retrieves a user from the database by username and password
		public static User GetUserByUsernameAndPassword(string username, string password)
		{
			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();
				string query = "SELECT * FROM users WHERE LOWER(Username) = LOWER(@Username) AND Password = @Password;";
				MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.Parameters.AddWithValue("@Username", username);
				cmd.Parameters.AddWithValue("@Password", password);

				MySqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					User user = new User
					{
						Id = reader.GetInt32("Id"),
						Username = reader.GetString("Username"),
						Password = reader.GetString("Password"),
						Email = reader.GetString("Email")
					};

					return user;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
