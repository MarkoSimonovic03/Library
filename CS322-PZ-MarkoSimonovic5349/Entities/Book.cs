using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS322_PZ_MarkoSimonovic5349.Entities
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int Year { get; set; }
		public bool IsAvailable { get; set; }

		public Book() { }
		public Book(int id, string title, string author, int year, bool isAvailable)
		{
			Id = id;
			Title = title;
			Author = author;
			Year = year;
			IsAvailable = isAvailable;
		}
	}
}
