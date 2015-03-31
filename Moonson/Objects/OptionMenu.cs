using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moonson
{
    class OptionMenu : Panel
    {
        //Variables
        private List<String> _buttons;
        private int _arcs;
        private RoundButton btnMenu;
        //Parameters
        private const int startGrade = 90;
        private const int separation = 6;
        private Color colSelect = Color.FromArgb(100, 255, 102, 102);
        private Color colUnSelect = Color.FromArgb(100, 102, 0, 51);
        //Flags
        private int buttonSel = 0;
        private Boolean addButton = false;

        public OptionMenu()
        {
            this.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _arcs = this._buttons.Count();
            int gradeArc = 360 / _arcs;
            int stepGrade = startGrade;
            for (var t = 0; t < _arcs; t++)
            {
                Pen p2 = new Pen((t == buttonSel) ? colSelect : colUnSelect, 2);
                Rectangle rt2 = new Rectangle(0, 0, this.Size.Width - 1, this.Size.Height - 1);
                e.Graphics.DrawArc(p2, rt2, stepGrade + separation, gradeArc - (separation * 2));
                stepGrade = stepGrade + gradeArc - 360;
            }

            if (!addButton)
            {
                btnMenu = new RoundButton
                {
                    Text = _buttons[buttonSel],
                    Location = new System.Drawing.Point(4, 5),
                    Size = new System.Drawing.Size(this.Size.Width - 10, this.Size.Height - 10)
                };
                this.Controls.Add(btnMenu);
                btnMenu.Click += new EventHandler(this.BtnRound_Click);
                addButton = true;
            }
        }

        void BtnRound_Click(Object sender, EventArgs e)
        {
            buttonSel++;
            if (buttonSel >= this._buttons.Count()) buttonSel = 0;
            btnMenu.Text = _buttons[buttonSel];
            this.Invalidate();
        }

        public void Random()
        {
            Random rnd = new Random();
            buttonSel = rnd.Next(1, this._buttons.Count());
            btnMenu.Text = _buttons[buttonSel];
            this.Invalidate();
        }

        public List<String> Buttons
        {
            get
            {
                return this._buttons;
            }
            set
            {
                this._buttons = value;
            }
        }
    }
}
