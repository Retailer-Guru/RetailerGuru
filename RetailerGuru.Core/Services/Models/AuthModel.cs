using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailerGuru.Core.Services.Models
{
    public class AuthModel
    {
        public string Token { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
