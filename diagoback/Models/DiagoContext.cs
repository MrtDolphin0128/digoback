using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public class DiagoContext : DbContext
    {
        public DiagoContext(DbContextOptions<DiagoContext> options)
            : base(options)
        {

        }

        public DbSet<UserItem> UserItems { get; set; }

        // public string ConnectionString { get; set; }
        // public DiagoContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        //private MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(ConnectionString);
        //}
        //public List<UserItem> GetAllUsers(UserItem input)
        //{
        //    // var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
        //    // cmd.CommandText = @"UPDATE Tasks SET Completed = STR_TO_DATE(@Date, '%Y/%m/%d') WHERE TaskId = @TaskId;";
        //    // cmd.Parameters.AddWithValue("@TaskId", input.TaskId);
        //    // cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy/MM/dd"));
        //    List < UserItem > list = new List<UserItem>();
        //    using(MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("Select * from users", conn);
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while(reader.Read())
        //            {
        //                list.Add(new UserItem()
        //                {
        //                    Id = Convert.ToInt32(reader["id"]),
        //                    Name = reader["email"].ToString(),
        //                    Email = reader["email"].ToString(),
        //                    Password = reader["password"].ToString()
        //                });
        //            }
        //        }
        //    }
        //    return list;
        //}
    }
}
