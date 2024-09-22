using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class FilePermission
{
    public int PermissionId { get; set; }

    public int FileId { get; set; }

    public int RoleId { get; set; }

    public bool? CanView { get; set; }

    public bool? CanEdit { get; set; }

    public bool? CanDelete { get; set; }

    public virtual File File { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
