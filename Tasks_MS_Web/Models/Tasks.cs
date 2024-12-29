using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tasks_MS_Web.Models
{
    public class Tasks
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        
        [Required, MaxLength(100)]
        public string TaskTitle { get; set; }
        
        [Required, MaxLength(500)]
        public string TaskDescription { get; set; }
        
        [Required, StringLength(30)]
        public string TaskStatus { get; set; }
        
        [Required, StringLength(30)]
        public string TaskPeriority { get; set; }
       
        [Required]
        public DateTime TaskDeadLine { get; set; }
        
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Projects Project { get; set; }

        [ForeignKey("TeamMember")]
        public int MemberID { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
