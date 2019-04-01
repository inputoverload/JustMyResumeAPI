using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JustMyResumeApi.Models
{
    public class User
    {

        [Key]
        public long Id { get; set; }

        public string FirstName{ get; set; }
        public string LastName{ get; set; }

        public string StreetAddress{ get; set; }
        public string StreetAddress2{ get; set; }
        public string City{ get; set; }
        public string State{ get; set; }
        public string ZipCode{ get; set; }

        public string Phone{ get; set; }
        public string Phone2{ get; set; }
        public string Email{ get; set; }

        public ICollection<Job> Jobs { get; set; }
        public ICollection<EducationItem> EducationItems { get; set; }
        public ICollection<TechSkill> TechSkills { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
