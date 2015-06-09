using RailDomain;
using RailDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailForms
{
    public partial class MainForm : Form
    {
        private RailBL rail { get; set; }

        public MainForm()
        {
            InitializeComponent();
            rail = new RailBL();
            BindingControls();
        }

        private void BindingControls()
        {
            cbxSource.Items.Insert(0, "בחר תחנה");
            cbxSource.Items.AddRange(rail.GetAllStations().ToArray());
            cbxSource.DisplayMember = "Name";
            cbxSource.ValueMember = "Id";
            cbxSource.SelectedIndex = 0;
            cbxSource.SelectedIndexChanged += cbxSource_SelectedIndexChanged;
        }

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem;
            Debug.WriteLine(item.ToString());

            cbxDestination.Items.Clear();
            cbxDestination.Items.Insert(0, "בחר תחנה");
            cbxDestination.Items.AddRange(rail.GetLineStations((item as Station).Id).ToArray());
            cbxDestination.DisplayMember = "Name";
            cbxDestination.ValueMember = "Id";
            cbxDestination.SelectedIndex = 0;
        }
    }
}
