using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeek.Entities.Lookups;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public class FileService : IFileService
	{
		private readonly DatabaseContext _dbContext;
		public FileService(DatabaseContext db)
		{
			this._dbContext = db; 
		}

		public async Task<FileDetails> UploadFileAsync(IFormFile fileData)
		{
			try
			{
				var fileDetails = new FileDetails()
				{
					FileName = fileData.FileName,
					FileType = Path.GetExtension(fileData.FileName),
					Path= Path.Combine("C:\\Users\\Ramanda\\source\\repos\\HireAndSeek\\HireAndSeek.Data\\Files\\", fileData.FileName)
,
				};

				using (var stream = new FileStream(fileDetails.Path, FileMode.Create))
				{
					await fileData.CopyToAsync(stream);
				}

				byte[] fileContent;
				using (var memoryStream = new MemoryStream())
				{
					using (var fileStream = new FileStream(fileDetails.Path, FileMode.Open))
					{
						await fileStream.CopyToAsync(memoryStream);
					}
					fileContent = memoryStream.ToArray();
				}

				fileDetails.FileData = fileContent;
				await _dbContext.FileDetails.AddAsync(fileDetails);
				await _dbContext.SaveChangesAsync();
				return fileDetails;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
