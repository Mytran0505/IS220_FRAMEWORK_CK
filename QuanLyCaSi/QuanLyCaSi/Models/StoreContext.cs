﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace QuanLyCaSi.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }//biết thành viên 

        public StoreContext(string connectionString) //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }
        public StoreContext()
        {
        }
    }
}