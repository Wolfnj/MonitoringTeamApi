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

        [ForeignKey(nameof(PageInfoId))]
        [InverseProperty(nameof(Pages.ApplicationUser))]
        public virtual Pages PageInfo { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUsers.ApplicationUser))]
        public virtual AspNetUsers User { get; set; }
        [InverseProperty("ApplicationUser")]
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
    }
}
