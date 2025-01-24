using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS322_PZ_MarkoSimonovic5349.Entities;
using MySql.Data.MySqlClient;

namespace CS322_PZ_MarkoSimonovic5349.DB
{
	public class LoanCrud
	{
		// Retrieves a list of loans for a specific user by their user ID
		public static List<Loan> GetLoansByUserId(int userId)
		{
			List<Loan> loans = new List<Loan>();

			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();
				string query = "SELECT * FROM loans WHERE UserId = @UserId";
				MySqlCommand cmd = new MySqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@UserId", userId);

				MySqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Loan loan = new Loan
					{
						Id = reader.GetInt32("Id"),
						UserId = reader.GetInt32("UserId"),
						BookId = reader.GetInt32("BookId"),
						StartDate = reader.GetDateTime("StartDate"),
						EndDate = reader.GetDateTime("EndDate")
					};

					loans.Add(loan);
				}
			}

			return loans;
		}

		// Creates a new loan entry in the database when a user borrows a book
		public static void CreateLoan(int userId, int bookId)
		{
			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();

				string query = "INSERT INTO loans (UserId, BookId, StartDate) VALUES (@UserId, @BookId, @StartDate)";
				MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.Parameters.AddWithValue("@UserId", userId);
				cmd.Parameters.AddWithValue("@BookId", bookId);
				cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);

				cmd.ExecuteNonQuery();

				// Update book availability
				BookCrud.SetBookAvailability(bookId, false);
			}
		}

		// Updates the loan record to mark the book as returned
		public static void ReturnLoan(int bookId)
		{
			using (MySqlConnection conn = DBUtil.GetConnection())
			{
				conn.Open();

				string query = "UPDATE loans SET EndDate = @EndDate " +
					"WHERE BookId = @BookId AND EndDate IS NULL";
				MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.Parameters.AddWithValue("@EndDate", DateTime.Now);
				cmd.Parameters.AddWithValue("@BookId", bookId);

				cmd.ExecuteNonQuery();

				BookCrud.SetBookAvailability(bookId, true);
			}
		}
	}
}
