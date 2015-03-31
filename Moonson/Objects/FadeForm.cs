using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Moonson
{
    public abstract class FadeForm : Form
    {
        #region Win32

        const int AW_HIDE = 0X10000;
        const int AW_ACTIVATE = 0X20000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_SLIDE = 0X40000;
        const int AW_BLEND = 0X80000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int AnimateWindow
        (IntPtr hwand, int dwTime, int dwFlags);

        #endregion

        #region Variables

        private bool _UseSlideAnimation;

        #endregion

        #region Constructor

        public FadeForm() : this(false) { }
        

        public FadeForm(bool useSlideAnimation)
        {
            _UseSlideAnimation = useSlideAnimation;
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AnimateWindow(this.Handle, 1000, AW_ACTIVATE | (_UseSlideAnimation ? AW_HOR_POSITIVE | AW_SLIDE : AW_BLEND));
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (e.Cancel == false)
            {
                AnimateWindow(this.Handle, 1000, AW_HIDE | (_UseSlideAnimation ? AW_HOR_NEGATIVE | AW_SLIDE : AW_BLEND));
            }
        }

        #endregion

    }
}
