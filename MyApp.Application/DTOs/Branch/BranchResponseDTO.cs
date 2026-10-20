using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs.Branch
{
    public class BranchResponseDTO
    {
        public Guid BranchId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Province { get; set; }
        public String ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
