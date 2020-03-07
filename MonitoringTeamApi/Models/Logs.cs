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

        [ForeignKey(nameof(PageInfoId))]
        [InverseProperty(nameof(Pages.Logs))]
        public virtual Pages PageInfo { get; set; }
    }
}
