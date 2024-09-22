using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class File
{
    public int FileId { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string? FileType { get; set; }

    public int UploadedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<FilePermission> FilePermissions { get; set; } = new List<FilePermission>();

    public virtual User UploadedByNavigation { get; set; } = null!;
}
