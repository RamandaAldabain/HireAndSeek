using HireAndSeek.Entities;
using HireAndSeekEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public interface IUserFactory
	{
		IUser CreateUser(UserDto model);
		IUser UpdateUser(UserDto model);

	}
}
