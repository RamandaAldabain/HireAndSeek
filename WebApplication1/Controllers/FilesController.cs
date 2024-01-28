using HireAndSeek.Entities.Dto;
using HireAndSeek.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireAndSeek.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilesController : ControllerBase
	{
		private readonly IFileService _uploadService;

		public FilesController(IFileService uploadService)
		{
			_uploadService = uploadService;
		}
		[HttpPost]
		public async Task<ActionResult> PostSingleFile([FromForm] FileDetailsDto fileDetails)
		{
			if (fileDetails == null)
			{
				return BadRequest();
			}

			try
			{
				await _uploadService.UploadFileAsync(fileDetails.FileDetails);
				return Ok();
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
