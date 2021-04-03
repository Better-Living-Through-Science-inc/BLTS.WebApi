using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace BLTS.WebApi.Models
{
    public partial class FileStorage : Entity<long>
    {
        public FileStorage()
        {
        }

        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string RootPath { get; set; }
        public long SizeKB { get; set; }
        public string SubPath { get; set; }
        [NotMapped]
        public Stream FileData { get; set; }
    }
}
