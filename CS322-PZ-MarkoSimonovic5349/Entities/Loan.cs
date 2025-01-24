using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS322_PZ_MarkoSimonovic5349.Entities
{
	public class Loan
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int BookId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public Loan() { }
		public Loan(int id, int userId, int bookId, DateTime startDate, DateTime endDate)
		{
			Id = id;
			UserId = userId;
			BookId = bookId;
			StartDate = startDate;
			EndDate = endDate;
		}
	}
}
