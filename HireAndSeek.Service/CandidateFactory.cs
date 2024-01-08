using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeekEntities;
using HireAndSeekEntities.Lookups;
using Mapster;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HireAndSeek.Service
{
	public class CandidateFactory : IUserFactory
	{

		private readonly DatabaseContext _db;


		public CandidateFactory(DatabaseContext db)
		{
			
			_db = db;
		}

		public IUser CreateUser(UserDto model)
		{
			if (model.Candidate == null)
				throw new ArgumentException("Candidate informations are required");
			var user = model.Adapt<User>();
			user.ProfilePicture = model.ProfilePicture;
			_db.Users.Add(user);
			var candidate = new Candidate(model.Candidate.ExperienceLevel, model.Candidate.Cv, model.Id, user);
			_db.Candidates.Add(candidate);
			_db.SaveChanges();
			return candidate;

		}

		public IUser UpdateUser(UserDto model)
		{
			if (model.Candidate == null)
				throw new ArgumentException("Company informations are required");
			var user = _db.Users.Where(i => i.Id == model.Id && i.Role == model.Role).FirstOrDefault();
		    user = model.Adapt<User>();
			user.ProfilePicture = model.ProfilePicture;
			_db.Update(user);


			var candidate = _db.Candidates.Where(i => i.UserId == model.Id).FirstOrDefault();
			if (candidate == null)
				throw new Exception("candidate not found");
			model.Candidate.UserId = user.Id;
			model.Candidate.Id = candidate.Id;
			model.Candidate.Cv = candidate.Cv;
			candidate = model.Candidate.Adapt<Candidate>();
     		_db.Update(candidate);
			_db.SaveChanges();
			return candidate;
		}
	}
}
