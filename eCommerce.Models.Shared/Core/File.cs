using eCommerce.Models.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Shared.Core
{
	public class File : IFile
	{
		public byte[] FileAsBinary { get; set; }

		[NotMapped]
		public string FileData { get; set; }
	}
}
