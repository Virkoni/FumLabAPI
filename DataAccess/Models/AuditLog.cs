using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class AuditLog
{
    public int AuditLogId { get; set; }

    public string TableName { get; set; } = null!;

    public int RecordId { get; set; }

    public string Action { get; set; } = null!;

    public int PerformedBy { get; set; }

    public DateTime? PerformedAt { get; set; }

    public virtual User PerformedByNavigation { get; set; } = null!;
}
