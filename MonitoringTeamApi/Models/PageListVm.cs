using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringTeamApi.Models
{
    [Table("PageListVM")]
    public partial class PageListVm
    {
        public PageListVm()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
            Logs = new HashSet<Logs>();
        }

        [Key]
        public int Id { get; set; }
        public string TimeStamp { get; set; }
        public string PageTitle { get; set; }
        public string UserName { get; set; }

        [InverseProperty("PageListVm")]
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        [InverseProperty("PageListVm")]
        public virtual ICollection<Logs> Logs { get; set; }
    }
}
