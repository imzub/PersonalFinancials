using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PF_Desktop.ClassLib
{
    public static class AssetControlsEvents
    {
        public static void DecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Allow control keys (Backspace, Delete, Left, Right Arrows)
                if (char.IsControl(e.KeyChar))
                    return;

                // Allow digits (0-9)
                if (char.IsDigit(e.KeyChar))
                    return;

                // Allow only one decimal point (.)
                if (e.KeyChar == '.' && !textBox.Text.Contains("."))
                    return;

                // Block all other characters
                e.Handled = true;
            }
        }
    }
}
