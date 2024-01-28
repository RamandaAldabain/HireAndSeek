using HireAndSeek.Entities.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities.Dto
{
	public class FileDetailsDto
	{
		public IFormFile FileDetails { get; set; }
	}
}
