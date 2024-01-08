using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeekEntities;
using HireAndSeekEntities.Lookups;

namespace HireAndSeek.Service
{
	public class AccountManagerService : IAccountManager
	{
		private readonly DatabaseContext _db;
		public AccountManagerService(DatabaseContext db)
		{
			_db = db;
		}

		public bool ChechUser(string email,string password)
		{
			var user = _db.Users.Any(i => i.Email == email && i.Password == password);
			if (!user) return false;
			return true;
		}
		public IUser CreateOrUpdateUser(UserDto model)
		{
			IUserFactory userFactory;
			if(model == null) { }
			if(model.Role==RolesLookup.Company)
				userFactory = new CompanyFactory(_db);
			else if (model.Role == RolesLookup.Candidate)
				userFactory = new CandidateFactory(_db);
			else
				throw new ArgumentException("Invalid user role", nameof(model.Role));
			if(model.Id!=0 ) 
				return  userFactory.UpdateUser(model);
			else
			return userFactory.CreateUser(model);

		}
	}

}
