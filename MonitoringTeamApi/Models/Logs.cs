using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringTeamApi.Models
{
    public partial class Logs
    {
        [Key]
        public int Id { get; set; }
        public string TimeStamp { get; set; }
        public string UserName { get; set; }
        public string TimeLoggedIn { get; set; }
        public string TimeLoggedOut { get; set; }
        public string NumberOfPageViews { get; set; }
        public string SessionDuration { get; set; }
        public string PageTitle { get; set; }
        public int? PageInfoId { get; set; }
        [Column("PageListVMId")]
        public int? PageListVmid { get; set; }
        [Column("PageCreateVMId")]
        public int? PageCreateVmid { get; set; }
        [Column("PageDeleteVMId")]
        public int? PageDeleteVmid { get; set; }
        [Column("PageEditVMId")]
        public int? PageEditVmid { get; set; }

        [ForeignKey(nameof(PageCreateVmid))]
        [InverseProperty("Logs")]
        public virtual PageCreateVm PageCreateVm { get; set; }
        [ForeignKey(nameof(PageDeleteVmid))]
        [InverseProperty("Logs")]
        public virtual PageDeleteVm PageDeleteVm { get; set; }
        [ForeignKey(nameof(PageEditVmid))]
        [InverseProperty("Logs")]
        public virtual PageEditVm PageEditVm { get; set; }
        [ForeignKey(nameof(PageInfoId))]
        [InverseProperty(nameof(Pages.Logs))]
        public virtual Pages PageInfo { get; set; }
        [ForeignKey(nameof(PageListVmid))]
        [InverseProperty("Logs")]
        public virtual PageListVm PageListVm { get; set; }
    }
}
