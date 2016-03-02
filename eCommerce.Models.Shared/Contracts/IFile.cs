using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Shared.Contracts
{
    public interface IFile
    {
        byte[] FileAsBinary { get; set; }

		[NotMapped]
		string FileData { get; set; }
    }
}
