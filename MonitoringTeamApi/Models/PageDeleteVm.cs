using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringTeamApi.Models
{
    [Table("PageDeleteVM")]
    public partial class PageDeleteVm
    {
        public PageDeleteVm()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
            Logs = new HashSet<Logs>();
        }

        [Key]
        public int Id { get; set; }
        public string TimeStamp { get; set; }
        public string PageTitle { get; set; }
        public string UserName { get; set; }

        [InverseProperty("PageDeleteVm")]
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        [InverseProperty("PageDeleteVm")]
        public virtual ICollection<Logs> Logs { get; set; }
    }
}
