using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeekEntities;
using HireAndSeekEntities.Lookups;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public class CompanyFactory : IUserFactory
	{
		private readonly DatabaseContext _db;

		//public CompanyFactory()
		//{
		//}

		public CompanyFactory(DatabaseContext db)
		{
			
			_db = db;
		}

		public IUser CreateUser(UserDto model)
		{
			if (model.Company == null)
				throw new ArgumentException("Company informations are required");
		
			var user = model.Adapt<User>();
			user.ProfilePicture= model.ProfilePicture;

			_db.Users.Add(user);
			var company = new Company(model.Company.Address, model.Company.Industry, model.Company.CompanySize, model.Id, user);
			_db.Companies.Add(company);
			_db.SaveChanges();
			return company;




		}

		public IUser UpdateUser(UserDto model)
		{
			if (model.Company == null)
				throw new ArgumentException("Company informations are required");
			var user = _db.Users.Where(i => i.Id == model.Id && i.Role==model.Role).FirstOrDefault();
			if (user == null)
				throw new Exception("user not found");
			user=model.Adapt<User>();
			user.ProfilePicture = model.ProfilePicture;

			_db.Update(user);
			_db.SaveChanges();

			var company = _db.Companies.Where(i => i.UserId == model.Id).FirstOrDefault();
			if (company == null)
				throw new Exception("company not found");
			model.Company.UserId = user.Id;
			model.Company.Id = company.Id;
			company = model.Company.Adapt<Company>();

			_db.Companies.Update(company);
			_db.SaveChanges();
			return company;
		}
	}
}

