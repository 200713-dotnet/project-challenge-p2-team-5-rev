using System;
using System.Collections.Generic;
using BugTracker.Service.Models.Abstracts;

namespace BugTracker.Service.Models
{
  public class Ticket : EntityBase
  {
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime Created { get; set; }

    // public virtual User Dev { get; set; }
    public int DevID { get; set; }

    // public virtual User Submitter { get; set; }
    public int SubmitterID { get; set; }

    // public virtual Project Project { get; set; }
    public int ProjectID { get; set; }

    public virtual string Priority { get; set; }

    public virtual string Status { get; set; }

    public virtual string Type { get; set; }

    // public virtual ICollection<Comment> Comments { get; set; }  // probably not implemented
  }
}