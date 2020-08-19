using System.ComponentModel.DataAnnotations;

namespace BugTracker.Storing.Abstracts
{
    public abstract class EntityBase
    {
        [Key]
        public int ID { get; set; }
    }
}