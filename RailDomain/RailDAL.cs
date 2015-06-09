using RailDomain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RailDomain.Helpers;

namespace RailDomain
{
    internal class RailDAL
    {
        public RailDAL()
        {
            conStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=d:\Development\Projects\Private\RailJCE\RailDomain\DB\RailDB.mdf;Integrated Security=True";
            conn = new SqlConnection(conStr);
        }

        private string conStr { get; set; }
        private SqlConnection conn { get; set; }

        /// <summary>
        /// Get all stations
        /// </summary>
        public List<Station> GetAllStations()
        {
            string query = "SELECT * FROM [Stations]";
            return ExecuteQuery<Station>(query);
        }

        /// <summary>
        /// Get all routes
        /// </summary>
        public List<Route> GetAllRoutes()
        {
            string query = "SELECT * FROM [Routes]";
            return ExecuteQuery<Route>(query);
        }

        /// <summary>
        /// Get all stations an selected line
        /// </summary>
        /// <param name="line">line name</param>
        public List<Station> GetLineStations(string line)
        {
            string query = string.Format("SELECT * FROM [Stations] WHERE Id IN (SELECT StationId FROM [Routes] WHERE Line='{0}')", line);
            return ExecuteQuery<Station>(query);
        }

        /// <summary>
        /// Get all stations that can be reached from selected station
        /// </summary>
        /// <param name="stationId">station id</param>
        public List<Station> GetLineStations(int stationId)
        {
            string query = string.Format("SELECT * FROM [Stations] WHERE Id IN (SELECT StationId FROM [Routes] WHERE Line IN (SELECT Line FROM [Routes] WHERE StationId={0}))", stationId);
            return ExecuteQuery<Station>(query);
        }

        /// <summary>
        /// Check if source and destination stations on the same line.
        /// </summary>
        /// <param name="source">source station id</param>
        /// <param name="destination">destination station id</param>
        public bool OnSameLine(int source, int destination)
        {
            string query = string.Format("SELECT a.LINE FROM [Routes] a, [Routes] b WHERE a.StationId={0} AND b.StationId={1} AND a.Line=b.Line", source, destination);
            List<Route> routes = ExecuteQuery<Route>(query);
            // not good
            return routes.Count > 0;
        }

        /// <summary>
        /// ExecuteQuery and return list of objects
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="query">Query string</param>
        private List<T> ExecuteQuery<T>(string query) where T : new()
        {
            List<T> result = new List<T>();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    result = reader.MapDataToModel<T>();
                }
                conn.Close();
                return result;
            }
            catch (Exception)
            {
                conn.Close();
                return result;
            }
        }
    }
}
