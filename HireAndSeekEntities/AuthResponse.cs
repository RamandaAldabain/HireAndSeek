using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities
{
	public class AuthResponse
	{
		public string Token { get; set; }
		public bool Result { get; set; }
		public string Error { get; set; }
	}
}
