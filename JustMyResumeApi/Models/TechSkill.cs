using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustMyResumeApi.Models
{
    public class TechSkill
    {

        [Key]
        public long Id { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("SkillCategory")]
        public long SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }

        public string Name { get; set; }
        public string SkillLevel { get; set; }
        public int SortOrder { get; set; }
    }
}
