using Dorixona.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorixona.Domain.Models.AdminModel.AdminEntities
{
    public class AdminActivityLog : BaseParams
    {
        public Guid AdminId { get; set; }
        public string Action { get; set; } = default!;
        public DateTime Timestamp { get; set; }
        public string? Description { get; set; }
    }
}
