using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailDomain.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string Line { get; set; }
        public int Position { get; set; }
        public bool MultyPass { get; set; }
    }
}
