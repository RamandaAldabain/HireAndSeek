using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeek.Entities;
using HireAndSeek.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HireAndSeek.Service
{
	public class AccountService : IAccountManager
	{
		private readonly DatabaseContext _dbContext;
		private readonly FileService _fileService;
		private readonly SkillsService _skillService;
		private readonly IConfiguration _configuration;


		public AccountService(DatabaseContext db, FileService fileService, SkillsService skillService, IConfiguration configuration)
		{
			this._dbContext = db;
			_fileService = fileService;
			_skillService = skillService;
			_configuration = configuration;
		}

		public async Task<bool> CheckUser(string email, string password)
		{
			var userExists = await _dbContext.Users
				.AnyAsync(i => i.Email == email && i.Password == password);

			return userExists;
		}
		public async Task<User> CreateOrUpdateUser(UserDto model)
		{
			IUserFactory userFactory;

			if (model == null)
			{
			}

			if (model.Role == RolesEnum.Company)
			{
				if (model.Company == null)
				{
					throw new ArgumentException("Company information is required");
				}

				userFactory = new CompanyFactory(_dbContext, _fileService);
			}
			else if (model.Role == RolesEnum.Candidate)
			{
				if (model.Candidate == null)
				{
					throw new ArgumentException("Candidate information is required");
				}

				userFactory = new CandidateFactory(_dbContext, _fileService, _skillService,_configuration);
			}
			else
			{
				throw new ArgumentException("Invalid user role", nameof(model.Role));
			}

			if (model.Id != 0)
			{
				return await userFactory.UpdateUser(model);
			}
			else
			{
				return await userFactory.CreateUser(model);
			}
		}
	}

}
