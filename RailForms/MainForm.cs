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
            var stations = rail.GetAllStations().ToArray();
            var placeHolder = new Station(-1, "בחר תחנה");

            cbxSource.Items.Insert(0, placeHolder);
            cbxSource.Items.AddRange(stations);
            cbxSource.DisplayMember = "Name";
            cbxSource.ValueMember = "Id";
            cbxSource.SelectedIndex = 0;
            cbxSource.SelectedIndexChanged += cbxSource_SelectedIndexChanged;

            cbxDestination.Items.Clear();
            cbxDestination.Items.Insert(0, placeHolder);
            cbxDestination.Items.AddRange(stations);
            cbxDestination.DisplayMember = "Name";
            cbxDestination.ValueMember = "Id";
            cbxDestination.SelectedIndex = 0;
        }

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem;
            Debug.WriteLine(item.ToString());

            //cbxDestination.Items.Clear();
            //cbxDestination.Items.Insert(0, "בחר תחנה");
            //cbxDestination.Items.AddRange(rail.GetLineStations((item as Station).Id).ToArray());
            //cbxDestination.DisplayMember = "Name";
            //cbxDestination.ValueMember = "Id";
            //cbxDestination.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var source = cbxSource.SelectedItem as Station;
            var destination = cbxDestination.SelectedItem as Station;
            if (source.Id < 0 && destination.Id < 0)
            {
                MessageBox.Show("מוצא: בחר תחנה\nיעד: בחר תחנה", "שגיאת מידע", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
            }
            if (source.Id < 0)
            {
                MessageBox.Show("מוצא: בחר תחנה", "שגיאת מידע", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
            }
            if (destination.Id < 0)
            {
                MessageBox.Show("יעד: בחר תחנה", "שגיאת מידע", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
            }
            if (source.Id == destination.Id)
            {
                MessageBox.Show("נא בחר תחנות יעד ומוצא שונות", "שגיאת מידע", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
            }
        }
    }
}
