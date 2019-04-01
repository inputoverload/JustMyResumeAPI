using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustMyResumeApi.Models
{
    public class Project
    {

        [Key]
        public long Id { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string DemoUrl { get; set; }
        public string GitHubUrl { get; set; }
    }
}
