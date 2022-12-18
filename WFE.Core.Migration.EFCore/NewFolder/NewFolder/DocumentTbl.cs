using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class Document
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public int FileType { get; set; }

    public string FileName { get; set; }

    public string MediaName { get; set; }

    public string MimeType { get; set; }

    public string Extension { get; set; }

    public int Size { get; set; }

    public virtual BaseTable IdNavigation { get; set; }

    public virtual BaseTable Owner { get; set; }
}
