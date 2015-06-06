using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailDomain.Models
{
    public class Station
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Station()
        {
        }

        public Station(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return String.Format("{0} \t | {1} \t", Id, Name);
        }
    }
}
