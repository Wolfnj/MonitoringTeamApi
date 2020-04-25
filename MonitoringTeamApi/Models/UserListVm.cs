using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringTeamApi.Models
{
    [Table("UserListVM")]
    public partial class UserListVm
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int NumberOfRoles { get; set; }
    }
}
