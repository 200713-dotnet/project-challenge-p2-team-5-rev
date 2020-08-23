using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int CommenterId { get; set; }
        public int TicketId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Text { get; set; }

        public virtual Users Commenter { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
