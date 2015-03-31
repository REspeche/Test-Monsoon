using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moonson
{
    class ButtonBar : Button
    {
        public ButtonBar()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.FromArgb(0, 0, 0, 0);
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Text = "";
            this.FlatAppearance.BorderSize = 0;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {

            // Make the cursor the Hand cursor when the mouse moves  
            // over the button.
            Cursor = Cursors.Hand;

            base.OnMouseMove(e);
        }
    }
}
