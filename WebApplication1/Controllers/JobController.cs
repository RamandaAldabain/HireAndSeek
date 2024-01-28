using HireAndSeek.Service;
using HireAndSeek.Entities;
using HireAndSeek.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireAndSeek.Api.Controllers
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
		

		public async Task<IActionResult> CreateOrUpdateJob(JobDto model)
		{
			if (ModelState.IsValid && model != null)
			{
				var job = await _JobService.CreateOrUpdateJob(model);
				return Ok(new { message = "Operation successful", data = job });
			}
			else
			{
				return BadRequest(new { error = "Invalid model data" });
			}
		}
		[HttpPost]
		[Authorize]

		public async Task<IActionResult> ApplyToJob(int jobId, int candidateId)
		{
			if (ModelState.IsValid)
			{
				var candidateJob = await _JobService.ApplyToJob(jobId, candidateId);

				return Ok(new { message = "Operation successful", data = candidateJob });
			}
			else
			{
				return BadRequest(new { error = "Invalid model data" });
			}
		}
	}
}
