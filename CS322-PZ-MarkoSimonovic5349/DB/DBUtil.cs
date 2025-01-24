using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CS322_PZ_MarkoSimonovic5349.DB
{
	public class DBUtil
	{
		private static string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";
		private static string masterConnectionString = "Server=localhost;Uid=root;Pwd=;";

		// Returns a MySQL connection to the main database
		public static MySqlConnection GetConnection()
		{
			return new MySqlConnection(connectionString);
		}

		// Ensures the existence of the database and creates it if necessary
		public static void EnsureDatabaseExists()
		{
			try
			{
				using (var connection = new MySqlConnection(masterConnectionString))
				{
					connection.Open();

					string checkDbQuery = "CREATE DATABASE IF NOT EXISTS librarydb;";
					using (var command = new MySqlCommand(checkDbQuery, connection))
					{
						command.ExecuteNonQuery();
					}
				}

				CreateTables();
				SeedData();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error ensuring database exists: {ex.Message}");
				throw;
			}
		}

		private static void CreateTables()
		{
			try
			{
				using (var connection = GetConnection())
				{
					connection.Open();

					string createTablesQuery = @"
                        CREATE TABLE IF NOT EXISTS books (
                            Id INT AUTO_INCREMENT PRIMARY KEY,
                            Title VARCHAR(50) NOT NULL,
                            Author VARCHAR(50) NOT NULL,
                            Year INT NOT NULL,
                            IsAvailable TINYINT(1) NOT NULL DEFAULT 1,
                            IsDeleted TINYINT(1) DEFAULT 0
                        );

                        CREATE TABLE IF NOT EXISTS users (
                            Id INT AUTO_INCREMENT PRIMARY KEY,
                            Username VARCHAR(50) NOT NULL UNIQUE,
                            Password VARCHAR(50) NOT NULL,
                            Email VARCHAR(50) NOT NULL UNIQUE
                        );

                        CREATE TABLE IF NOT EXISTS loans (
                            Id INT AUTO_INCREMENT PRIMARY KEY,
                            UserId INT NOT NULL,
                            BookId INT NOT NULL,
                            StartDate DATE NOT NULL,
                            EndDate DATE DEFAULT NULL,
                            FOREIGN KEY (UserId) REFERENCES users(Id),
                            FOREIGN KEY (BookId) REFERENCES books(Id)
                        );
                    ";

					using (var command = new MySqlCommand(createTablesQuery, connection))
					{
						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error creating tables: {ex.Message}");
				throw;
			}
		}

		private static void SeedData()
		{
			try
			{
				using (var connection = GetConnection())
				{
					connection.Open();

					string checkIfEmptyQuery = "SELECT COUNT(*) FROM books";
					bool isTableEmpty;

					using (var checkCommand = new MySqlCommand(checkIfEmptyQuery, connection))
					{
						var result = checkCommand.ExecuteScalar();
						isTableEmpty = Convert.ToInt32(result) == 0;
					}

					if (isTableEmpty)
					{
						string insertBooksQuery = @"
							INSERT INTO books (Title, Author, Year) VALUES
								('To Kill a Mockingbird', 'Harper Lee', 1960),
								('1984', 'George Orwell', 1949),
								('The Great Gatsby', 'F. Scott Fitzgerald', 1925),
								('Pride and Prejudice', 'Jane Austen', 1813),
								('Moby Dick', 'Herman Melville', 1851),
								('The Catcher in the Rye', 'J.D. Salinger', 1951),
								('War and Peace', 'Leo Tolstoy', 1869),
								('The Hobbit', 'J.R.R. Tolkien', 1937),
								('Crime and Punishment', 'Fyodor Dostoevsky', 1866),
								('The Odyssey', 'Homer', 800),
								('The Brothers Karamazov', 'Fyodor Dostoevsky', 1880),
								('Brave New World', 'Aldous Huxley', 1932),
								('Jane Eyre', 'Charlotte Brontë', 1847),
								('Wuthering Heights', 'Emily Brontë', 1847),
								('Anna Karenina', 'Leo Tolstoy', 1877);
						";

						using (var insertCommand = new MySqlCommand(insertBooksQuery, connection))
						{
							insertCommand.ExecuteNonQuery();
						}

						Console.WriteLine("Books data seeded successfully.");
					}
					else
					{
						Console.WriteLine("Books table already contains data. No seeding needed.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error seeding data: {ex.Message}");
				throw;
			}
		}

	}
}
