using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CS322_PZ_MarkoSimonovic5349.Entities;
using MySql.Data.MySqlClient;

namespace CS322_PZ_MarkoSimonovic5349.DB
{
	public class BookCrud
	{
		// Retrieves all books that are not marked as deleted (IsDeleted = 0)
		public static List<Book> GetAllBooks()
		{
			List<Book> books = new List<Book>();

			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();
				string query = "SELECT * FROM books WHERE IsDeleted = 0";
				MySqlCommand cmd = new MySqlCommand(query, conn);
				MySqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					books.Add(new Book
					{
						Id = reader.GetInt32("Id"),
						Title = reader.GetString("Title"),
						Author = reader.GetString("Author"),
						Year = reader.GetInt32("Year"),
						IsAvailable = reader.GetBoolean("IsAvailable")
					});
				}
			}

			return books;
		}

		// Retrieves a book's details based on the provided book ID
		public static Book GetBookByBookId(int bookId)
        {
            using (MySqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Title, Author, Year FROM books WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", bookId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            Id = reader.GetInt32("Id"),
                            Title = reader.GetString("Title"),
                            Author = reader.GetString("Author"),
                            Year = reader.GetInt32("Year")
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

		// Retrieves the books currently loaned by a user, where the loan does not have an end date
		public static List<Book> GetLoanedBooksByUserId(int userId)
        {
            List<Book> books = new List<Book>();

            using (MySqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT b.Id, b.Title, b.Author, b.Year " +
					"FROM books b " +
					"JOIN loans l ON b.Id = l.BookId " +
					"WHERE l.UserId = @Id AND l.EndDate is NULL AND b.IsDeleted = 0";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", userId);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = reader.GetInt32("Id"),
                        Title = reader.GetString("Title"),
                        Author = reader.GetString("Author"),
                        Year = reader.GetInt32("Year")
                    });
                }
            }

            return books;
        }

		// Adds a new book to the database
		public static void AddBook(Book book)
		{
			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();
				string query = "INSERT INTO books (Title, Author, Year) VALUES (@Title, @Author, @Year)";
				MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.Parameters.AddWithValue("@Title", book.Title);
				cmd.Parameters.AddWithValue("@Author", book.Author);
				cmd.Parameters.AddWithValue("@Year", book.Year);

				cmd.ExecuteNonQuery();
			}
		}

		// Updates an existing book's details in the database
		public static void UpdateBook(Book book)
		{
			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();
				string query = "UPDATE books SET Title = @Title, Author = @Author, Year = @Year WHERE Id = @Id";
				MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.Parameters.AddWithValue("@Id", book.Id);
				cmd.Parameters.AddWithValue("@Title", book.Title);
				cmd.Parameters.AddWithValue("@Author", book.Author);
				cmd.Parameters.AddWithValue("@Year", book.Year);

				cmd.ExecuteNonQuery();
			}
		}

		// Marks a book as deleted by setting the IsDeleted flag to 1
		public static void DeleteBook(int bookId)
		{
			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();
				string query = "UPDATE books SET IsDeleted = 1 WHERE Id = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.Parameters.AddWithValue("@Id", bookId);

				cmd.ExecuteNonQuery();
			}
		}

		// Updates the availability status of a book (available or not)
		public static void SetBookAvailability(int bookId, bool isAvailable)
		{
			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();
				string query = "UPDATE books SET IsAvailable = @IsAvailable WHERE Id = @Id";
				MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.Parameters.AddWithValue("@Id", bookId);
				cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);

				cmd.ExecuteNonQuery();
			}
		}
	}
}
