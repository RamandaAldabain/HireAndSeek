using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeek.Entities.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HireAndSeek.Service
{
	public class JobService
	{

		private readonly DatabaseContext _dbContext;
		private readonly SkillsService _skillService;
		private readonly IConfiguration _configuration;
		public JobService(DatabaseContext db, SkillsService skillService, IConfiguration configuration)
		{
			_dbContext = db;
			_skillService = skillService;
			_configuration = configuration;
		}

		public async Task<JobDto> CreateOrUpdateJob(JobDto model)
		{
			var jobDto = new JobDto();
			var job = new Job();

			if (model.Id == 0)
			{
				job = model.Adapt<Job>();
				_dbContext.Jobs.Add(job);
				await _dbContext.SaveChangesAsync();
				await _skillService.AddSkillsToEntityAsync<JobSkills>(model.Skills, job.Id);

				jobDto = job.Adapt<JobDto>();
			}
			else
			{
				job = await _dbContext.Jobs.FindAsync(model.Id);

				if (job == null)
				{
					throw new ArgumentNullException("Job not Found", nameof(Job));
				}

				job = model.Adapt<Job>();
				await _skillService.AddSkillsToEntityAsync<JobSkills>(model.Skills, job.Id);
				int maxSkillsToAdd = _configuration.GetValue<int>("SkillLimitConfig:MaxSkills");
				if (job.Skills.Count < maxSkillsToAdd)
				{
					throw new Exception("You need to add More Skills");
				}
				_dbContext.Jobs.Update(job);
				await _dbContext.SaveChangesAsync();

				jobDto = job.Adapt<JobDto>();
			}

			return jobDto;
		}



		public async Task<CandidateJob> ApplyToJob(int jobId, int candidateId)
		{
			 var job = await _dbContext.Jobs
	         .Include(j => j.Skills)
	         .FirstOrDefaultAsync(j => j.Id == jobId);

			if (job == null)
			{
				throw new ArgumentNullException("Job is invalid");
			}

			var candidate = await _dbContext.Candidates
				.Include(c => c.Skills)
				.FirstOrDefaultAsync(c => c.Id == candidateId);

			if (candidate == null)
			{
				throw new ArgumentNullException("Candidate is invalid");
			}

			var jobSkillIds = job.Skills.Select(js => js.SkillId);
			var candidateSkillIds = candidate.Skills.Select(cs => cs.SkillId);
			bool enoughMatchingSkills = jobSkillIds.Count(js => candidateSkillIds.Contains(js)) >= 3;


			if (!enoughMatchingSkills)
			{
				throw new Exception("Candidate does not have enough matching skills for this job");
			}
			var candidateJob = new CandidateJob
			{
				JobId = jobId,
				CandidateId = candidateId
			};

			_dbContext.CandidateJob.Add(candidateJob);
			await _dbContext.SaveChangesAsync();

			return candidateJob;
		}


	}
}