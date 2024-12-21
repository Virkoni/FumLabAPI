namespace FumLabAPI.Contracts.File
{
    public class GetFileResponse
    {
        public int FileId { get; set; }
        public string NameFile { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public int UploadedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}