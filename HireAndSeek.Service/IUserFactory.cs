using HireAndSeek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public interface IUserFactory
	{
	    Task<User> CreateUser(UserDto model);
		Task<User> UpdateUser(UserDto model);

	}
}
