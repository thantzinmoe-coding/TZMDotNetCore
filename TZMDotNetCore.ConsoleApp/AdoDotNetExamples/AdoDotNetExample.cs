﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZMDotNetCore.ConsoleApp.AdoDotNetExamples;

internal class AdoDotNetExample
{
    //private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    //{
    //    DataSource = "LENOVO-V14\\SQLEXPRESS",
    //    InitialCatalog = "TZMDotNetCore",
    //    UserID = "sa",
    //    Password = "sasa@123"
    //};

    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public AdoDotNetExample(SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
    }

    public void Edit(int id)
    {
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        Console.WriteLine("Connection opened!");
        string query = "select * from tbl_blog where BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);

        connection.Close();
        Console.WriteLine("Connection closed!");

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("No data found!");
            return;
        }
        DataRow dr = dt.Rows[0];

        Console.WriteLine("Blog Id => " + dr["BlogId"]);
        Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
        Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
        Console.WriteLine("Blog Content => " + dr["BlogContent"]);
        Console.WriteLine("-------------------------");
    }
    public void Read()
    {
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        Console.WriteLine("Connection opened!");
        string query = "select * from tbl_blog";
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);

        connection.Close();
        Console.WriteLine("Connection closed!");

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("Blog Id => " + dr["BlogId"]);
            Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content => " + dr["BlogContent"]);
            Console.WriteLine("-------------------------");
        }
    }
    public void Create(string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);
        int result = cmd.ExecuteNonQuery();

        connection.Close();
        string message = result > 0 ? "Saving successful." : "Saving failed";
        Console.WriteLine(message);
    }
    public void Update(int id, string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);
        int result = cmd.ExecuteNonQuery();

        connection.Close();
        string message = result > 0 ? "Updating successful." : "Updating failed";
        Console.WriteLine(message);
    }
    public void Delete(int id)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);

        int result = cmd.ExecuteNonQuery();

        connection.Close();
        string message = result > 0 ? "Deleting successful." : "Deleting failed";
        Console.WriteLine(message);
    }
}
