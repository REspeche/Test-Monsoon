using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moonson
{
    class TopBar : Panel
    {
        private List<EventHandler> _events;
        private List<Bitmap> _buttonList;
        private const int separator = 10;
        private int _sizeIcon;
        private Boolean _overColor = true;

        public TopBar()
        {
            this.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int widthCell = this.Width / _buttonList.Count;

            for (var t = 0; t < _buttonList.Count; t++)
            {
                if (_buttonList[t] != null)
                {
                    ButtonBar button = new ButtonBar
                    {
                        Size = new System.Drawing.Size(_sizeIcon, _sizeIcon),
                        Location = new System.Drawing.Point(widthCell * t + separator, separator),
                        BackgroundImage = _buttonList[t]
                    };
                    button.FlatAppearance.MouseOverBackColor = (_overColor) ? Color.FromArgb(70, Color.Black) : Color.FromArgb(0, Color.Black);
                    button.FlatAppearance.MouseDownBackColor = (_overColor) ? Color.FromArgb(90, Color.Black) : Color.FromArgb(0, Color.Black);
                    if (_events!=null) button.Click += _events[t];
                    this.Controls.Add(button);
                }
            }
        }

        public List<EventHandler> Events
        {
            get
            {
                return this._events;
            }
            set
            {
                this._events = value;
            }
        }

        public List<Bitmap> ButtonList
        {
            get
            {
                return this._buttonList;
            }
            set
            {
                this._buttonList = value;
            }
        }

        public int SizeIcon
        {
            get
            {
                return this._sizeIcon;
            }
            set
            {
                this._sizeIcon = value;
            }
        }

        public Boolean OverColor
        {
            get
            {
                return this._overColor;
            }
            set
            {
                this._overColor = value;
            }
        }
    }
}
