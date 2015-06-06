using RailDomain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailDomain.Helpers;

namespace RailDomain
{
    public class RailDAL
    {
        public RailDAL()
        {
            conStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=d:\Development\Projects\Private\RailJCE\RailDomain\DB\RailDB.mdf;Integrated Security=True";
            conn = new SqlConnection(conStr);
        }

        private string conStr{get;set;}
        private SqlConnection conn { get; set; }


        public List<Station> GetAllStations()
        {
            List<Station> stations;
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Stations", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                stations = reader.MapDataToModel<Station>();
            }
            conn.Close();

            return stations;
        }

        public List<Route> GetAllRoutes()
        {
            List<Route> routes;
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Routes", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                routes = reader.MapDataToModel<Route>();
            }
            conn.Close();

            return routes;
        }

    }
}
