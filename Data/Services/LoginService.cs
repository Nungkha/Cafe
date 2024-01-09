using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafe.Data.Models;

namespace Cafe.Data.Services
{
	public class LoginService
	{
		// creating list of UserModel type to store the user's object
		private static List<UserModel> _users = new List<UserModel>
		{
			// creating deafult admin and staff user
			new UserModel{ Email = "admin@gmail.com", Password = "admin123", Role = Roles.Admin },
			new UserModel{ Email = "staff@gmail.com", Password = "staff123", Role = Roles.Staff },
		};


		// this method returns the object of authenticated Users type if found
		public UserModel AuthenticateUser(string email, string password)
		{
			// finding first user from _users list which matches email and password
			var user = _users.FirstOrDefault(x => x.Email == email && x.Password == password);
			return user;
		}
 	}
}
