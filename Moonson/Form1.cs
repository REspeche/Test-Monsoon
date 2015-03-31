using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moonson
{
    public partial class Form1 : Form
    {
        private const int sizeButton = 160;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create Menu Bar (TOP)
            this.Controls.Add(new TopBar
            {
                ButtonList = new List<Bitmap>(new Bitmap[]{
                    Moonson.Properties.Resources.MON_searchIcon_2x,
                    Moonson.Properties.Resources.MON_calendarIcon_2x,
                    Moonson.Properties.Resources.MON_compassIcon_2x,
                    null,null,null,null,
                    Moonson.Properties.Resources.MON_menuIcon_2x
                }),
                Size = new System.Drawing.Size(this.Width, 48),
                SizeIcon = 27
            });

            //Create Menu Bar (BOTTOM)
            this.Controls.Add(new TopBar
            {
                ButtonList = new List<Bitmap>(new Bitmap[]{
                    null,
                    Moonson.Properties.Resources.MON_Ellipse_13_copy_2x_refresh,
                    Moonson.Properties.Resources.MON_Ellipse_13_copy_2x_go,
                    null
                }),
                Events = new List<EventHandler>(new EventHandler[]{
                    null,
                    new EventHandler(this.BtnRefresh_Click),
                    new EventHandler(this.BtnNewForm_Click),
                    null
                }),
                Size = new System.Drawing.Size(this.Width, 80),
                SizeIcon = 60,
                Location = new System.Drawing.Point(0, this.Height-80),
                OverColor = false
            });

            //Create options menu
            List<List<String>> buttons = new List<List<string>>();
            buttons.Add(new List<string> { "one of a kind", "small batch", "large batch", "mass market" });
            buttons.Add(new List<string> { "savory", "sweet", "umami" });
            buttons.Add(new List<string> { "spicy", "mild" });
            buttons.Add(new List<string> { "crunchy", "mushy", "smooth" });
            buttons.Add(new List<string> { "a little", "a lot" });
            buttons.Add(new List<string> { "breakfast", "brunch", "lunch", "snack", "dinner" });
            RenderButtons(buttons);
        }

        void BtnRefresh_Click(Object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(OptionMenu))
                {
                    OptionMenu itemO = (OptionMenu)item;
                    itemO.Random();
                }
            }
        }

        void BtnNewForm_Click(Object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Top = this.Top;
            form2.Left = this.Left;
            form2.Show();
        }

        private void RenderButtons(List<List<String>> buttons)
        {
            int margenButton;
            int initX, initY = 60; //start position Y
            int countX = this.Width / sizeButton;
            margenButton = ((this.Width / countX) - sizeButton) / 2;
            initX = margenButton; //start position X
            int x = initX, y = initY;

            for (var r = 0; r < buttons.Count(); r++)
            {
                this.Controls.Add(new OptionMenu
                {
                    Location = new System.Drawing.Point(x, y),
                    Buttons = buttons[r],
                    Size = new System.Drawing.Size(sizeButton, sizeButton)
                });
                x += sizeButton + margenButton;
                if ((x + sizeButton) > this.Width)
                {
                    x = initX;
                    y += sizeButton + margenButton;
                }
            }
        }

    }
}
