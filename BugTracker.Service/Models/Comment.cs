using System;

namespace BugTracker.Service.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual User Commenter { get; set; }
    }
}