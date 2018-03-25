using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
  public class ProductSqlDAL : IProductDAL
  {
    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SSGeek;Integrated Security=True";


    public Product GetProduct(int id)
    {
      const string GetProductDetailSql = @"select * from products where product_id = @id";
      var product = new Product();
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();

        var cmd = new SqlCommand(GetProductDetailSql, conn);
        cmd.Parameters.AddWithValue("@id", id.ToString());

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          try
          {
            product.ProductId = int.Parse(reader["product_id"].ToString());
            product.Price = double.Parse(reader["price"].ToString());
            product.Name = reader["name"].ToString();
            product.Description = reader["description"].ToString();
            product.ImageName = reader["image_name"].ToString();
          }
          catch (SqlException) { }
        }
        return product;
      }
    }

    public List<Product> GetProducts()
    {
      var products = new List<Product>();
      const string GetProductsSql = @"select * from products";

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(GetProductsSql, conn);
        
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          try
          {

            var product = new Product();
            product.ProductId =  int.Parse(reader["product_id"].ToString());
            product.Price = double.Parse(reader["price"].ToString());
            product.Name = reader["name"].ToString();
            product.Description = reader["description"].ToString();
            product.ImageName = reader["image_name"].ToString();

            products.Add(product);
          }
          catch (SqlException) { }
          
        }
      }

      return products;
    }
  }
}