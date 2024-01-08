using HireAndSeek.Service;
using HireAndSeekEntities;
using HireAndSeekEntities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		public readonly JobService _JobService;

		public JobController(JobService JobService)
		{
			_JobService = JobService;
		}
		[HttpPost]
		[Authorize]

		public IActionResult CreateOrUpdateJob(JobDto model)
		{
			if (ModelState.IsValid)
			{
				var job =  _JobService.CreateOrUpdateJob(model);
				return Ok(new { message = "Operation successful", data = job });
			}
			else
			{
				return BadRequest(new { error = "Invalid model data" });
			}
		}
		[HttpPost]
		[Authorize]

		public IActionResult ApplyToJob(int jobId, int candidateId)
		{
			if (ModelState.IsValid)
			{
				var candidateJob = _JobService.ApplyToJob(jobId, candidateId);
				return Ok(new { message = "Operation successful", data = candidateJob });
			}
			else
			{
				return BadRequest(new { error = "Invalid model data" });
			}
		}

	}
}
