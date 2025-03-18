using PF_Desktop.ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PF_Desktop.Zakat
{
    public partial class AddZakatDueForm : Form
    {
        public AddZakatDueForm()
        {
            InitializeComponent();
            FormLoad();
        }

        private void FormLoad()
        {
            azdf_tbDueZakat.KeyPress += AssetControlsEvents.DecimalTextBox_KeyPress;
        }
    }
}
