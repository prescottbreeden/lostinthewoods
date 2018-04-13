using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using lost_in_the_woods.Models;
using Dapper;
using System.Linq;

namespace lost_in_the_woods.Factories
{
    public class TrailFactory
    {
        string server = "localhost";
        string port = "3306";
        string db = "lost_in_the_woods";
        string user = "root";
        string pass = "root";
        
        internal IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }

        // get all trails
        public List<Trail> GetAllTrails()
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    string query = "SELECT * FROM trails";
                    dbConnection.Open();
                    return dbConnection.Query<Trail>(query).ToList();
                }
            }
        }
        
        // get a trail by Id
        public List<Trail> GetTrailId(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    string query = $"SELECT * FROM trails where id = {id}";
                    dbConnection.Open();
                    return dbConnection.Query<Trail>(query).ToList();
                }
            }
        }

        // add a trail
        public void AddNewTrail(Trail trail)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO trails (name, description, elevation, length, longitude, latitude) ";
                query += "VALUES (@Name, @Description, @Elevation, @Length, @Longitude, @Latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, trail);               
            }
        }
    }
}