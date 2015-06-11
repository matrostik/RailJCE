using RailDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailForms
{
    public partial class ResultForm : Form
    {
        private Station source { get; set; }
        private Station destination { get; set; }
        
        public ResultForm()
        {
            InitializeComponent();
        }

        public void SetData(Station source, Station destination)
        {
            this.source = source;
            this.destination = destination;
        }


    }
}
