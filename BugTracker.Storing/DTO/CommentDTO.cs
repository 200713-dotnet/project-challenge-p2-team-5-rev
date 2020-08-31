using System;
using BugTracker.Storing.Models;

namespace BugTracker.Storing.DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public UserDTO Commenter { get; set; }
        public DateTime DateCreated { get; set; }
        public string Text { get; set; }

        public CommentDTO() { }

        public CommentDTO(Comment comment)
        {
            CommentId = comment.CommentId;
            Commenter = new UserDTO(comment.Commenter);
            DateCreated = comment.DateCreated;
            Text = comment.Text;
        }
    }
}