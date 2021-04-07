using System.Collections.Generic;

namespace BLTS.WebApi.Models
{
    public partial class Application : Entity<long>
    {
        public Application()
        {
            ApplicationLogCollection = new HashSet<ApplicationLog>();
            OperationalConfigurationCollection = new HashSet<OperationalConfiguration>();
            WebsiteCollection = new HashSet<Website>();
        }

        public string Name { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PocEmail { get; set; }
        public string PocNumber { get; set; }

        public virtual ICollection<ApplicationLog> ApplicationLogCollection { get; set; }
        public virtual ICollection<OperationalConfiguration> OperationalConfigurationCollection { get; set; }
        public virtual ICollection<Website> WebsiteCollection { get; set; }
    }
}
