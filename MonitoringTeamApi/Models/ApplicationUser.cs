using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringTeamApi.Models
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            AspNetRoles = new HashSet<AspNetRoles>();
        }

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
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
        [InverseProperty("ApplicationUser")]
        public virtual PageCreateVm PageCreateVm { get; set; }
        [ForeignKey(nameof(PageDeleteVmid))]
        [InverseProperty("ApplicationUser")]
        public virtual PageDeleteVm PageDeleteVm { get; set; }
        [ForeignKey(nameof(PageEditVmid))]
        [InverseProperty("ApplicationUser")]
        public virtual PageEditVm PageEditVm { get; set; }
        [ForeignKey(nameof(PageInfoId))]
        [InverseProperty(nameof(Pages.ApplicationUser))]
        public virtual Pages PageInfo { get; set; }
        [ForeignKey(nameof(PageListVmid))]
        [InverseProperty("ApplicationUser")]
        public virtual PageListVm PageListVm { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUsers.ApplicationUser))]
        public virtual AspNetUsers User { get; set; }
        [InverseProperty("ApplicationUser")]
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
    }
}
