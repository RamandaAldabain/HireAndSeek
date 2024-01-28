using HireAndSeek.Entities.Lookups;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities
{
	public class FileDetails : BaseEntity
	{
		public string FileName { get; set; }
		public string Path { get; set; }
		public byte[] FileData { get; set; }
		public string FileType { get; set; }
	}
}
