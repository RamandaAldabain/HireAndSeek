using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeek.Entities;
using HireAndSeek.Entities.Lookups;
using Mapster;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace HireAndSeek.Service
{
	public class CandidateFactory : IUserFactory
	{

		private readonly DatabaseContext _dbContext;
		private readonly FileService _fileService;
		private readonly SkillsService _skillService;
		private readonly IConfiguration _configuration;


		public CandidateFactory(DatabaseContext db, FileService fileService, SkillsService skillsService, IConfiguration configuration)
		{

			_dbContext = db;
			_fileService = fileService;
			_skillService = skillsService;
			_configuration = configuration;
		}
		public async Task<User> CreateUser(UserDto model)
		{
			try
			{
				var user = model.Adapt<User>();
				var pictureFile = await _fileService.UploadFileAsync(model.ProfilePicture);
				user.FileId = pictureFile.Id;

				await _dbContext.Users.AddAsync(user);
				await _dbContext.SaveChangesAsync();

				var candidate = model.Candidate.Adapt<Candidate>();
				var cv = await _fileService.UploadFileAsync(model.Candidate.Cv);
				candidate.FileId = cv.Id;
				candidate.UserId = user.Id;

				await _dbContext.Candidates.AddAsync(candidate);
				await _dbContext.SaveChangesAsync();

				await _skillService.AddSkillsToEntityAsync<CandidateSkills>(model.Candidate.Skills, candidate.Id);
				int maxSkillsToAdd = _configuration.GetValue<int>("SkillLimitConfig:MaxSkills");
                if(candidate.Skills.Count < maxSkillsToAdd)
				{
					throw new Exception("You need to add More Skills");
				}
				return user;
			}
			catch (Exception e)
			{
				throw new Exception("An error occurred while creating a user.", e);
			}
		}
		public async Task<User> UpdateUser(UserDto model)
		{
			var user = await _dbContext.Users
				.Where(i => i.Id == model.Id && i.Role == model.Role)
				.FirstOrDefaultAsync();

			if (user == null)
			{
				throw new Exception("User not found");
			}

			user = model.Adapt<User>();
			var pictureFile = await _fileService.UploadFileAsync(model.ProfilePicture);
			user.FileId = pictureFile.Id;

			_dbContext.Update(user);

			var candidate = await _dbContext.Candidates
				.Where(i => i.UserId == model.Id)
				.FirstOrDefaultAsync();

			if (candidate == null)
			{
				throw new Exception("Candidate not found");
			}

			model.Candidate.UserId = user.Id;
			model.Candidate.Id = candidate.Id;
			candidate = model.Candidate.Adapt<Candidate>();
			var cv = await _fileService.UploadFileAsync(model.Candidate.Cv);
			candidate.FileId = cv.Id;
			_dbContext.Update(candidate);
			await _dbContext.SaveChangesAsync();

			return user;
		}
	}
}
