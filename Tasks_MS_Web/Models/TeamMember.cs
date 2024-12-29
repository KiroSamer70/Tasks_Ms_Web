using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasks_MS_Web.Models
{
    public class TeamMember
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }

        [Required,MaxLength(100)]
        public string MemberName { get; set; }

        [Required,MaxLength(100)]
        public string MemberEmail { get; set; }

        [Required,MaxLength(50)]
        public string MemberRole { get; set; }

        public List<Tasks> Tasks { get; set; }
    }
}
