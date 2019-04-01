using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustMyResumeApi.Models
{
    public class SkillCategory
    {

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
