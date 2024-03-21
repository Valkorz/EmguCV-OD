using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;

namespace ObjectDetection
{
    public class NumericInputFormDesigner : ControlDesigner
    {
        // Constructor
        public NumericInputFormDesigner()
        {
        }

        // Override OnPaintAdornments method if you need to draw something on the design surface
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);
            // Add custom painting code if needed
        }
    }
}
