using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustMyResumeApi.Models
{
    public class EducationItem
    {

        [Key]
        public long Id { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        public string Description { get; set; }
        public string Degree { get; set; }
    }
}
