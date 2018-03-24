using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
  public class ForumPost
  {
    public string Username { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }

    public int Id { get; set; }
    public DateTime PostDate { get; set; }
  }
}