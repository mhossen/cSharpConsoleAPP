﻿using System.Configuration;

namespace ConsoleApplicationForlearning
{
    public class DBConfig
    {
        public readonly string _connect = null;

        public DBConfig()
        {
            //_connect = @"Data Source=mohammedhossen\sqlexpress;Initial Catalog=EmployeeDb;Integrated Security=True";
            _connect = ConfigurationManager.AppSettings.Get("EmployeeDB");
        }


    }

}
