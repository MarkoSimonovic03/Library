using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS322_PZ_MarkoSimonovic5349.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public User() { }
		public User(int id, string username, string password, string email)
		{
			Id = id;
			Username = username;
			Password = password;
			Email = email;
		}
	}
}
