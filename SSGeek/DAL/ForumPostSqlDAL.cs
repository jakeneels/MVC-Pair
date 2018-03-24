using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
  public class ForumPostSqlDAL : IForumPostDAL
  {
    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SSGeek;Integrated Security=True";


    public List<ForumPost> GetAllPosts()
    {
      List<ForumPost> posts = new List<ForumPost>();

      const string GetAllPostsSQL = @"select * from forum_post";

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        try
        {
          SqlCommand cmd = new SqlCommand(GetAllPostsSQL, conn);
          var reader = cmd.ExecuteReader();

          while (reader.Read())
          {
            var post = new ForumPost();

            post.Username = reader["username"].ToString();
            post.Subject = reader["subject"].ToString();
            post.Message = reader["message"].ToString();
            post.PostDate = (DateTime) reader["post_date"];

            posts.Add(post);
          }
        }
        catch (SqlException) { }
      }

        return posts;
    }
    
    public bool SaveNewPost(ForumPost post)
    {
      bool success = false;

      const string InsertPostSQL = @"INSERT INTO forum_post(username, subject, message) 
                                     VALUES(@username, @subject, @message)";

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        SqlTransaction trans = conn.BeginTransaction();

        try
        {
          SqlCommand cmd = new SqlCommand(InsertPostSQL, conn);
          cmd.Parameters.Add(new SqlParameter("@username", post.Username));
          cmd.Parameters.Add(new SqlParameter("@subject", post.Subject));
          cmd.Parameters.Add(new SqlParameter("@message", post.Message));
          trans.Commit();

          cmd.ExecuteNonQuery();

          success = true;
        }catch(SqlException)
        { trans.Dispose(); }
      }
      return success;
    }
  }
}