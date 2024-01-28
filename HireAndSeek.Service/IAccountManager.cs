using HireAndSeek.Entities;
using HireAndSeek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public interface IAccountManager
	{
	 public Task<User> CreateOrUpdateUser(UserDto model);
	}
}
