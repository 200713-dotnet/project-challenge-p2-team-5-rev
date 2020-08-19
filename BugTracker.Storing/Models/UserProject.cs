using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class UserProject : EntityBase
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
    }
}