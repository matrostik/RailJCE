using RailDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailDomain
{
    public class RailBL
    {
        private RailDAL dal { get; set; }

        public RailBL()
        {
            dal = new RailDAL();
        }

        /// <summary>
        /// Get all stations
        /// </summary>
        public List<Station> GetAllStations()
        {
            return dal.GetAllStations();
        }

        /// <summary>
        /// Get all stations that can be reached from selected station
        /// </summary>
        /// <param name="stationId">station id</param>
        public List<Station> GetLineStations(int stationId)
        {
            return dal.GetLineStations(stationId);
        }

        public void GetRouteStations(int source, int destination)
        {
            bool inSameLine = dal.OnSameLine(source, destination);
        }


    }
}
