﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZMDotNetCore.ConsoleApp.Dtos;
using TZMDotNetCore.ConsoleApp.Services;

namespace TZMDotNetCore.ConsoleApp.DapperExamples;

public class DapperExample
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public DapperExample(SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
    }

    public void Run()
    {
        //Read();
        //Edit(1);
        //Edit(11);
        Create("title", "author", "content");
        //Update(2002, "title 2", "author 2", "conent 2");
        //Delete(2002);
    }
    private void Read()
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();

        foreach (BlogDto item in lst)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("---------------------------");
        }
    }
    private void Edit(int id)
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        var item = db.Query<BlogDto>("select * from tbl_blog where BlogId = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();

        if (item is null)
        {
            Console.WriteLine("No data found!");
            return;
        }
        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
        Console.WriteLine("---------------------------");
    }
    private void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Saving successful." : "Saving failed";
        Console.WriteLine(message);
    }
    private void Update(int id, string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogId = id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Updaing successful." : "Updaing failed";
        Console.WriteLine(message);
    }
    private void Delete(int id)
    {
        var item = new BlogDto
        {
            BlogId = id
        };

        string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Deleting successful." : "Deleting failed";
        Console.WriteLine(message);
    }

}
