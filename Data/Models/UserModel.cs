using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cafe.Data.Models
{
	public class UserModel
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Email { get; set; }
		public string Password { get; set; } 
		public Roles Role { get; set; }
	}
}
