using HireAndSeek.Data;
using HireAndSeekEntities;
using HireAndSeekEntities.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public class JobService
	{
		
		private readonly DatabaseContext _db;
		public JobService( DatabaseContext db)
		{
			_db = db;
		}

		public JobDto CreateOrUpdateJob(JobDto model)
		{
			if (model == null) throw new ArgumentNullException(nameof(Job));
			if(model.Id == 0)
			{
				var job = model.Adapt<Job>();
				_db.Jobs.Add(job);
				_db.SaveChanges();
				var jobDto = job.Adapt<JobDto>();
				
				return jobDto;
			}
			else
			{
				var job= _db.Jobs.FirstOrDefault(i=>i.Id==model.Id);
				if(job == null) throw new ArgumentNullException("Job not Found",nameof(Job));
				job = model.Adapt<Job>();
				_db.Jobs.Update(job);
				_db.SaveChanges();
				var jobDto = job.Adapt<JobDto>();
				
				return jobDto;
			}
		}

		public CandidateJob ApplyToJob(int jobId, int candidateId)
		{
			var job = _db.Jobs.Any(i => i.Id == jobId);
			var candidate = _db.Candidates.Any(i => i.Id == candidateId);
			if (job == null) throw new ArgumentNullException("job is invalid");
			if (candidate == null) throw new ArgumentNullException("user is invalid");
			var candidateJob = new CandidateJob
			{
				JobId = jobId,
				CandidateId = candidateId
			};
			_db.CandidateJob.Add(candidateJob);
			_db.SaveChanges();
			return candidateJob;
		}
	}
}
