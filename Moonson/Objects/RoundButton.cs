using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Moonson
{
    class RoundButton : Button
    {

        public RoundButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            FlatAppearance.BorderSize = 0;
            this.BackColor = Color.FromArgb(50, Color.Black);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, Color.Black);
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, Color.Yellow);
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForeColor = Color.White;
            this.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grEllipse = new GraphicsPath();
            grEllipse.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(grEllipse);
            this.Text = this.Text.ToUpper();
            base.OnPaint(e);
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
