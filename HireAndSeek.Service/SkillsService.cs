using HireAndSeek.Data;
using HireAndSeek.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public class SkillsService
	{
		private readonly DatabaseContext _dbContext;
		private readonly IConfiguration _configuration;

		public SkillsService(DatabaseContext db, IConfiguration configuration)
		{
			_dbContext = db;
			_configuration = configuration;

		}
		public async Task<int> SkillExistsAsync(string skillName)
		{
			var skillId = await _dbContext.Skills
			.Where(skill => skill.Name == skillName)
			.Select(skill => skill.Id)
			 .FirstOrDefaultAsync();
			if (skillId == null) return 0;

			return skillId;
		}

		public async Task<List<int>> AddSkillsToEntityAsync<T>(List<string> skillNames, int id)
		where T : class
		{
			var skillIds = new List<int>();
			IEnumerable<T> entitySkills;
			int maxSkillsToAdd = _configuration.GetValue<int>("SkillLimitConfig:MaxSkills");

			try
			{
				foreach (var skillName in skillNames.Take(maxSkillsToAdd))
				{
					var skillId =  GetOrCreateSkillIdAsync(skillName); 
					skillIds.Add(skillId);
				}

				if (typeof(T) == typeof(JobSkills))
				{
					var constructor = typeof(T).GetConstructor(new[] { typeof(int), typeof(int) });

					entitySkills = skillIds.Select(skillId => constructor.Invoke(new object[] { id, skillId }) as T);

				}
				else if (typeof(T) == typeof(CandidateSkills))
				{
					entitySkills = skillIds.Select(skillId => Activator.CreateInstance(typeof(T), new { CandidateId = id, SkillId = skillId }) as T);
				}
				else
				{
					throw new Exception("dd");
				}



				await _dbContext.Set<T>().AddRangeAsync(entitySkills);
				await _dbContext.SaveChangesAsync();

				return skillIds;
			}
			catch (Exception e)
			{
				throw new Exception($"An error occurred while adding skills to an entity of type {typeof(T).Name}.", e);
			}
		}

		private int GetOrCreateSkillIdAsync(string skillName)
		{
			var skillId = _dbContext.Skills
				.Where(skill => skill.Name == skillName)
				.FirstOrDefault();

			if (skillId == null)
			{
				var newSkill = new Skill { Name = skillName };
				_dbContext.Skills.Add(newSkill);
				_dbContext.SaveChanges();
				skillId.Id = newSkill.Id;
			}

			return skillId.Id;
		}
	}
}
