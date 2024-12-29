using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasks_MS_Web.Models
{
    public class Projects
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }
        [Required,MaxLength(100)]
        public string ProjectName { get; set; }
        [Required,MaxLength(500)]
        public string ProjectDescription { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
       
        [Required]
        public DateTime EndDate { get; set; }

        public List<Tasks> Tasks { get; set; }
    }
}
