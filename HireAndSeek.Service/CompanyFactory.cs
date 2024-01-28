using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeek.Entities.Lookups;
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
		private readonly DatabaseContext _dbContext;
		private readonly FileService _fileService;


		public CompanyFactory(DatabaseContext db, FileService fileService)
		{

			_dbContext = db;
			_fileService = fileService;
		}

		public async Task<User> CreateUser(UserDto model)
		{
			var user = model.Adapt<User>();
			var pictureFile = await _fileService.UploadFileAsync(model.ProfilePicture);
			user.FileId = pictureFile.Id;

			await _dbContext.Users.AddAsync(user);
			await _dbContext.SaveChangesAsync();

			var company = model.Company.Adapt<Company>();
			company.UserId = user.Id;
			await _dbContext.Companies.AddAsync(company);

			await _dbContext.SaveChangesAsync();

			return user;
		}

		public async Task<User> UpdateUser(UserDto model)
		{

			var user = _dbContext.Users.Where(i => i.Id == model.Id && i.Role == model.Role).FirstOrDefault();
			if (user == null)
				throw new Exception("user not found");
			user = model.Adapt<User>();
			var pictureFile = await _fileService.UploadFileAsync(model.ProfilePicture);
			user.FileId = pictureFile.Id;

			_dbContext.Update(user);
			_dbContext.SaveChangesAsync();

			var company = _dbContext.Companies.Where(i => i.UserId == model.Id).FirstOrDefault();
			if (company == null)
				throw new Exception("company not found");
			model.Company.UserId = user.Id;
			model.Company.Id = company.Id;
			company = model.Company.Adapt<Company>();

			_dbContext.Companies.Update(company);
			_dbContext.SaveChangesAsync();
			return user;
		}
	}
}

