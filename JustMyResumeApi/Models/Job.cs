using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustMyResumeApi.Models
{
    public class Job
    {

        [Key]
        public long Id { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        public string Employer { get; set; }
        public string Title { get; set; }
        public string Role { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }
}
