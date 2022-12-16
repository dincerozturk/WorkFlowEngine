using WorkFlowManager.Common.Enums;

namespace WorkFlowManager.Common.Tables
{
    public class Document : ABaseTable
    {
        public int OwnerId { get; set; }
        public virtual ABaseTable Owner { get; set; }

        public virtual FileType FileType { get; set; }
        public string FileName { get; set; }

        public string MediaName { get; set; }
        public string MimeType { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }

    }
}
