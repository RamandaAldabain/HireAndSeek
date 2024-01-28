using HireAndSeek.Entities;
using HireAndSeek.Entities.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public interface IFileService
	{
		public Task<FileDetails> UploadFileAsync(IFormFile fileData);
	}
}
