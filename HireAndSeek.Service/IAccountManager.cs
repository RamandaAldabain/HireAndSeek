using HireAndSeek.Entities;
using HireAndSeekEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public interface IAccountManager
	{
	 public IUser CreateOrUpdateUser(UserDto model);
	}
}
