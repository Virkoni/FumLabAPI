namespace FumLabAPI.Contracts.File
{
    public class CreateFileRequest
    {
        public string NameFile { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public int UploadedBy { get; set; }
    }
}